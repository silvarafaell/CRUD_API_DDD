using System.ComponentModel.DataAnnotations;
using System.Net;
using FluentValidation.Results;

namespace CRUD.Application.Extensions
{
    public class OperationResult
    {
        public object Content { get; private set; }
        public FluentValidation.Results.ValidationResult Result { get; private set; }
        public bool IsValid => Result?.IsValid ?? true;
        public HttpStatusCode StatusCode { get; private set; }

        public OperationResult(FluentValidation.Results.ValidationResult result, HttpStatusCode statusCode)
        {
            Result = result;
            StatusCode = statusCode;
        }

        public OperationResult()
        {
        }

        public OperationResult(FluentValidation.Results.ValidationResult result) => Result = result;

        public OperationResult(object content) => Content = content;
    }
}
