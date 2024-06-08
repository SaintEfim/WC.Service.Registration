using AutoMapper;
using WC.Service.Registration.gRPC.GrpcClients;
using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.gRPC;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Employee, EmployeeRegistrationClientModel>();

        CreateMap<EmployeeRegistrationClientModel, Employee>();

        CreateMap<EmployeeListResponse, List<EmployeeRegistrationClientModel>>()
            .ConvertUsing((src, _, context) =>
                context.Mapper.Map<List<EmployeeRegistrationClientModel>>(src.Employees));

        CreateMap<CreateResult, CreateResultModel>();
    }
}