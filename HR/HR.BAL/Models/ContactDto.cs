using HR.Common.Models.enums;

namespace HR.BAL.Models
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public ContactType Type { get; set; }
        public bool IsPrimary { get; set; }
        public string Status { get; set; }
    }
}
