using SGE.Contracts.Common;

namespace SGE.Contracts.Subscriptions;

public record SubscriptionResponse(
    Guid Id,
    Guid UserId,
    SubscriptionType SubscriptionType);