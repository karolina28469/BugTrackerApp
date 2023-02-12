using BugTracker.Application.Common.Interfaces.Authentication;
using BugTracker.Application.Common.Interfaces.Persistence;
using BugTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // check if user doesn't exists
            if (_userRepository.GetUserByEmail(email) is not null) 
            {
                throw new Exception("User with given email already exists");
            }

            // create user and generate unique id & persis to db
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

        public AuthenticationResult Login(string email, string password)
        {
            // check if user alredy exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email doesn't exist");
            }

            // validate if password is correct
            if(user.Password != password)
            {
                throw new Exception("Invalid password.");
            }

            // create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user, 
                token);
        }


    }
}
