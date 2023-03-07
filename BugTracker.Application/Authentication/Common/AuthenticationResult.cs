using BugTracker.Domain.UserAggregate;

namespace BugTracker.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
