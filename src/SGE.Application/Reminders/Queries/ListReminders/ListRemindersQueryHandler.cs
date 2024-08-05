using ErrorOr;
using MediatR;
using SGE.Application.Common.Interfaces;
using SGE.Domain.Reminders;

namespace SGE.Application.Reminders.Queries.ListReminders;

public class ListRemindersQueryHandler(IRemindersRepository _remindersRepository) : IRequestHandler<ListRemindersQuery, ErrorOr<List<Reminder>>>
{
    public async Task<ErrorOr<List<Reminder>>> Handle(ListRemindersQuery request, CancellationToken cancellationToken)
    {
        return await _remindersRepository.ListBySubscriptionIdAsync(request.SubscriptionId, cancellationToken);
    }
}
