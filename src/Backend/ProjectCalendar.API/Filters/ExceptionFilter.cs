using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectCalendar.Communication.Responses;
using ProjectCalendar.Exceptions;
using ProjectCalendar.Exceptions.ExceptionsBase;
using System.Net;

namespace ProjectCalendar.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ProjectCalendarException)
                HandleProjectException(context);
            else
                ThrowUnknowException(context);

        }

        private static void HandleProjectException(ExceptionContext context)
        {
            if(context.Exception is ErrorOnValidationException exception)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorMessages));
            }
        }

        private static void ThrowUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesException.UNKNOW_ERROR));
        }

    }
}
