using DataAccess.Mongo.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Data.Common;

namespace DataAccess.Mongo;
public class DbContext : IDbContext
{
    private readonly IOptions<DbConfig> DbConfig;

    public DbContext(IOptions<DbConfig> dbConfig)
    {
        DbConfig = dbConfig;
    }

    public IMongoCollection<T> GetCollection<T>()
    {
        var client = new MongoClient(DbConfig.Value.ConnectionString);
        var database = client.GetDatabase(DbConfig.Value.DatabaseName);
        return database.GetCollection<T>(typeof(T).Name);
    }
}
