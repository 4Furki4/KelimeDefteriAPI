namespace KelimeDefteriAPI.Middlewares
{
    public static class ExtensionHandling
    {
        public static IApplicationBuilder UseHTTPInfo(this IApplicationBuilder appBuilder)
        {
            return appBuilder.UseMiddleware<HTTPInfoMiddleware>();
        }

        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder appBuilder)
        {
            return appBuilder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
