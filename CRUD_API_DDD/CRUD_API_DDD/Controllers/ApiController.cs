using CRUD.Application.Extensions;
using CRUD.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace CRUD_API_DDD.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected ActionResult CustomResponse(OperationResult result)
        {
            var jsonOptions = new JsonSerializerOptions();
            jsonOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            //var userId = Convert.ToInt64(User.FindFirst("idUser")?.Value);

            if (!result.IsValid)
            {
                var responseError = ErrorResponse(result);

                return responseError;
            }

            return Ok(result.Content ?? string.Empty);
        }

        private ActionResult ErrorResponse(OperationResult result)
        {
            switch (result.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return BadRequest(MapErrorsToResponse(result.Result));

                case HttpStatusCode.NotFound:
                    return NotFound(MapErrorsToResponse(result.Result));

                case HttpStatusCode.Unauthorized:
                    return Unauthorized(MapErrorsToResponse(result.Result));

                default:
                    return BadRequest(MapErrorsToResponse(result.Result));
            }
        }

        private static ErrorViewModel MapErrorsToResponse(ValidationResult validationResult)
           => new ErrorViewModel(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
    }
}
