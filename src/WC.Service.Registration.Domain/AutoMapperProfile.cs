using AutoMapper;
using WC.Service.Registration.Domain.Models;
using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.Domain;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EmployeeRegistrationModel, EmployeeCreateModel>().ReverseMap();
        CreateMap<CreateResultModel, EmployeeRegistrationModel>();
    }
}