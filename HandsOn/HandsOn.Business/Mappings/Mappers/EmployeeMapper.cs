using AutoMapper;
using HandsOn.Business.Factories;
using HandsOn.Data.Entities;
using HandsOn.Model.Dtos;
using System.Collections.Generic;

namespace HandsOn.Business.Mappings.Mappers
{
    public class EmployeeMapper
    {
        private readonly IMapper _mapper;
        private EmployeeCreator _employeeCreator;

        public EmployeeMapper(IMapper mapper)
        {
            _mapper = mapper;
            _employeeCreator = new EmployeeCreator();
        }

        public EmployeeDto Map(Employee source)
        {
            EmployeeDto employeeDto = _employeeCreator.Create(source?.ContractTypeName);

            if (employeeDto != null)
            {
                employeeDto.Id = source.Id;
                employeeDto.Name = source.Name;
                employeeDto.Role = _mapper.Map<RoleDto>(source);
                employeeDto.Contract = _mapper.Map<ContractDto>(source);
            }

            return employeeDto;
        }

        public IEnumerable<EmployeeDto> Map(IEnumerable<Employee> source)
        {
            List<EmployeeDto> employeesDto = new List<EmployeeDto>();

            foreach (var emp in source)
            {
                employeesDto.Add(Map(emp));
            }

            return employeesDto;
        }
    }
}
