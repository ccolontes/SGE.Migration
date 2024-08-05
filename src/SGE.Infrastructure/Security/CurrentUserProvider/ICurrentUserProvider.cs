namespace SGE.Infrastructure.Security.CurrentUserProvider;

public interface ICurrentUserProvider
{
    CurrentUser GetCurrentUser();
}