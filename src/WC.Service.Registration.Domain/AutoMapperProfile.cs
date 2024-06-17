using AutoMapper;
using WC.Service.Registration.Domain.Models;
using WC.Service.Registration.gRPC.Client.Models;

namespace WC.Service.Registration.Domain;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EmployeeRegistrationModel, EmployeeCreateModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
    }
}