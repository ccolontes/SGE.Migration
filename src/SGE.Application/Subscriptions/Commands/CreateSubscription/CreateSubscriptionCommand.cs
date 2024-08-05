using ErrorOr;
using SGE.Application.Common.Security.Permissions;
using SGE.Application.Common.Security.Policies;
using SGE.Application.Common.Security.Request;
using SGE.Application.Subscriptions.Common;
using SGE.Domain.Users;

namespace SGE.Application.Subscriptions.Commands.CreateSubscription;

[Authorize(Permissions = Permission.Subscription.Create, Policies = Policy.SelfOrAdmin)]
public record CreateSubscriptionCommand(
    Guid UserId,
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType)
    : IAuthorizeableRequest<ErrorOr<SubscriptionResult>>;