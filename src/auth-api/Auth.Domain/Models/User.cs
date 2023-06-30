using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Models;
public class User
{
    public string Id { get; set; } = string.Empty;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
}
