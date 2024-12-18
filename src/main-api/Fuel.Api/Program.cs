using System.Reflection;
using Application.Providers.Products;
using Application.UseCases;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using DataAccess.Mongo;
using Fuel.Api.Middleware;
using Fuel.Api.Providers;
using Fuel.Api.Settings;
using Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.RateLimiting;
using FluentValidation;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using FluentValidation;
using FluentAssertions.Common;
using Infrastructure.ExternalAPIs.LLMAssistants;
using Fuel.Api.AiAssistantChat;
using Application.UseCases.AiAssistant;
using Application.UseCases.AiAssistant.QueryAiAssistantStream;
using OpenAI;

namespace Fuel.Api;

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


        builder.Services.Configure<DataAccess.Mongo.DbConfig>(builder.Configuration);
        builder.Services.AddSingleton<IUserProvider, UserProvider>();
        builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        builder.Services.AddSingleton<DataAccess.Mongo.Interfaces.IDbContext, DataAccess.Mongo.DbContext>();
        builder.Services.AddScoped(typeof(IWriteRepository<>), typeof(DataAccess.Mongo.WriteRepository<>));
        builder.Services.AddScoped(typeof(IReadRepository<>), typeof(DataAccess.Mongo.ReadRepository<>));

        builder.Services.AddScoped(typeof(IPromptBuilder), typeof(PromptBuilder));
        builder.Services.AddScoped(typeof(ISessionManager), typeof(SessionManager));
        builder.Services.AddScoped(typeof(ILLMAssistantService), typeof(OpenAiAssistant));


        builder.Services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName.StartsWith("Application")), ServiceLifetime.Transient);

        builder.Services.AddScoped<IExternalProductApiWrapper, OpenFoodFactsApiWrapper>();
        builder.Services.AddScoped<IExternalProductsProvider, ExternalProductsProvider>();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
    
        });
        BsonSerializer.RegisterSerializer(new GuidSerializer(MongoDB.Bson.GuidRepresentation.Standard));


        AddUseCases(builder);

        builder.Services.AddSignalR(o =>
        {
            o.EnableDetailedErrors = true;
        });

        builder.Services.AddSingleton(new OpenAIClient(apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

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
        app.MapHub<ChatHub>("/chatHub");

        //seed
        var dbContext = app.Services.GetService<DataAccess.Mongo.Interfaces.IDbContext>();
#pragma warning disable CS8604 // Possible null reference argument.
        Seeder.SeedAsync(dbContext).GetAwaiter().GetResult();
#pragma warning restore CS8604 // Possible null reference argument.

        app.Run();
    
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

        builder.Services.AddScoped<IAiAssistantService, AiAssistantService>();
    }
}

