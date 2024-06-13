using AutoMapper;
using WC.Library.Web.Models;
using WC.Service.Registration.API.Models;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.API;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EmployeeRegistrationCreateDto, EmployeeRegistrationModel>();
        CreateMap<EmployeeRegistrationModel, CreateActionResultDto>();
    }
}