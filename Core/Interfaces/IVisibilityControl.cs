using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces;
public interface IVisibilityControl
{
    public User? Owner { get; set; }
    public bool IsGloballyVisible { get; set; } 
}
