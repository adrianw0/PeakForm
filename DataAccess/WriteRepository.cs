using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using DataAccess.Mongo.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccess.Mongo;
public class WriteRepository<TDocument> : IWriteRepository<TDocument> where TDocument : IEntity
{
    private readonly IMongoCollection<TDocument> _collection;
    public WriteRepository(IDbContext dbContext)
    {
        _collection = dbContext.GetCollection<TDocument>();
    }

    public async Task InsertOneAsync(TDocument document)
    {
        await _collection.InsertOneAsync(document);
    }

    public async Task InsertManyAsync(IEnumerable<TDocument> documents)
    {
        await InsertManyAsync(documents);
    }

    public async Task<bool> DeleteByIdAsync(Guid Id)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, Id);
        var r= await _collection.DeleteOneAsync(filter);
        return r.DeletedCount > 0;
    }

    public async Task DeleteOneAsync(Expression<Func<TDocument, bool>> filter)
    {
        await _collection.DeleteManyAsync(filter);
    }
    
    public async Task<bool> UpdateAsync(TDocument Document) //replace but will be update someday...
    {
        
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, Document.Id);
        var updated= await _collection.ReplaceOneAsync(filter, Document);
        return updated.ModifiedCount > 0;
    }
}
