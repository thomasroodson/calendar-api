using ProjectCalendar.Communication.Responses;
using ProjectCalendar.Exceptions;

namespace ProjectCalendar.API.Middleware
{
    public class NotFoundMiddleware
    {
        private readonly RequestDelegate _next;
        public NotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status404NotFound &&
                !context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(
                   new ResponseErrorJson(
                       ResourceMessagesException.ROUTE_NOT_FOUND
                   )
                );
            }
        }
    }
}
