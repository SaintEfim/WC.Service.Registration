using AutoMapper;
using WC.Library.Domain.Models;
using WC.Service.Registration.gRPC.Client.Models;
using WC.Service.Registration.gRPC.GrpcClients;

namespace WC.Service.Registration.gRPC;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EmployeeCreateModel, EmployeeCreateRequest>();
        CreateMap<EmployeeCreateResponse, CreateResultModel>();
    }
}