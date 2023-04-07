﻿using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;
public class User : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}
