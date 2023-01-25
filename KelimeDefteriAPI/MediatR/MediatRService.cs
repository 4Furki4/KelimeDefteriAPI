using MediatR;

namespace KelimeDefteriAPI.MediatoR
{
    public static class MediatoRService
    {
        public static IServiceCollection AddMediatRService(this IServiceCollection services)
        {
            services.AddMediatR(typeof(MediatoRService).Assembly);
            return services;
        }
    }
}