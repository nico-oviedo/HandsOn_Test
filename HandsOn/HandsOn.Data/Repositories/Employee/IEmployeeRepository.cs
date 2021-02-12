using System.Collections.Generic;

namespace HandsOn.Data.Repositories.Employee
{
    public interface IEmployeeRepository
    {
        IEnumerable<Entities.Employee> GetEmployees();
        Entities.Employee GetEmployeeById(int employeeId);
    }
}
