using SGE.Domain.Common;

namespace SGE.Domain.Users.Events;

public record SubscriptionCanceledEvent(User User, Guid SubscriptionId) : IDomainEvent;