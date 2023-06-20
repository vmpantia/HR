using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HR.BAL.Models
{
    public class EmployeeDTO
    {
        [Key]
        public Guid InternalID { get; set; }

        //Relational IDs
        public Guid Department_InternalID { get; set; }
        public string? DepartmentName { get; set; }
        public Guid Position_InternalID { get; set; }
        public string? PositionName { get; set; }

        [Required, StringLength(15)]
        public string ID { get; set; }

        [DisplayName("First Name"), Required, StringLength(40)]
        public string FirstName { get; set; }

        [DisplayName("Middle Name"), StringLength(40)]
        public string? MiddleName { get; set; }

        [DisplayName("Last Name"), Required, StringLength(40)]
        public string LastName { get; set; }

        [DisplayName("Birth Date"), Required, StringLength(10)]
        public string BirthDate { get; set; }

        [Required, StringLength(6)]
        public string Gender { get; set; }

        [DisplayName("Civil Status"), Required, StringLength(15)]
        public string CivilStatus { get; set; }

        [Range(0, 2)]
        public int Status { get; set; } /* [0] - Enabled [1] - Disabled [2] - For Deletion  */
        public string? StatusDescription { get; set; } 

        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
