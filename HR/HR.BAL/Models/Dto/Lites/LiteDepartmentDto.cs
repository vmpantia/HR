using HR.Common.Extensions;
using HR.DAL.DataAccess.Entities;

namespace HR.BAL.Models.Dto.Lites
{
    public class LiteDepartmentDto
    {
        public LiteDepartmentDto(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            Description = department.Description;
            Status = department.Status.GetDescription();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
    }
}
