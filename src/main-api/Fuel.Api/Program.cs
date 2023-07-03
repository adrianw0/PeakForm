using Application.UseCases;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using DataAccess.Mongo;
using Fuel.Api.Middleware;
using Fuel.Api.Providers;
using Fuel.Api.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.RateLimiting;

namespace Fuel.Api;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        

        // Add services to the container.
        builder.Services.AddHttpContextAccessor();

        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.Jwt));
        builder.Services.Configure<RateLimitSettings>(builder.Configuration.GetSection(RateLimitSettings.RateLimit));

        var jwtSettings = new JwtSettings();
        var rateLimitSettings = new RateLimitSettings();

        builder.Configuration.GetSection(JwtSettings.Jwt).Bind(jwtSettings);
        builder.Configuration.GetSection(RateLimitSettings.RateLimit).Bind(rateLimitSettings);


        SetupRateLimiter(builder, rateLimitSettings);
        SetupJwt(builder, jwtSettings);
        
        builder.Services.AddAuthorization();

        AddUseCases(builder);
        builder.Services.Configure<DataAccess.Mongo.DbConfig>(builder.Configuration);
        builder.Services.AddSingleton<IUserProvider, UserProvider>();
        builder.Services.AddSingleton<DataAccess.Mongo.Interfaces.IDbContext, DataAccess.Mongo.DbContext>();
        builder.Services.AddScoped(typeof(IWriteRepository<>), typeof(DataAccess.Mongo.WriteRepository<>));
        builder.Services.AddScoped(typeof(IReadRepository<>), typeof(DataAccess.Mongo.ReadRepository<>));


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


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
        var fixedPolicy = "fixed";
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
