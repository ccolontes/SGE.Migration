using SGE.Domain.Common;

namespace SGE.Domain.Users.Events;

public record ReminderDeletedEvent(Guid ReminderId) : IDomainEvent;