using ErrorOr;
using SGE.Application.Common.Security.Permissions;
using SGE.Application.Common.Security.Policies;
using SGE.Application.Common.Security.Request;
using SGE.Domain.Reminders;

namespace SGE.Application.Reminders.Queries.ListReminders;

[Authorize(Permissions = Permission.Reminder.Get, Policies = Policy.SelfOrAdmin)]
public record ListRemindersQuery(Guid UserId, Guid SubscriptionId) : IAuthorizeableRequest<ErrorOr<List<Reminder>>>;