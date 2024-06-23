using AutoMapper;
using WC.Library.Domain.Models;
using WC.Service.Registration.gRPC.Client.Clients;
using WC.Service.Registration.gRPC.Client.Models.Employee;
using WC.Service.Registration.gRPC.Client.Models.Position;

namespace WC.Service.Registration.gRPC.Client;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EmployeeCreateModel, EmployeeCreateRequest>();
        CreateMap<EmployeeCreateResponse, CreateResultModel>();

        CreateMap<CheckPositionRequestModel, CheckPositionRequest>();
        CreateMap<CheckPositionResponse, CheckPositionResponseModel>();
    }
}