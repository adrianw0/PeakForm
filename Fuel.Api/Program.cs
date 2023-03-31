
using Core.Interfaces;
using Core.Models;
using DataAccess;
using DataAccess.Interfaces;

namespace Fuel.Api;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Configure<DbConfig>(builder.Configuration);

        builder.Services.AddSingleton<IDbContext, DbContext>();
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        
        // Add services to the container.

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

        app.UseAuthorization();


        app.MapControllers();

        app.Run();

      
        
    }
}
