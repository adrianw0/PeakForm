using DataAccess.Mongo.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataAccess.Mongo;
public class DbContext : IDbContext
{
    private readonly IOptions<DbConfig> _dbConfig;

    public DbContext(IOptions<DbConfig> dbConfig)
    {
        _dbConfig = dbConfig;
    }

    public IMongoCollection<T> GetCollection<T>()
    {
        var client = new MongoClient(_dbConfig.Value.ConnectionString);
        var database = client.GetDatabase(_dbConfig.Value.DatabaseName);

        var collection = database.GetCollection<T>(typeof(T).Name);

        return collection;

    }
}
