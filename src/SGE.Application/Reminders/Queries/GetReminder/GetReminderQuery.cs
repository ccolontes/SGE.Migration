using ErrorOr;
using SGE.Application.Common.Security.Permissions;
using SGE.Application.Common.Security.Policies;
using SGE.Application.Common.Security.Request;
using SGE.Domain.Reminders;

namespace SGE.Application.Reminders.Queries.GetReminder;

[Authorize(Permissions = Permission.Reminder.Get, Policies = Policy.SelfOrAdmin)]
public record GetReminderQuery(Guid UserId, Guid SubscriptionId, Guid ReminderId) : IAuthorizeableRequest<ErrorOr<Reminder>>;