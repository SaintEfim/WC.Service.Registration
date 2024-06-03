using System.Globalization;
using AutoMapper;
using WC.Service.Registration.gRPC.Models;
using WC.Service.Registration.gRPC.Services;

namespace WC.Service.Registration.gRPC;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Employee, EmployeeServiceClientModel>()
            .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(src =>
                    string.IsNullOrEmpty(src.CreatedAt)
                        ? DateTime.MinValue
                        : DateTime.ParseExact(src.CreatedAt, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture)));

        CreateMap<EmployeeServiceClientModel, Employee>()
            .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(src =>
                    src.CreatedAt == DateTime.MinValue ? string.Empty : src.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss")));

        CreateMap<EmployeeListResponse, List<EmployeeServiceClientModel>>()
            .ConvertUsing((src, _, context) =>
                context.Mapper.Map<List<EmployeeServiceClientModel>>(src.Employees));
    }
}