using System;

namespace Mx.NET.SDK.Domain.Exceptions
{
    public class APIException : Exception
    {
        public int StatusCode { get; set; }
        public new string Message { get; set; }

        public APIException() { }

        public APIException(string content)
            : base(content) { }

        public APIException(string errorMessage, string code)
            : base($"Error when calling API : {errorMessage} with smartContractCode : {code}") { }

        public APIException(APIException apiException)
        {
            StatusCode = apiException.StatusCode;
            Message = apiException.Message;
        }
    }
}
