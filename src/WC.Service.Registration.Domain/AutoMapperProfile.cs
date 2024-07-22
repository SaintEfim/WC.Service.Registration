using AutoMapper;
using WC.Service.Employees.gRPC.Client.Models.Employee;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EmployeeRegistrationModel, EmployeeCreateRequestModel>();
    }
}
