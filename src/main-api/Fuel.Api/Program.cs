using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using DataAccess.Mongo;
using Fuel.Api.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Fuel.Api;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        var config = builder.Configuration;

        // Add services to the container.
        //builder.Services.AddAuthentication(x =>
        //{
        //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        //}).AddJwtBearer(x =>
        //{
        //    x.TokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidIssuer = config["JwtSettings:Issuer"],
        //        ValidAudience = config["JwtSettings:Audience"],
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
        //        ValidateIssuer = true,
        //        ValidateAudience = true,
        //        ValidateLifetime = true,
        //        ValidateIssuerSigningKey = true
        //    };
        //});

        //builder.Services.AddAuthorization();



        builder.Services.Configure<DataAccess.Mongo.DbConfig>(builder.Configuration);
        builder.Services.AddSingleton<DataAccess.Mongo.Interfaces.IDbContext, DataAccess.Mongo.DbContext>();
        builder.Services.AddScoped(typeof(IWriteRepository<>), typeof(DataAccess.Mongo.WriteRepository<>));
        builder.Services.AddScoped(typeof(IReadRepository<>), typeof(DataAccess.Mongo.ReadRepository<>));

        //builder.Services.AddTransient<IUserProvider, UserProvider>();



        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        //app.UseAuthentication();
        //app.UseAuthorization();


        app.MapControllers();

        //seed
        var dbContext = app.Services.GetService<DataAccess.Mongo.Interfaces.IDbContext>();
#pragma warning disable CS8604 // Possible null reference argument.
        Seeder.SeedAsync(dbContext).GetAwaiter().GetResult();
#pragma warning restore CS8604 // Possible null reference argument.

        app.Run();

      
        
    }
}
