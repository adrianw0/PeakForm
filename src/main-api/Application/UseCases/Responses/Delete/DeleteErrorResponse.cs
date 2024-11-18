﻿using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Responses.Delete;
public class DeleteErrorResponse<T> : DeleteResponse<T>
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
