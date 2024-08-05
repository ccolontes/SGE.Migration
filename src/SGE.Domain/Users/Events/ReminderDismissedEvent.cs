using SGE.Domain.Common;

namespace SGE.Domain.Users.Events;

public record ReminderDismissedEvent(Guid ReminderId) : IDomainEvent;