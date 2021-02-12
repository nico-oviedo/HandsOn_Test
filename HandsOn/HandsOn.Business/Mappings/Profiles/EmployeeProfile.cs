using AutoMapper;
using HandsOn.Data.Entities;
using HandsOn.Model.Dtos;

namespace HandsOn.Business.Mappings.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, RoleDto>();

            CreateMap<Employee, ContractDto>();
        }
    }
}
