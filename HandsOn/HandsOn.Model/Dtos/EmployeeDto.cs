namespace HandsOn.Model.Dtos
{
    public abstract class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoleDto Role { get; set; }
        public ContractDto Contract { get; set; }
        public abstract double? AnnualSalary { get; }
    }
}
