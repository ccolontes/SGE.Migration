using System.Diagnostics;

using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

using SGE.Api.Common.Http;

namespace SGE.Api.Common.Errors;

public class SgeProblemDetailsFactory(
    IOptions<ApiBehaviorOptions> options,
    IOptions<ProblemDetailsOptions>? problemDetailsOptions = null)
    : ProblemDetailsFactory
{
    private readonly ApiBehaviorOptions _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
    private readonly Action<ProblemDetailsContext>? _configure = problemDetailsOptions?.Value?.CustomizeProblemDetails;

    public override ProblemDetails CreateProblemDetails(HttpContext httpContext, int? statusCode = null, string? title = null,
#pragma warning disable SA1117
        string? type = null, string? detail = null, string? instance = null)
#pragma warning restore SA1117
    {
        statusCode ??= StatusCodes.Status500InternalServerError;
        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Detail = detail,
            Instance = instance,
        };
        ApplyProblemDetails(httpContext, problemDetails, statusCode.Value);
        return problemDetails;
    }

    public override ValidationProblemDetails CreateValidationProblemDetails(
        HttpContext httpContext,
#pragma warning disable SA1117
        ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null,
#pragma warning restore SA1117
        string? detail = null, string? instance = null)
    {
        ArgumentNullException.ThrowIfNull(modelStateDictionary);
        statusCode ??= StatusCodes.Status400BadRequest;
        var problemDetails = new ValidationProblemDetails(modelStateDictionary)
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Detail = detail,
            Instance = instance,
        };
        if (title != null)
        {
            problemDetails.Title = title;
        }

        ApplyProblemDetails(httpContext, problemDetails, statusCode.Value);
        return problemDetails;
    }

    private void ApplyProblemDetails(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
    {
        problemDetails.Status ??= statusCode;
        if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientError))
        {
            problemDetails.Title ??= clientError.Title;
            problemDetails.Type ??= clientError.Link;
        }

        var traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
        if (traceId != null)
        {
            problemDetails.Extensions["traceId"] = traceId;
        }

        if (httpContext?.Items[HttpContextItemKeys.Errors] is List<Error> errors)
        {
            problemDetails.Extensions.Add("errors", errors.Select(e => e.Code));
        }

        _configure?.Invoke(
            new ProblemDetailsContext { HttpContext = httpContext!, ProblemDetails = problemDetails });
    }
}