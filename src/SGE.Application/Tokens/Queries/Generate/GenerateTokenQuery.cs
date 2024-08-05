using ErrorOr;
using MediatR;
using SGE.Application.Authentication.Queries.Login;
using SGE.Domain.Users;

namespace SGE.Application.Tokens.Queries.Generate;

public record GenerateTokenQuery(
    Guid? Id,
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType,
    List<string> Permissions,
    List<string> Roles) : IRequest<ErrorOr<GenerateTokenResult>>;