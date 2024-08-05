using SGE.Domain.Users;

namespace SGE.Application.Authentication.Queries.Login;

public record GenerateTokenResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType,
    string Token);