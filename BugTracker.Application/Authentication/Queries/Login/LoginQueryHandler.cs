using BugTracker.Application.Authentication.Common;
using BugTracker.Application.Common.Interfaces.Authentication;
using BugTracker.Application.Common.Interfaces.Persistence;
using BugTracker.Domain.Common.Errors;
using BugTracker.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BugTracker.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;


        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // check if user alredy exists
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // validate if password is correct
            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
