using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces;
public interface IReadRepository<TDocument> where TDocument : IEntity
{
    Task<TDocument> FindByIdAsync(Guid Id);
    Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filter);
    Task<IEnumerable<TDocument>> FindAsync(Expression<Func<TDocument, bool>> filter, int pageNumber, int pageSize);
}
