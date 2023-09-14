using HR.Common.Models.enums;

namespace HR.BAL.Models
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public AddressType Type { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Status { get; set; }
    }
}
