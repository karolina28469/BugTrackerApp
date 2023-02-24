using BugTracker.Application.Common.Interfaces.Authentication;
using BugTracker.Application.Common.Interfaces.Persistence;
using BugTracker.Domain.Common.Errors;
using BugTracker.Domain.Entities;
using ErrorOr;

namespace BugTracker.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            // check if user doesn't exists
            if (_userRepository.GetUserByEmail(email) is not null) 
            {
                return Errors.User.DuplicateEmail;
            }

            // create user and generate unique id & persist to db
            var user = new User 
            { 
                FirstName = firstName, 
                LastName = lastName, 
                Email= email, 
                Password = password 
            };  
            
            _userRepository.Add(user);

            // create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }

        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            // check if user alredy exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // validate if password is correct
            if(user.Password != password)
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
