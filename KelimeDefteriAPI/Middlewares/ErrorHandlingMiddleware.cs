using KelimeDefteriAPI.Services.Logger;

namespace KelimeDefteriAPI.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly ILoggerService logger;
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next, ILoggerService logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.Write($"Error Source: {ex.Source}\n------Error Message------\n{ex.Message}");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
