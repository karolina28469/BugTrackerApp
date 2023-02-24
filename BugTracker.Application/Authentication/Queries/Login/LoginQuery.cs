using BugTracker.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BugTracker.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
