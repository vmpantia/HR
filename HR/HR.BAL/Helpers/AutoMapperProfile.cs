using AutoMapper;
using HR.BAL.Models;
using HR.Common.Extensions;
using HR.DAL.DataAccess.Entities;

namespace HR.BAL.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dto => dto.Status, opt => opt.MapFrom(src => src.Status.GetDescription()))
                .ForMember(dto => dto.DepartmentName, opt => opt.MapFrom(src => src.Department.Name ?? "N/A"))
                .ForMember(dto => dto.PositionName, opt => opt.MapFrom(src => src.Position.Name ?? "N/A"));
            CreateMap<Contact, ContactDto>()
                .ForMember(dto => dto.Status, opt => opt.MapFrom(src => src.Status.GetDescription()));
            CreateMap<Address, AddressDto>()
                .ForMember(dto => dto.Status, opt => opt.MapFrom(src => src.Status.GetDescription()));
        }
    }
}
