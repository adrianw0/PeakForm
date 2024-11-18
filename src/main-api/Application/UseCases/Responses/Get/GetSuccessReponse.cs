using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Responses.Get;
public class GetSuccessReponse<T> : GetReponse<T>
{
    public required List<T> Entity { get; set; } = new();
}
