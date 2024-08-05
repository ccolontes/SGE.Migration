using ErrorOr;
using SGE.Application.Common.Security.Permissions;
using SGE.Application.Common.Security.Policies;
using SGE.Application.Common.Security.Request;
using SGE.Application.Subscriptions.Common;

namespace SGE.Application.Subscriptions.Queries.GetSubscription;

[Authorize(Permissions = Permission.Subscription.Get, Policies = Policy.SelfOrAdmin)]
public record GetSubscriptionQuery(Guid UserId)
    : IAuthorizeableRequest<ErrorOr<SubscriptionResult>>;