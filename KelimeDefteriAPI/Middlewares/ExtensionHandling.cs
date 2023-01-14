namespace KelimeDefteriAPI.Middlewares
{
    public static class ExtensionHandling
    {
        public static IApplicationBuilder UseHTTPInfo(this IApplicationBuilder appBuilder)
        {
            return appBuilder.UseMiddleware<HTTPInfoMiddleware>();
        }
    }
}
