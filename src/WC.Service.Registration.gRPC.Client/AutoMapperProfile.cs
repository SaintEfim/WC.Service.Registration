using AutoMapper;
using WC.Library.Domain.Models;
using WC.Service.Registration.gRPC.GrpcClients;
using WC.Service.Registration.gRPC.Models;

namespace WC.Service.Registration.gRPC;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EmployeeCreateModel, EmployeeCreateRequest>();
        CreateMap<EmployeeCreateResponse, CreateResultModel>();
    }
}