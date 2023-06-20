using AutoMapper;
using HR.BAL.Contractors;
using HR.BAL.Models;
using HR.BAL.Models.Request;
using HR.Common.Constants;
using HR.DAL.Contractors;
using HR.DAL.DataAccess.Entities;
using HR.DAL.Exceptions;

namespace HR.BAL.Services
{
    public class PositionService : IPositionService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public PositionService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public IEnumerable<PositionDTO> GetPositions()
        {
            var positions = _uow.PositionRepository.GetAll();
            return _mapper.Map<IEnumerable<PositionDTO>>(positions).Select(data => PopulateOtherInfo(data));
        }

        public PositionDTO GetPositionByID(Guid internalID)
        {
            var position = _uow.PositionRepository.GetByID(internalID);
            return PopulateOtherInfo(_mapper.Map<PositionDTO>(position));
        }

        public async Task SavePositionAsync(SavePositionRequest request)
        {
            if (request == null)
                throw new CustomException(Message.ERROR_REQUEST_NULL);

            var isAdd = request.inputPosition.InternalID == Guid.Empty;

            //Map PositionDTO to Position
            var position = _mapper.Map<Position>(request.inputPosition);

            if (isAdd) /* Create position information */
            {
                position.CreatedBy = Guid.NewGuid();
                position.CreatedDate = DateTime.Now;
                position.ModifiedBy = null;
                position.ModifiedDate = null;
                _uow.PositionRepository.Add(position);
            }
            else /* Edit position information */
            {
                position.ModifiedBy = Guid.NewGuid();
                position.ModifiedDate = DateTime.Now;
                _uow.PositionRepository.Update(position.InternalID, position);
            }

            await _uow.SaveChangesAsync();
        }

        public async Task DeletePositionAsync(DeleteByIDRequest request)
        {
            if (request == null)
                throw new CustomException(Message.ERROR_REQUEST_NULL);

            //Delete position information
            _uow.PositionRepository.Delete(request.InternalIDToDelete);

            await _uow.SaveChangesAsync();
        }

        private PositionDTO PopulateOtherInfo(PositionDTO data)
        {
            //Get Department
            var dep = _uow.DepartmentRepository.GetByExpression(dep => dep.InternalID == data.Department_InternalID).FirstOrDefault();
            data.DepartmentName = dep != null && dep.Status == Status.STATUS_ENABLED_INT ? dep.Name : "-"; /* Set DepartmentName */

            return data;
        }
    }
}
