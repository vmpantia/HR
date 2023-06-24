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
    public class DepartmentService : BaseService<DepartmentDTO>
    {
        public DepartmentService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public override IEnumerable<DepartmentDTO> GetAll()
        {
            var departments = _uow.DepartmentRepository.GetAll();
            return _mapper.Map<IEnumerable<DepartmentDTO>>(departments);
        }

        public override DepartmentDTO GetByID(Guid internalID)
        {
            var department = _uow.DepartmentRepository.GetByID(internalID);
            return _mapper.Map<DepartmentDTO>(department);
        }

        public override async Task SaveAsync(SaveRequest<DepartmentDTO> request)
        {
            if (request == null)
                throw new CustomException(Message.ERROR_REQUEST_NULL);

            var isAdd = request.inputData.InternalID == Guid.Empty;

            //Map DepartmentDTO to Department
            var department = _mapper.Map<Department>(request.inputData);

            if (isAdd) /* Create department information */
            {
                department.CreatedBy = Guid.NewGuid();
                department.CreatedDate = DateTime.Now;
                department.ModifiedBy = null;
                department.ModifiedDate = null;
                _uow.DepartmentRepository.Add(department);
            }
            else /* Edit department information */
            {
                department.ModifiedBy = Guid.NewGuid();
                department.ModifiedDate = DateTime.Now;
                _uow.DepartmentRepository.Update(department.InternalID, department);
            }

            await _uow.SaveChangesAsync();
        }

        public override async Task DeleteAsync(DeleteByIDRequest request)
        {
            if (request == null)
                throw new CustomException(Message.ERROR_REQUEST_NULL);

            //Delete department information
            _uow.DepartmentRepository.Delete(request.InternalIDToDelete);

            await _uow.SaveChangesAsync();
        }
    }
}
