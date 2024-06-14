using AutoMapper;
using WC.Service.Registration.gRPC.GrpcClients;
using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.gRPC;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EmployeeCreate, EmployeeCreateModel>();

        CreateMap<EmployeeCreateModel, EmployeeCreate>();

        // CreateMap<EmployeeListResponse, List<EmployeeCreateModel>>()
        //     .ConvertUsing((src, _, context) =>
        //         context.Mapper.Map<List<EmployeeCreateModel>>(src.Employees));

        CreateMap<CreateResult, CreateResultModel>();
    }
}