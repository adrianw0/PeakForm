using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using DataAccess.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccess;
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

    public async Task DeleteByIdAsync(Guid Id)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, Id);
        await _collection.FindOneAndDeleteAsync(filter);
    }

    public async Task DeleteManyAsync(Expression<Func<TDocument, bool>> filter)
    {
        await _collection.DeleteManyAsync(filter);
    }
}
