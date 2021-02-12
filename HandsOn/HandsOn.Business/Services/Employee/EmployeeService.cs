using HandsOn.Business.Mappings.Mappers;
using HandsOn.Data.Repositories.Employee;
using HandsOn.Model.Dtos;
using System.Collections.Generic;
using Entities = HandsOn.Data.Entities;

namespace HandsOn.Business.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeMapper _employeeMapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, EmployeeMapper employeeMapper)
        {
            _employeeMapper = employeeMapper;
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            IEnumerable<Entities.Employee> employees = _employeeRepository.GetEmployees();
            return _employeeMapper.Map(employees);
        }

        public EmployeeDto GetEmployeeById(int employeeId)
        {
            Entities.Employee employee = _employeeRepository.GetEmployeeById(employeeId);
            return _employeeMapper.Map(employee);
        }
    }
}
