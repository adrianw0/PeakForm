using Auth.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Auth_Api;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        var config = builder.Configuration;
        // Add services to the container.

       

        var conn = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<AuthDbContext>(optionsAction: options =>
        options.UseNpgsql(conn));

        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
