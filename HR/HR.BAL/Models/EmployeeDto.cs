using HR.DAL.DataAccess.Entities;

namespace HR.BAL.Models
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string CivilStatus { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

        public IEnumerable<AddressDto> Addresses { get; set; }
        public IEnumerable<ContactDto> Contacts { get; set; }

        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public string PositionId { get; set; }
        public string PositionName { get; set; }
    }
}
