﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;
public class Unit : IEntity
{
    public Guid Id { get; init; }
    public required string Name { get; set; }
    public required string Code { get; set; }
}
