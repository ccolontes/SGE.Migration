using Microsoft.AspNetCore.Mvc.Infrastructure;

using SGE.Api.Common.Errors;
using SGE.Api.Mappings;

namespace SGE.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, SgeProblemDetailsFactory>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddProblemDetails();

        services.AddMappings();

        return services;
    }
}