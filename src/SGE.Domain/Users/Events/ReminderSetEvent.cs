using SGE.Domain.Common;
using SGE.Domain.Reminders;

namespace SGE.Domain.Users.Events;

public record ReminderSetEvent(Reminder Reminder) : IDomainEvent;