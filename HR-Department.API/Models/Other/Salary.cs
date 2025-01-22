using HR_Department.API.Models.Persons;
namespace HR_Department.API.Models.Other
{
    public class Salary : AbstractBaseData
    {
        public int? EmployeeId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Person GetPerson()
        {
            return new Person();
        }
    }
}
