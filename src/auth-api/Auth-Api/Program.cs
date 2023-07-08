using Auth.Application.Services;
using Auth.DAL;
using Auth.DAL.Repository;
using Auth.Infrastructure.Services;
using Auth.Infrastructure.Services.Jwt;
using Auth_Api.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Auth_Api;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var config = builder.Configuration;
        // Add services to the container.

        builder.Services.Configure<JwtSettings>(config.GetSection("JwtSettings"));

        var conn = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddSingleton<IAuthTokenService, JwtService>();

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();

        builder.Services.AddDbContext<AuthDbContext>(optionsAction: options =>
        options.UseNpgsql(conn));

        builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
        })
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseMiddleware<ErrorHandlerMiddleware>();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<AuthDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        app.Run();
    }
}