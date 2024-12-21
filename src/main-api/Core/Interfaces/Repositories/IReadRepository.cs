using Domain;
using System.Linq.Expressions;

namespace Core.Interfaces.Repositories;
public interface IReadRepository<TDocument> where TDocument : IEntity
{
    Task<TDocument> FindByIdAsync(Guid id);
    Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filter);
    Task<IEnumerable<TDocument>> FindAsync(Expression<Func<TDocument, bool>> filter, int pageNumber, int pageSize);
    Task<bool> ExistsAsync(Expression<Func<TDocument, bool>> predicate);
}
