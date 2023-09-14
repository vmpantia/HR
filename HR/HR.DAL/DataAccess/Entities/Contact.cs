using HR.Common.Models.enums;
using HR.DAL.Contractors;
using System.ComponentModel.DataAnnotations;

namespace HR.DAL.DataAccess.Entities
{
    public class Contact : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(50)]
        public string Value { get; set; }

        [Range(1, 3)]
        public ContactType Type { get; set; }

        [Required]
        public bool IsPrimary { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required, StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [StringLength(100)]
        public string? ModifiedBy { get; set; }
    }
}
