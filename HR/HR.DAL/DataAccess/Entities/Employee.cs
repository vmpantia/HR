using System.ComponentModel.DataAnnotations;

namespace HR.DAL.DataAccess.Entities
{
    public class Employee
    {
        [Key]
        public Guid InternalID { get; set; }

        [StringLength(15)]
        public string EmployeeID { get; set; }

        [StringLength(40)]
        public string FirstName { get; set; }

        [StringLength(40)]
        public string? MiddleName { get; set; }

        [StringLength(40)]
        public string LastName { get; set; }

        [DataType(DataType.Date)] 
        public DateTime BirthDate { get; set; }

        [StringLength(6)]
        public string Gender { get; set; }

        [StringLength(15)]
        public string CivilStatus { get; set; }

        [Range(-1, 2)]
        public int Status { get; set; } /* [-1] - Invalid [0] - Enabled [1] - Disabled [2] - For Deletion  */

        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
