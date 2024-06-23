using AutoMapper;
using WC.Library.Domain.Models;
using WC.Service.Registration.gRPC.Client.Models;
using WC.Service.Registration.gRPC.Clients.Employees;
using WC.Service.Registration.gRPC.Clients.Positions;

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