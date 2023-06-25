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
    public class EmployeeService : BaseService<Employee, EmployeeDTO>
    {
        public EmployeeService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public override IEnumerable<EmployeeDTO> GetAll()
        {
            var result = base.GetAll();
            return result.Select(data => PopulateOtherInfo(data)); ;
        }

        public async Task SaveAsync(SaveRequest<EmployeeDTO> request)
        {
            //Save Employee Information 
            await base.SaveAsync(request, false);

            //Save Other Informations
            SaveContacts(request.inputData.Contacts, request.inputData.InternalID);
            SaveAddresses(request.inputData.Addresses, request.inputData.InternalID);

            //Commit Changes
            await _uow.SaveChangesAsync();
        }

        private void SaveContacts(IEnumerable<ContactDTO>? contacts, Guid internalID)
        {
            if (contacts == null)
                return;

            //Delete old contacts
            _uow.GetRepository<Contact>()
                .DeleteByExpression(data => data.Relation_InternalID == internalID);

            //Add new contacts
            foreach (var contact in contacts)
            {
                var entity = _mapper.Map<Contact>(contact);
                entity.Relation_InternalID = internalID;
                _uow.GetRepository<Contact>().Add(entity);
            }
        }

        private void SaveAddresses(IEnumerable<AddressDTO>? addresses, Guid internalID)
        {
            if (addresses == null)
                return;

            //Delete old addresses
            _uow.GetRepository<Address>()
                .DeleteByExpression(data => data.Relation_InternalID == internalID);

            //Add new addresses
            foreach (var address in addresses)
            {
                var entity = _mapper.Map<Address>(address);
                entity.Relation_InternalID = internalID;
                _uow.GetRepository<Address>().Add(entity);
            }
        }

        private EmployeeDTO PopulateOtherInfo(EmployeeDTO data)
        {
            //Get Department
            var dep = _uow.GetRepository<Department>().GetByExpression(dep => dep.InternalID == data.Department_InternalID).FirstOrDefault();
            data.DepartmentName = dep != null && dep.Status == Status.STATUS_ENABLED_INT ? dep.Name : "-"; /* Set DepartmentName */

            //Get Position
            var pos = _uow.GetRepository<Position>().GetByExpression(pos => pos.InternalID == data.Position_InternalID).FirstOrDefault();
            data.PositionName = pos != null && pos.Status == Status.STATUS_ENABLED_INT ? pos.Name : "-"; /* Set PositionName */

            //Get Contacts
            var contacts = _uow.GetRepository<Contact>().GetByExpression(con => con.Relation_InternalID == data.InternalID);
            data.Contacts = _mapper.Map<IEnumerable<ContactDTO>>(contacts);

            //Get Addresses
            var addresses = _uow.GetRepository<Address>().GetByExpression(con => con.Relation_InternalID == data.InternalID);
            data.Addresses = _mapper.Map<IEnumerable<AddressDTO>>(addresses);

            return data;
        }
    }
}
