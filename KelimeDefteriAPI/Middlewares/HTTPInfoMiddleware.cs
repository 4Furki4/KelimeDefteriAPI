using KelimeDefteriAPI.Services.Logger;

namespace KelimeDefteriAPI.Middlewares
{
    public class HTTPInfoMiddleware
    {
        private readonly RequestDelegate next;

        private readonly ILoggerService logger;
        public HTTPInfoMiddleware(RequestDelegate next, ILoggerService logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            logger.Write("+++++++ New Request Arrived +++++++");
            logger.Write($"Request Path: {context.Request.Method}  {context.Request.Path}");
            logger.Write($"Origin: {context.Request.Headers.Origin}");
            await next(context);
            logger.Write($"Response Status Code:{context.Response.StatusCode}");
            if (context.Request.Method == "POST")
                logger.Write($"Location: {context.Response.Headers.Location}");
            logger.Write("------- End Of the Request -------");
        }
    }
}
