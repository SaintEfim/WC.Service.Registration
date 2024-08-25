using AutoMapper;
using WC.Service.Authentication.gRPC.Client.Models;
using WC.Service.Registration.API.Models;
using WC.Service.Registration.API.Models.Authentication;
using WC.Service.Registration.Domain.Services;

namespace WC.Service.Registration.API;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RegistrationCreateDto, RegistrationCreatePayloadModel>();

        CreateMap<AuthenticationLoginResponseModel, AuthenticationLoginResponseDto>();
    }
}
