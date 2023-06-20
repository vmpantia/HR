using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HR.DAL.DataAccess.Entities
{
    [PrimaryKey(nameof(Relation_InternalID), nameof(Type))]
    public class Address
    {
        public Guid Relation_InternalID { get; set; }

        [Range(1, 3)]
        public int Type { get; set; } /* [1] - Permanent Address [2] - Present Address [3] - Provincial Address  */

        [StringLength(50)]
        public string AddressLine1 { get; set; }

        [StringLength(50)]
        public string? AddressLine2 { get; set; }

        [StringLength(50)]
        public string Barangay { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Province { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }
    }
}
