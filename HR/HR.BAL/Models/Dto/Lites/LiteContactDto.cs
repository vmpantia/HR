using HR.Common.Extensions;
using HR.DAL.DataAccess.Entities;

namespace HR.BAL.Models.Dto.Lites
{
    public class LiteContactDto
    {
        public LiteContactDto(Contact contact)
        {
            Id = contact.Id;
            Type = contact.Type.GetDescription();
            Value = contact.Value;
            IsPrimary = contact.IsPrimary;
            Status = contact.Status.GetDescription();
        }

        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsPrimary { get; set; }
        public string Status { get; set; }
    }
}
