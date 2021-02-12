using AutoMapper;
using HandsOn.Business.Mappings.Mappers;
using HandsOn.Business.Services.Employee;
using HandsOn.Data.Entities;
using HandsOn.Data.Repositories.Employee;
using HandsOn.Model.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HandsOn.Business.Test.ServiceTests
{
    [TestClass]
    public class EmployeeServiceTest
    {
        private Mock<IMapper> _mapperMock;
        private EmployeeMapper _employeeMapper;
        private Mock<EmployeeService> _employeeServiceMock;
        private Mock<IEmployeeRepository> _employeeRepositoryMock;

        [TestInitialize]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _employeeMapper = new EmployeeMapper(_mapperMock.Object);
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
        }

        [TestMethod]
        public void GetEmployeeById_IsNotNull()
        {
            _employeeRepositoryMock.Setup(p => p.GetEmployeeById(1)).Returns(CreateEmployeeEntityForTest());
            _employeeServiceMock = new Mock<EmployeeService>(_employeeRepositoryMock.Object, _employeeMapper);

            EmployeeDto employeeResult = _employeeServiceMock.Object.GetEmployeeById(1);
            Assert.IsNotNull(employeeResult);
        }

        private Employee CreateEmployeeEntityForTest()
        {
            return new Employee()
            {
                Id = 1,
                Name = "Nicolas",
                ContractTypeName = "HourlySalaryEmployee",
                RoleId = 1,
                RoleName = "Administrator",
                RoleDescription = null,
                HourlySalary = 15000,
                MonthlySalary = 45000
            };
        }
    }
}
