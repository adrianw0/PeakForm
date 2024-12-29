using Core.Interfaces.Repositories;
using DataAccess.Mongo.Interfaces;
using Domain;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace DataAccess.Mongo;
public class WriteRepository<TDocument>(IDbContext dbContext) : IWriteRepository<TDocument> where TDocument : IEntity
{
    private readonly IMongoCollection<TDocument> _collection = dbContext.GetCollection<TDocument>();

    public async Task InsertOneAsync(TDocument document)
    {
        await _collection.InsertOneAsync(document);
    }

    public async Task InsertManyAsync(IEnumerable<TDocument> documents)
    {
        await _collection.InsertManyAsync(documents);
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
        var r = await _collection.DeleteOneAsync(filter);
        return r.DeletedCount > 0;
    }

    public async Task DeleteOneAsync(Expression<Func<TDocument, bool>> filter)
    {
        await _collection.DeleteManyAsync(filter);
    }

    public async Task<bool> UpdateAsync(TDocument document)
    {

        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
        var updated = await _collection.ReplaceOneAsync(filter, document);
        return updated.ModifiedCount > 0;
    }
}
