using SGE.Contracts.Common;

namespace SGE.Contracts.Subscriptions;

public record CreateSubscriptionRequest(
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType);