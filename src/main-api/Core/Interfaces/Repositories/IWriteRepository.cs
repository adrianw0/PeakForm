using Domain;
using System.Linq.Expressions;

namespace Core.Interfaces.Repositories;
public interface IWriteRepository<TDocument> where TDocument : IEntity
{
    Task InsertOneAsync(TDocument document);
    Task InsertManyAsync(IEnumerable<TDocument> documents);
    Task<bool> UpdateAsync(TDocument document);
    Task DeleteOneAsync(Expression<Func<TDocument, bool>> filter);
    Task<bool> DeleteByIdAsync(Guid Id);
}
