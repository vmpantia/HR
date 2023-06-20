using System.ComponentModel.DataAnnotations;

namespace HR.BAL.Models
{
    public class PositionDTO
    {
        [Key]
        public Guid InternalID { get; set; }

        //Relational IDs
        public Guid Department_InternalID { get; set; }

        [Required, StringLength(15)]
        public string ID { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }

        [Range(0, 2)]
        public int Status { get; set; } /* [0] - Enabled [1] - Disabled [2] - For Deletion  */
        public string? StatusDescription { get; set; }

        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
