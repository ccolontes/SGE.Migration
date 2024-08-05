using Microsoft.AspNetCore.Builder;
using SGE.Infrastructure.Common.Middleware;

namespace SGE.Infrastructure;

public static class RequestPipeline
{
    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseMiddleware<EventualConsistencyMiddleware>();
        return app;
    }
}