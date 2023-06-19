using AutoMapper;
using HR.BAL.Models;
using HR.DAL.DataAccess.Entities;

namespace HR.BAL.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
               .ForMember(dest => dest.StatusDescription, 
                          opts => opts.MapFrom(org => org.Status == 1 ? "Tanga" : "Bobo"))
               .ReverseMap();
        }
    }
}
