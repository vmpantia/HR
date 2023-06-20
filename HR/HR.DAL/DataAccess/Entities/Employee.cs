using System.ComponentModel.DataAnnotations;

namespace HR.DAL.DataAccess.Entities
{
    public class Employee
    {
        [Key]
        public Guid InternalID { get; set; }

        //Relational IDs
        public Guid Department_InternalID { get; set; }
        public Guid Position_InternalID { get; set; }

        [StringLength(15)]
        public string ID { get; set; }

        [StringLength(40)]
        public string FirstName { get; set; }

        [StringLength(40)]
        public string? MiddleName { get; set; }

        [StringLength(40)]
        public string LastName { get; set; }

        [StringLength(10), DataType(DataType.Date)] 
        public string BirthDate { get; set; }

        [StringLength(6)]
        public string Gender { get; set; }

        [StringLength(15)]
        public string CivilStatus { get; set; }

        [Range(0, 2)]
        public int Status { get; set; } /* [0] - Enabled [1] - Disabled [2] - For Deletion  */

        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
