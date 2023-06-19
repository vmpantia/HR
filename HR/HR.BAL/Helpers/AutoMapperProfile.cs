using AutoMapper;
using HR.BAL.Models;
using HR.DAL.DataAccess.Entities;

namespace HR.BAL.Mapper
{
    public class AutoMapperProfile : Profile
    {
        protected AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
