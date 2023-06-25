using HR.DAL.Contractors;
using HR.DAL.DataAccess;
using HR.DAL.DataAccess.Entities;
using HR.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace HR.DAL.Test
{
    public class UnitOfWorkTest
    {
        private HRDbContext _db;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<HRDbContext>()
                            .UseInMemoryDatabase(databaseName: "TestDatabase")
                            .Options;
            _db = new HRDbContext(options);
        }

        [TearDown]
        public void Teardown()
        {
            _db.Dispose();
        }

        [Test]
        public void GetRepository_Employee_Valid_Test()
        {
            //Arrange
            IUnitOfWork uow = new UnitOfWork(_db);

            //Act
            var repo =  uow.GetRepository<Employee>();

            //Assert
            Assert.IsNotNull(repo);
        }

        [Test]
        public void GetRepository_Department_Valid_Test()
        {
            //Arrange
            IUnitOfWork uow = new UnitOfWork(_db);

            //Act
            var repo = uow.GetRepository<Department>();

            //Assert
            Assert.IsNotNull(repo);
        }

        [Test]
        public void GetRepository_Position_Valid_Test()
        {
            //Arrange
            IUnitOfWork uow = new UnitOfWork(_db);

            //Act
            var repo = uow.GetRepository<Position>();

            //Assert
            Assert.IsNotNull(repo);
        }

        [Test]
        public void GetRepository_Contact_Valid_Test()
        {
            //Arrange
            IUnitOfWork uow = new UnitOfWork(_db);

            //Act
            var repo = uow.GetRepository<Contact>();

            //Assert
            Assert.IsNotNull(repo);
        }

        [Test]
        public void GetRepository_Address_Valid_Test()
        {
            //Arrange
            IUnitOfWork uow = new UnitOfWork(_db);

            //Act
            var repo = uow.GetRepository<Contact>();

            //Assert
            Assert.IsNotNull(repo);
        }

        [Test]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Male", "Single", 0)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Male", "Married", 0)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Male", "Separated", 0)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Male", "Widowed", 0)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Male", "Divorced", 0)]

        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Female", "Single", 0)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Female", "Married", 0)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Female", "Separated", 0)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Female", "Widowed", 0)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Female", "Divorced", 0)]

        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Male", "Single", 1)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Male", "Married", 1)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Male", "Separated", 1)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Male", "Widowed", 1)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Male", "Divorced", 1)]

        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Female", "Single", 1)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Female", "Married", 1)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Female", "Separated", 1)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Female", "Widowed", 1)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Female", "Divorced", 1)]

        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Male", "Single", 2)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Male", "Married", 2)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Male", "Separated", 2)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Male", "Widowed", 2)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Male", "Divorced", 2)]

        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Female", "Single", 2)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Female", "Married", 2)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Female", "Separated", 2)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Female", "Widowed", 2)]
        [TestCase("000000000000000", "Test First Name", "Test Middle Name", "Test Last Name", "06/12/1999", "Female", "Divorced", 2)]

        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Male", "Single", 0)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Male", "Married", 0)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Male", "Separated", 0)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Male", "Widowed", 0)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Male", "Divorced", 0)]

        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Female", "Single", 0)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Female", "Married", 0)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Female", "Separated", 0)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Female", "Widowed", 0)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Female", "Divorced", 0)]

        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Male", "Single", 1)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Male", "Married", 1)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Male", "Separated", 1)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Male", "Widowed", 1)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Male", "Divorced", 1)]

        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Female", "Single", 1)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Female", "Married", 1)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Female", "Separated", 1)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Female", "Widowed", 1)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Female", "Divorced", 1)]

        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Male", "Single", 2)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Male", "Married", 2)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Male", "Separated", 2)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Male", "Widowed", 2)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Male", "Divorced", 2)]

        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Female", "Single", 2)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Female", "Married", 2)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Female", "Separated", 2)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Female", "Widowed", 2)]
        [TestCase("000000000000000", "Test First Name", null, "Test Last Name", "06/12/1999", "Female", "Divorced", 2)]
        public void SaveChangesAsync_Employee_Valid_Test(string ID, string FirstName, string? MiddleName, string LastName, string BirthDate, string Gender, string CivilStatus, int Status)
        {
            //Arrange
            IUnitOfWork uow = new UnitOfWork(_db);
            var employee = new Employee
            {
                InternalID = Guid.NewGuid(),
                ID = ID,
                Department_InternalID = Guid.NewGuid(),
                Position_InternalID = Guid.NewGuid(),
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                BirthDate = BirthDate,
                Gender = Gender,
                CivilStatus = CivilStatus,
                Status = Status,
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                ModifiedBy = Guid.NewGuid(),
                ModifiedDate = DateTime.Now
            };

            //Act
            uow.GetRepository<Employee>().Add(employee);
            uow.SaveChangesAsync();

            //Assert
            Assert.AreEqual(employee.InternalID, uow.GetRepository<Employee>().GetByID(employee.InternalID).InternalID);
            Assert.IsNotEmpty(uow.GetRepository<Employee>().GetByExpression(data => data.InternalID == employee.InternalID &&
                                                                                    data.ID == employee.ID));
        }

        [Test]
        [TestCase("000000000000000", "Test Name", "Test Description", 0)]
        [TestCase("000000000000000", "Test Name", "Test Description", 1)]
        [TestCase("000000000000000", "Test Name", "Test Description", 2)]

        [TestCase("000000000000000", "Test Name", null, 0)]
        [TestCase("000000000000000", "Test Name", null, 1)]
        [TestCase("000000000000000", "Test Name", null, 2)]

        public void SaveChangesAsync_Department_Valid_Test(string ID, string Name, string? Description, int Status)
        {
            //Arrange
            IUnitOfWork uow = new UnitOfWork(_db);
            var department = new Department
            {
                InternalID = Guid.NewGuid(),
                ID = ID,
                Name = Name,
                Description = Description,
                Status = Status,
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                ModifiedBy = Guid.NewGuid(),
                ModifiedDate = DateTime.Now
            };

            //Act
            uow.GetRepository<Department>().Add(department);
            uow.SaveChangesAsync();

            //Assert
            Assert.AreEqual(department.InternalID, uow.GetRepository<Department>().GetByID(department.InternalID).InternalID);
            Assert.IsNotEmpty(uow.GetRepository<Department>().GetByExpression(data => data.InternalID == department.InternalID &&
                                                                                      data.ID == department.ID &&
                                                                                      data.Name == department.Name));
        }

        [Test]
        [TestCase("000000000000000", "Test Name", null, 0)]
        [TestCase("000000000000000", "Test Name", null, 1)]
        [TestCase("000000000000000", "Test Name", null, 2)]

        public void SaveChangesAsync_Position_Valid_Test(string ID, string Name, string? Description, int Status)
        {
            //Arrange
            IUnitOfWork uow = new UnitOfWork(_db);
            var position = new Position
            {
                InternalID = Guid.NewGuid(),
                ID = ID,
                Department_InternalID = Guid.NewGuid(),
                Name = Name,
                Description = Description,
                Status = Status,
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                ModifiedBy = Guid.NewGuid(),
                ModifiedDate = DateTime.Now
            };

            //Act
            uow.GetRepository<Position>().Add(position);
            uow.SaveChangesAsync();

            //Assert
            Assert.AreEqual(position.InternalID, uow.GetRepository<Position>().GetByID(position.InternalID).InternalID);
            Assert.IsNotEmpty(uow.GetRepository<Position>().GetByExpression(data => data.InternalID == position.InternalID &&
                                                                                      data.ID == position.ID &&
                                                                                      data.Name == position.Name));
        }
    }
}