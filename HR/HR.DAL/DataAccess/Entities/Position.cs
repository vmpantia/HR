using System.ComponentModel.DataAnnotations;

namespace HR.DAL.DataAccess.Entities
{
    public class Position
    {
        [Key]
        public Guid InternalID { get; set; }

        //Relational IDs
        public Guid Department_InternalID { get; set;  }

        [StringLength(15)]
        public string ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }

        [Range(0, 2)]
        public int Status { get; set; } /* [0] - Enabled [1] - Disabled [2] - For Deletion  */

        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
