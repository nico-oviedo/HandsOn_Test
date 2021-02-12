using HandsOn.Business.Services.Employee;
using HandsOn.Model.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HandsOn.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<EmployeeDto> GetEmployees()
        {
            return _employeeService.GetEmployees();
        }

        [HttpGet("{id}")]
        public EmployeeDto GetEmployeeById(int id)
        {
            return _employeeService.GetEmployeeById(id);
        }
    }
}