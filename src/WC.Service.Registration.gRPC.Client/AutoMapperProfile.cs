using AutoMapper;
using WC.Library.Domain.Models;
using WC.Service.Registration.gRPC.Client.Models;
using WC.Service.Registration.gRPC.GrpcClients;
using WC.Service.Registration.gRPC.GrpcClients.Employee;
using WC.Service.Registration.gRPC.GrpcClients.Position;

namespace WC.Service.Registration.gRPC;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EmployeeCreateModel, EmployeeCreateRequest>();
        CreateMap<EmployeeCreateResponse, CreateResultModel>();

        CreateMap<PositionRequestModel, CheckPositionRequest>();
        CreateMap<CheckPositionResponseModel, CheckPositionResponse>();
    }
}