using AutoMapper;
using HR.BAL.Models;
using HR.Common.Utilities;
using HR.DAL.DataAccess.Entities;

namespace HR.BAL.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dst => dst.StatusDescription,
                           opt => opt.MapFrom(org => Parser.ParseStatus(org.Status)))
                .ReverseMap();
            CreateMap<Department, DepartmentDTO>()
                .ForMember(dst => dst.StatusDescription,
                           opt => opt.MapFrom(org => Parser.ParseStatus(org.Status)))
                .ReverseMap();
            CreateMap<Position, PositionDTO>()
                .ForMember(dst => dst.StatusDescription,
                           opt => opt.MapFrom(org => Parser.ParseStatus(org.Status)))
                .ReverseMap();
            CreateMap<Contact, ContactDTO>()
                .ForMember(dst => dst.TypeDescription,
                           opt => opt.MapFrom(org => Parser.ParseContactType(org.Type)))
                .ReverseMap();
        }
    }
}
