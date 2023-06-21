using Core.Interfaces;

using DataAccess.Mongo.Interfaces;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace DataAccess.Mongo;
public class ReadRepository<TDocument> : IReadRepository<TDocument> where TDocument : IEntity
{
    private readonly IMongoCollection<TDocument> _collection;
    public ReadRepository(IDbContext dbContext)
    {
        _collection = dbContext.GetCollection<TDocument>();
    }

    public async Task<TDocument> FindByIdAsync(Guid Id)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, Id);
        return await (await _collection.FindAsync(filter)).SingleOrDefaultAsync();
    }

    public async Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filter)
    {
        return await (await _collection.FindAsync(filter)).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<TDocument>> FindAsync(Expression<Func<TDocument, bool>> filter, int pageNumber, int pageSize)
    {

        var result = await _collection.Find(filter)
            .Skip((pageNumber - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();
        return result;
    }
}
