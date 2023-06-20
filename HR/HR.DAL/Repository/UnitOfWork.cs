﻿using HR.Common.Constants;
using HR.DAL.Contractors;
using HR.DAL.DataAccess;
using HR.DAL.DataAccess.Entities;
using HR.DAL.Exceptions;

namespace HR.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRDbContext _db;
        private IBaseRepository<Employee> _empRep;
        private IBaseRepository<Department> _depRep;
        private IBaseRepository<Position> _posRep;
        public UnitOfWork(HRDbContext context) => _db = context;

        public IBaseRepository<Employee> EmployeeRepository
        {
            get
            {
                if (_empRep == null)
                    _empRep = new BaseRepository<Employee>(_db);

                return _empRep;
            }
        }

        public IBaseRepository<Department> DepartmentRepository
        {
            get
            {
                if (_depRep == null)
                    _depRep = new BaseRepository<Department>(_db);

                return _depRep;
            }
        }

        public IBaseRepository<Position> PositionRepository
        {
            get
            {
                if (_posRep == null)
                    _posRep = new BaseRepository<Position>(_db);

                return _posRep;
            }
        }

        public async Task SaveChangesAsync()
        {
            var result = await _db.SaveChangesAsync();
            if (result <= 0)
                throw new CustomException(Message.ERROR_SAVING);
        }
    }
}
