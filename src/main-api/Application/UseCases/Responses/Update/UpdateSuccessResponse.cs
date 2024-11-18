﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Responses.Update;
public class UpdateSuccessResponse<T> : UpdateResponse<T> 
{
    public T? Entity { get; internal set; }
}
