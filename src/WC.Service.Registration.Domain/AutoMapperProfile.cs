using AutoMapper;
using WC.Service.Registration.Data.Models;
using WC.Service.Registration.Domain.Models;
using WC.Service.Registration.Domain.Models.Requests;

namespace WC.Service.Registration.Domain;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RegistrationRequestModel, UserRegistrationEntity>()
            .ForMember(dest => dest.Role,
                opt => { opt.MapFrom(src => string.IsNullOrEmpty(src.Role) ? "user" : src.Role); });
        CreateMap<UserRegistrationModel, UserRegistrationEntity>().ReverseMap();
    }
}