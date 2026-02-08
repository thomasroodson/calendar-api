namespace ProjectCalendar.API.Middleware
{
    public static class NotFoundMiddlewareExtensions
    {
        public static IApplicationBuilder UseNotFoundHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<NotFoundMiddleware>();
        }
    }
}
