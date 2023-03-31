using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces;
public interface IDbContext
{
    public IMongoCollection<T> GetCollection<T>();
}
