using HR_Department.API.Models.Persons;

namespace HR_Department.API.Models.Groups
{
    public class Department : AbstractGroup
    {
        public int EmployerId { get; set; }

        public override int GetPeopleCount()
        {
            return base.GetPeopleCount();
        }
        public List<Employee> GetEmployees()
        {
            return null;
        }
        public Person GetEmployer()
        {
            return null;
        }
    }
}
