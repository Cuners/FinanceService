using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Application.UseCases
{
    public abstract class Response
    {
        public bool Success { get; }
        public string? ErrorMessage { get; }
        public string? ErrorCode { get; }

        protected Response(bool success, string? errorMessage = null, string? errorCode = null)
        {
            Success = success;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }
    }
}
