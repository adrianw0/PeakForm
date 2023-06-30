using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Common;
public class ErrorCodes
{
    public const string InvalidCredentials = "InvalidCredentials";
    public const string UserAlreadyExists = "UserAlreadyExists";
    public const string UserNotFound = "UserNotFound";
}
