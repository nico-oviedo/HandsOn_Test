using System.Collections.Generic;
using System.Linq;

namespace HandsOn.Data.Repositories.Employee
{
    public class EmployeeRepository : HttpRequestRepository, IEmployeeRepository
    {
        private string _apiUrl;

        public EmployeeRepository()
        {
            _apiUrl = "employees";
        }

        public IEnumerable<Entities.Employee> GetEmployees()
        {
            return GetAsync<IEnumerable<Entities.Employee>>(_apiUrl)
                .Result;
        }

        public Entities.Employee GetEmployeeById(int employeeId)
        {
            return GetAsync<IEnumerable<Entities.Employee>>(_apiUrl)
                .Result
                .FirstOrDefault(x => x.Id == employeeId);
        }
    }
}
