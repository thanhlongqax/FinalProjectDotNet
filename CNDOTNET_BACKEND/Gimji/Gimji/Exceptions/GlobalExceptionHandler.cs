using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Gimji.Exceptions
{
    public class GlobalExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {

                case NotFoundException:
                    var notFound = new
                    {
                        message = context.Exception.Message,
                        success = false,
                        statusCode = 404
                    };

                    context.Result = new ObjectResult(notFound)
                    {
                        StatusCode = StatusCodes.Status404NotFound
                    };
                    break;

                case ConflictException:
                    var conflict = new
                    {
                        message = context.Exception.Message,
                        success = false,
                        statusCode = 409
                    };

                    context.Result = new ObjectResult(conflict)
                    {
                        StatusCode = StatusCodes.Status409Conflict
                    };
                    break;

                case Exception:
                    var internalServerError = new
                    {
                        message = context.Exception.Message,
                        success = false,
                        statusCode = 500
                    };

                    context.Result = new ObjectResult(internalServerError)
                    {
                        StatusCode = StatusCodes.Status500InternalServerError
                    };
                    break;
                    

            }
        }
    }
}
