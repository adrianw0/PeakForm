
using Core.Interfaces;
using Core.Interfaces.Providers;
using Fuel.Api.Providers;

namespace Fuel.Api;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);


        // Add services to the container.
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

        app.UseAuthorization();


        app.MapControllers();

        app.Run();

      
        
    }
}
