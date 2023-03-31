using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using DataAccess.Interfaces;
using MongoDB.Driver;

namespace DataAccess;
public class Repository<TDocument> : IRepository<TDocument> where TDocument : IDocument
{
    private readonly IMongoCollection<TDocument> _collection;
    public Repository(IDbContext dbContext)
    {
        _collection = dbContext.GetCollection<TDocument>();
    }

    public async Task<IEnumerable<TDocument>> GetAllAsync()
    {
        var result = await _collection.FindAsync(_ => true);
        return await result.ToListAsync();
    }

    public async Task InsertOneAsync(TDocument document)
    {
        await _collection.InsertOneAsync(document);
    }

    public async Task InsertManyAsync(IEnumerable<TDocument> documents)
    {
        await InsertManyAsync(documents);
    }

    public async Task<TDocument> FindByIdAsync(Guid Id)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, Id);
        return await (await _collection.FindAsync(filter)).SingleOrDefaultAsync() ;
    }

    public async Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filter)
    {
        return await (await _collection.FindAsync(filter)).SingleOrDefaultAsync();
    }

    
}
