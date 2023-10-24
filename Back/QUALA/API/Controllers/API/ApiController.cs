using API.Common.Errors;
using API.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers.API
{
    [ApiController]
    public class ApiController : ControllerBase
    {

        protected IActionResult Problem(List<Error> errors)
        {

            if (errors.Count is 0)
            {
                return Problem();
            }

            if (errors.All(error => error.Type == ErrorType.Validation))
            {
                return ValidationProblem(errors);
            }

            HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            return Problem(errors[0]);
        }

        private IActionResult Problem(Error error)
        {

            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };

            return Problem(statusCode: statusCode, title: error.Description);
        }
        private IActionResult ValidationProblem(List<Error> errors)
        {
            string contenidoJson = JsonConvert.SerializeObject(new DataErrorModel(errors.First().Description));
            return new ContentResult
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Content = contenidoJson,
                ContentType = "application/json",
            };

        }
    }
}
