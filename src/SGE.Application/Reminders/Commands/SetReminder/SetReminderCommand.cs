using ErrorOr;
using SGE.Application.Common.Security.Permissions;
using SGE.Application.Common.Security.Policies;
using SGE.Application.Common.Security.Request;
using SGE.Domain.Reminders;

namespace SGE.Application.Reminders.Commands.SetReminder;

[Authorize(Permissions = Permission.Reminder.Set, Policies = Policy.SelfOrAdmin)]
public record SetReminderCommand(Guid UserId, Guid SubscriptionId, string Text, DateTime DateTime)
    : IAuthorizeableRequest<ErrorOr<Reminder>>;