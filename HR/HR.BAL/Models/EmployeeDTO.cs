using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HR.BAL.Models
{
    public class EmployeeDTO
    {
        [Key]
        public Guid InternalID { get; set; }

        [DisplayName("Employee ID"), StringLength(15)]
        public string EmployeeID { get; set; }

        [DisplayName("First Name"), StringLength(40)]
        public string FirstName { get; set; }

        [DisplayName("Middle Name"), StringLength(40)]
        public string? MiddleName { get; set; }

        [DisplayName("Last Name"), StringLength(40)]
        public string LastName { get; set; }

        [DisplayName("Birth Date"), DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [StringLength(6)]
        public string Gender { get; set; }

        [DisplayName("Civil Status"), StringLength(15)]
        public string CivilStatus { get; set; }

        [Range(-1, 2)]
        public int Status { get; set; } /* [-1] - Invalid [0] - Enabled [1] - Disabled [2] - For Deletion  */
        public string? StatusDescription { get; set; } /* [-1] - Invalid [0] - Enabled [1] - Disabled [2] - For Deletion  */

        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
