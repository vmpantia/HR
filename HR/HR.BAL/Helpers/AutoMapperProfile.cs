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
               .ForMember(dest => dest.StatusDescription, 
                          opts => opts.MapFrom(org => Parser.ParseStatus(org.Status)))
               .ReverseMap();
        }
    }
}
