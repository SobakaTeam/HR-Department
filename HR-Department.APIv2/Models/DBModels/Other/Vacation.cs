using HR_Department.APIv2.Models.DBModels.Persons;

namespace HR_Department.APIv2.Models.DBModels.Other
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
