using KelimeDefteriAPI.Services.Logger;
using System.Diagnostics;

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
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            logger.Write("+++++++ New Request Arrived +++++++");
            logger.Write($"- Request Path: {context.Request.Method} {context.Request.Path}");
            logger.Write($"- Origin: {context.Request.Headers.Origin}");
            await next(context);
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            logger.Write($"- Response Status Code: {context.Response.StatusCode}");
            logger.Write($"- Elapsed Time: {ts.TotalMilliseconds:0.00} ms");
            if (context.Request.Method == "POST" && context.Response.StatusCode < 400)
                logger.Write($"- Location: {context.Response.Headers.Location}");
            logger.Write("------- End Of the Request -------");
        }
    }
}
