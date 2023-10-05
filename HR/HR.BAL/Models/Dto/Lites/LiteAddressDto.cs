using HR.Common.Extensions;
using HR.DAL.DataAccess.Entities;

namespace HR.BAL.Models.Dto.Lites
{
    public class LiteAddressDto
    {
        public LiteAddressDto(Address address)
        {
            Id = address.Id;
            Type = address.Type.GetDescription();
            Address = $"{address.AddressLine1} {(string.IsNullOrEmpty(address.AddressLine2) ? "" : address.AddressLine2)} " +
                          $"{address.Barangay} {address.City} {address.Province}, {address.Country} ({address.ZipCode})";
            Status = address.Status.GetDescription();
        }

        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }
}
