using HandsOn.Model.Dtos;
using System.Collections.Generic;

namespace HandsOn.Business.Services.Employee
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees();
        EmployeeDto GetEmployeeById(int employeeId);
    }
}
