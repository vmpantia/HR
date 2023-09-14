using HR.Common.Models.enums;

namespace HR.DAL.Contractors
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
