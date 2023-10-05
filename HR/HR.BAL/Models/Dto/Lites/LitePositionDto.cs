using HR.Common.Extensions;
using HR.DAL.DataAccess.Entities;

namespace HR.BAL.Models.Dto.Lites
{
    public class LitePositionDto
    {
        public LitePositionDto(Position position)
        {
            Id = position.Id;
            Name = position.Name;
            Description = position.Description;
            Status = position.Status.GetDescription();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
    }
}
