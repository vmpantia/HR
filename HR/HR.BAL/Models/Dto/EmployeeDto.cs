using HR.BAL.Models.Dto.Lites;

namespace HR.BAL.Models.Dto
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

        public IEnumerable<LiteAddressDto> Addresses { get; set; }
        public IEnumerable<LiteContactDto> Contacts { get; set; }

        public LiteDepartmentDto Department { get; set; }
        public LitePositionDto Position { get; set; }
    }
}
