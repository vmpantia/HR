using HR.Common.Utilities;
using System.ComponentModel.DataAnnotations;

namespace HR.BAL.Models
{
    public class AddressDTO
    {
        [Range(1, 3)]
        public int Type { get; set; } /* [1] - Permanent Address [2] - Present Address [3] - Provincial Address  */
        public string TypeDescription { get { return Parser.ParseAddressType(Type); } }

        [Required, StringLength(50)]
        public string AddressLine1 { get; set; }

        [StringLength(50)]
        public string? AddressLine2 { get; set; }

        [Required, StringLength(50)]
        public string Barangay { get; set; }

        [Required, StringLength(50)]
        public string City { get; set; }

        [Required, StringLength(50)]
        public string Province { get; set; }

        [Required, StringLength(50)]
        public string Country { get; set; }

        [Required, StringLength(10)]
        public string ZipCode { get; set; }

        public string FullAddress {  get { return AddressLine1 + " " + AddressLine2 + " " + Barangay; }  }
    }
}
