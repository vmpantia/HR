﻿using HR.Common.Utilities;
using System.ComponentModel.DataAnnotations;

namespace HR.BAL.Models
{
    public class DepartmentDTO
    {
        [Key]
        public Guid InternalID { get; set; }

        [Required, StringLength(15)]
        public string ID { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }

        [Range(0, 2)]
        public int Status { get; set; } /* [0] - Enabled [1] - Disabled [2] - For Deletion  */
        public string StatusDescription { get { return Parser.ParseStatus(Status); } }

        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
