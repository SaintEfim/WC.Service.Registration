using System.Globalization;
using AutoMapper;
using WC.Service.Registration.gRPC.Models;
using WC.Service.Registration.gRPC.Services;

namespace WC.Service.Registration.gRPC;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EmployeeServiceClientModel, Employee>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(src => src.CreatedAt.ToString(CultureInfo.InvariantCulture)));

        CreateMap<Employee, EmployeeServiceClientModel>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => Guid.Parse(src.Id)))
            .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(src => DateTime.ParseExact(src.CreatedAt, "yyyy-MM-ddTHH:mm:ssZ",
                    CultureInfo.InvariantCulture)));
    }
}