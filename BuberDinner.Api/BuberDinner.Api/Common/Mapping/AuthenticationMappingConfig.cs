using BuberDinner.Application.Features.Authentication.Commands.Register;
using BuberDinner.Application.Features.Authentication.Common;
using BuberDinner.Application.Features.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
                
        }
    }
}
