using HR.Common.Models.enums;
using HR.DAL.Contractors;
using System.ComponentModel.DataAnnotations;

namespace HR.DAL.DataAccess.Entities
{
    public class Employee : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }

        [Required]
        public Guid PositionId { get; set; }

        [Required, StringLength(40)]
        public string FirstName { get; set; }

        [StringLength(40)]
        public string? MiddleName { get; set; }

        [Required, StringLength(40)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required, StringLength(6)]
        public string Gender { get; set; }

        [Required, StringLength(15)]
        public string CivilStatus { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required, StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [StringLength(100)]
        public string? ModifiedBy { get; set; }

        public virtual IEnumerable<Contact> Contacts { get; set; }
        public virtual IEnumerable<Address> Addresses { get; set; }
        public virtual Department Department { get; set; }
        public virtual Position Position { get; set; }
    }
}
