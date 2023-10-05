using AutoMapper;
using HR.BAL.Models.Dto;
using HR.BAL.Models.Dto.Lites;
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
                .ForMember(dto => dto.Addresses, opt => opt.MapFrom(src => src.Addresses.Select(data => new LiteAddressDto(data))))
                .ForMember(dto => dto.Contacts, opt => opt.MapFrom(src => src.Contacts.Select(data => new LiteContactDto(data))))
                .ForMember(dto => dto.Department, opt => opt.MapFrom(src => new LiteDepartmentDto(src.Department)))
                .ForMember(dto => dto.Position, opt => opt.MapFrom(src => new LitePositionDto(src.Position)));
        }
    }
}
