using HR.Common.Constants;
using HR.Common.Utilities;
using System.ComponentModel.DataAnnotations;

namespace HR.BAL.Models
{
    public class ContactDTO
    {
        [Required, StringLength(50)]
        public string Value { get; set; }

        [Range(1, 3)]
        public int Type { get; set; } /* [1] - Mobile Number [2] - Email Address [3] - Telephone Number  */
        public string TypeDescription { get { return Parser.ParseContactType(Type); } }

        public bool IsPrimary { get; set; }
    }
}
