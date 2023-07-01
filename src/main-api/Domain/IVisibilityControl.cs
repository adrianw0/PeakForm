using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public interface IVisibilityControl
{
    public string OwnerId { get; set; }
    public bool IsGloballyVisible { get; set; }
}
