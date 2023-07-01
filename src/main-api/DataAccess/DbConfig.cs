using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DataAccess.Mongo;

public class DbConfig
{
    public required string ConnectionString { get; set; }
    public required string DatabaseName { get; set; }
}
