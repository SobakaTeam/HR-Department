using HR_Department.API.Models.Persons;

namespace HR_Department.API.Models.Other
{
    public class Vacation : AbstractBaseData
    {
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? VacationType { get; set; }
        public int EmployeeId { get; set; }
        public Employee GetEmployee()
        {
            return new Employee();
        }
    }
}
