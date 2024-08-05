using ErrorOr;
using SGE.Application.Common.Security.Permissions;
using SGE.Application.Common.Security.Policies;
using SGE.Application.Common.Security.Request;

namespace SGE.Application.Reminders.Commands.DismissReminder;

[Authorize(Permissions = Permission.Reminder.Dismiss, Policies = Policy.SelfOrAdmin)]
public record DismissReminderCommand(Guid UserId, Guid SubscriptionId, Guid ReminderId)
    : IAuthorizeableRequest<ErrorOr<Success>>;