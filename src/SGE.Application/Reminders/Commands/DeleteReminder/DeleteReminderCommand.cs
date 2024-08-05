using ErrorOr;
using SGE.Application.Common.Security.Permissions;
using SGE.Application.Common.Security.Policies;
using SGE.Application.Common.Security.Request;

namespace SGE.Application.Reminders.Commands.DeleteReminder;

[Authorize(Permissions = Permission.Reminder.Delete, Policies = Policy.SelfOrAdmin)]
public record DeleteReminderCommand(Guid UserId, Guid SubscriptionId, Guid ReminderId)
    : IAuthorizeableRequest<ErrorOr<Success>>;