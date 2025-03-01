using Application.Providers.Products;
using Application.Services.AiAssistant;
using Application.Services.AiAssistant.Interfaces;
using Application.UseCases;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using DataAccess.Mongo;
using FluentValidation;
using PeakForm.Api.AiAssistantChat;
using PeakForm.Api.Middleware;
using PeakForm.Api.Providers;
using PeakForm.Api.Settings;
using Infrastructure.ExternalAPIs.LLMAssistants;
using Infrastructure.ExternalAPIs.OpenFoodFactsApiClient;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using OpenAI;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.RateLimiting;

namespace PeakForm.Api;

public static class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);


        // Add services to the container.
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddHttpClient();


        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.Jwt));
        builder.Services.Configure<RateLimitSettings>(builder.Configuration.GetSection(RateLimitSettings.RateLimit));

        var jwtSettings = new JwtSettings();
        var rateLimitSettings = new RateLimitSettings();

        builder.Configuration.GetSection(JwtSettings.Jwt).Bind(jwtSettings);
        builder.Configuration.GetSection(RateLimitSettings.RateLimit).Bind(rateLimitSettings);


        SetupRateLimiter(builder, rateLimitSettings);
        SetupJwt(builder, jwtSettings);

        builder.Services.AddControllers()

            .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        builder.Services.AddAuthorization();


        builder.Services.AddMemoryCache();
        builder.Services.Configure<DataAccess.Mongo.DbConfig>(builder.Configuration);
        builder.Services.AddSingleton<IUserProvider, UserProvider>();
        builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        builder.Services.AddSingleton<DataAccess.Mongo.Interfaces.IDbContext, DataAccess.Mongo.DbContext>();
        builder.Services.AddScoped(typeof(IWriteRepository<>), typeof(DataAccess.Mongo.WriteRepository<>));
        builder.Services.AddScoped(typeof(IReadRepository<>), typeof(DataAccess.Mongo.ReadRepository<>));

        var applicationAssembly = AppDomain.CurrentDomain.GetAssemblies()
            .FirstOrDefault(a => a.FullName != null && a.FullName.StartsWith("Application"));
        if (applicationAssembly != null)
        {
            builder.Services.AddValidatorsFromAssembly(applicationAssembly, ServiceLifetime.Transient);
        }

        builder.Services.AddScoped<IExternalProductApiClient, OpenFoodFactsApiClient>();
        builder.Services.AddScoped<IExternalProductsProvider, ExternalProductsProvider>();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {

        });
        BsonSerializer.RegisterSerializer(new GuidSerializer(MongoDB.Bson.GuidRepresentation.Standard));

        var openAiApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

        AddUseCases(builder);

        if (!string.IsNullOrEmpty(openAiApiKey))
        {
            AddAiServices(builder, openAiApiKey);
            builder.Services.AddSignalR(o =>
            {
                o.EnableDetailedErrors = true;
            });
        }


        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseRateLimiter();

        app.UseMiddleware<ErrorHandlerMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        if (!string.IsNullOrEmpty(openAiApiKey))
        {
            app.MapHub<ChatHub>("/chatHub");
        }


        //seed
        var dbContext = app.Services.GetService<DataAccess.Mongo.Interfaces.IDbContext>();
#pragma warning disable CS8604 // Possible null reference argument.
        Seeder.SeedAsync(dbContext).GetAwaiter().GetResult();
#pragma warning restore CS8604 // Possible null reference argument.

        app.Run();

    }

    private static void AddAiServices(WebApplicationBuilder builder, string openAiApiKey)
    {
        builder.Services.AddSingleton(new OpenAIClient(apiKey: openAiApiKey));
        builder.Services.AddTransient<IAiAssistantService, AiAssistantService>();
        builder.Services.AddScoped<IPromptBuilder, PromptBuilder>();
        builder.Services.AddScoped<ISessionManager, SessionManager>();
        builder.Services.AddScoped<ILLMAssistantService, OpenAiAssistant>();
    }

    private static void SetupJwt(WebApplicationBuilder builder, JwtSettings settings)
    {
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = settings.Issuer,
                ValidAudience = settings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };

            x.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var accessToken = context.Request.Query["access_token"];

                    var path = context.HttpContext.Request.Path;
                    if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/chatHub")))
                    {
                        context.Token = accessToken;
                    }
                    return Task.CompletedTask;
                }
            };

        });
    }

    private static void SetupRateLimiter(WebApplicationBuilder builder, RateLimitSettings settings)
    {
        const string fixedPolicy = "fixed";
        builder.Services.AddRateLimiter(_ => _
            .AddFixedWindowLimiter(policyName: fixedPolicy, options =>
            {
                options.PermitLimit = settings.PermitLimit;
                options.Window = TimeSpan.FromSeconds(settings.Window);
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = settings.QueueLimit;
            }));
    }

    private static void AddUseCases(WebApplicationBuilder builder)
    {
        builder.Services.Scan(scan => scan
        .FromAssembliesOf(typeof(IUseCase<,>))
        .AddClasses(classes => classes.AssignableTo(typeof(IUseCase<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}

