using ErrorOr;
using MediatR;
using SGE.Application.Common.Interfaces;
using SGE.Application.Subscriptions.Common;
using SGE.Domain.Users;

namespace SGE.Application.Subscriptions.Queries.GetSubscription;

public class GetSubscriptionQueryHandler(IUsersRepository _usersRepository)
    : IRequestHandler<GetSubscriptionQuery, ErrorOr<SubscriptionResult>>
{
    public async Task<ErrorOr<SubscriptionResult>> Handle(GetSubscriptionQuery request, CancellationToken cancellationToken)
    {
        return await _usersRepository.GetByIdAsync(request.UserId, cancellationToken) is User user
            ? SubscriptionResult.FromUser(user)
            : Error.NotFound(description: "Subscription not found.");
    }
}
