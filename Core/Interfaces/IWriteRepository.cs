using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces;
public interface IWriteRepository<TDocument> where TDocument : IEntity
{
    Task InsertOneAsync(TDocument document);
    Task InsertManyAsync(IEnumerable<TDocument> documents);
    Task<bool> UpdateAsync(TDocument Document);
    Task DeleteOneAsync(Expression<Func<TDocument, bool>> filter);
    Task<bool> DeleteByIdAsync(Guid Id);
}
