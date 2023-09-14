using HR.Common.Models.enums;
using HR.DAL.Contractors;
using System.ComponentModel.DataAnnotations;

namespace HR.DAL.DataAccess.Entities
{
    public class Address : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        public AddressType Type { get; set; }

        [Required, StringLength(100)]
        public string AddressLine1 { get; set; }

        [StringLength(100)]
        public string? AddressLine2 { get; set; }

        [Required, StringLength(100)]
        public string Barangay { get; set; }

        [Required, StringLength(100)]
        public string City { get; set; }

        [Required, StringLength(100)]
        public string Province { get; set; }

        [Required, StringLength(100)]
        public string Country { get; set; }

        [Required, StringLength(10)]
        public string ZipCode { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required, StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [StringLength(100)]
        public string? ModifiedBy { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
