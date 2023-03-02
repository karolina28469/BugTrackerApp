using BugTracker.Application.Authentication.Commands.Register;
using BugTracker.Application.Authentication.Common;
using BugTracker.Application.Authentication.Queries.Login;
using BugTracker.Contracts.Authentication;
using Mapster;

namespace BugTracker.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);
        }
    }
}
