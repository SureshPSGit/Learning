using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OneOfTutorial.WithExceptions.Models;

namespace OneOfTutorial.WithExceptions.Filters
{
    public class BadRequestExceptionFilter : IActionFilter, IOrderedFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!(context.Exception is BadRequestException exception))
            {
                return;
            }

            context.Result = new ObjectResult(exception.Error)
            {
                StatusCode = 400
            };
            context.ExceptionHandled = true;
        }

        public void OnActionExecuting(ActionExecutingContext context) {}

        public int Order { get; } = int.MaxValue - 10;
    }
}
