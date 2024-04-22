using AutoMapper;
using WC.Service.Registration.API.Models;
using WC.Service.Registration.Domain.Models;
using WC.Service.Registration.Domain.Models.Requests;

namespace WC.Service.Registration.API;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserRegistrationModel, UserRegistrationDto>();

        CreateMap<RegistrationRequestDto, RegistrationRequestModel>();
    }
}