using MediatR;
using SGE.Application.Common.Interfaces;
using SGE.Domain.Users.Events;

namespace SGE.Application.Subscriptions.Events;

public class SubscriptionCanceledEventHandler(IUsersRepository _usersRepository)
    : INotificationHandler<SubscriptionCanceledEvent>
{
    public async Task Handle(SubscriptionCanceledEvent notification, CancellationToken cancellationToken)
    {
        notification.User.DeleteAllReminders();

        await _usersRepository.RemoveAsync(notification.User, cancellationToken);
    }
}
