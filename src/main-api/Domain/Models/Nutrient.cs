﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public class Nutrient : IEntity
{
    public Guid Id { get; init; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required Unit Unit { get; set; }
}
