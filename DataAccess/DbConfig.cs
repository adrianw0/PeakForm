﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DataAccess;

#pragma warning disable
public class DbConfig
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}
