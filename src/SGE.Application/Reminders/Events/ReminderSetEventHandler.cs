using MediatR;
using SGE.Application.Common.Interfaces;
using SGE.Domain.Users.Events;

namespace SGE.Application.Reminders.Events;

public class ReminderSetEventHandler(IRemindersRepository _remindersRepository) : INotificationHandler<ReminderSetEvent>
{
    public async Task Handle(ReminderSetEvent @event, CancellationToken cancellationToken)
    {
        await _remindersRepository.AddAsync(@event.Reminder, cancellationToken);
    }
}
