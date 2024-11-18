using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Responses.Delete;
public class DeleteSuccessResponse<T> : DeleteResponse<T>
{
    public string Message { get; internal set; } = "Success";
}
