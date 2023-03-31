﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces;
public interface IRepository<TDocument> where TDocument : IDocument
{
    Task<IEnumerable<TDocument>> GetAllAsync();
    Task InsertOneAsync(TDocument document);
}
