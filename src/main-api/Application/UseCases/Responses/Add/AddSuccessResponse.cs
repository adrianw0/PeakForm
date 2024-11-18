using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Responses.Add;
public class AddSuccessResponse<T> : AddReponse<T> 
{
    public T? Entity { get; set; }
}
