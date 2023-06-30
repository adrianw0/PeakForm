using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DAL.Exceptions;
public class UserCreationException : Exception
{
    public string Errors { get; }

    public UserCreationException(string errors)
    {
        Errors = errors;
    }
}
