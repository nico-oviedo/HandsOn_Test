namespace HandsOn.Model.Dtos
{
    public class MonthlySalaryEmployeeDto : EmployeeDto
    {
        public override double? AnnualSalary => Contract?.MonthlySalary * 12;
    }
}
