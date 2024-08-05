using ErrorOr;
using SGE.Application.Common.Security.Request;
using SGE.Application.Common.Security.Roles;

namespace SGE.Application.Subscriptions.Commands.CancelSubscription;

[Authorize(Roles = Role.Admin)]
public record CancelSubscriptionCommand(Guid UserId, Guid SubscriptionId) : IAuthorizeableRequest<ErrorOr<Success>>;