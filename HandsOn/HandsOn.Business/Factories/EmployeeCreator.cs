using HandsOn.Business.Enums;
using HandsOn.Model.Dtos;
using System.Collections.Generic;

namespace HandsOn.Business.Factories
{
    public class EmployeeCreator
    {
        private Dictionary<string, EmployeeDto> _employeeTypes = new Dictionary<string, EmployeeDto>()
        {
            { EmployeeTypeEnum.HourlySalaryEmployee.ToString(), new HourlySalaryEmployeeDto() },
            { EmployeeTypeEnum.MonthlySalaryEmployee.ToString(), new MonthlySalaryEmployeeDto() }
        };

        public EmployeeDto Create(string contractTypeName)
        {
            if (string.IsNullOrWhiteSpace(contractTypeName))
            {
                return null;
            }

            return _employeeTypes[contractTypeName];
        }
    }
}
