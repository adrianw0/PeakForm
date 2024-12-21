using MongoDB.Driver;

namespace DataAccess.Mongo.Interfaces;
public interface IDbContext
{
    public IMongoCollection<T> GetCollection<T>();
}
