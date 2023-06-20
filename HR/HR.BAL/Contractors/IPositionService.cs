using HR.BAL.Models;
using HR.BAL.Models.Request;

namespace HR.BAL.Contractors
{
    public interface IPositionService
    {
        Task DeletePositionAsync(DeleteByIDRequest request);
        PositionDTO GetPositionByID(Guid internalID);
        IEnumerable<PositionDTO> GetPositions();
        Task SavePositionAsync(SavePositionRequest request);
    }
}