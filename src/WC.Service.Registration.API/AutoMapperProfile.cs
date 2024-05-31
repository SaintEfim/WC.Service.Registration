using AutoMapper;
using WC.Service.Registration.API.Models;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.API;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EmployeeRegistrationModel, EmployeeRegistrationDto>();

        CreateMap<RegistrationRequestDto, RegistrationRequestModel>();
    }
}