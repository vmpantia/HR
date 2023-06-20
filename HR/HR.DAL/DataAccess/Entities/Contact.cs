using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HR.DAL.DataAccess.Entities
{
    [PrimaryKey(nameof(Relation_InternalID), nameof(Value))]
    public class Contact
    {
        public Guid Relation_InternalID { get; set; }

        [StringLength(50)]
        public string Value { get; set; }

        [Range(1, 3)]
        public int Type { get; set; } /* [1] - Mobile Number [2] - Email Address [3] - Telephone Number  */

        public bool IsPrimary { get; set; }
    }
}
