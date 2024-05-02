using AutoMapper;
using WC.Service.Registration.Data.Models;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RegistrationRequestModel, UserRegistrationEntity>();
        CreateMap<UserRegistrationModel, UserRegistrationEntity>().ReverseMap();
    }
}