namespace HandsOn.Model.Dtos
{
    public class HourlySalaryEmployeeDto : EmployeeDto
    {
        public override double? AnnualSalary => 120 * Contract?.HourlySalary * 12;
    }
}

