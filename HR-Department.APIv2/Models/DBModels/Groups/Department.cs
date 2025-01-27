using HR_Department.APIv2.Models.DBModels.Persons;

namespace HR_Department.APIv2.Models.DBModels.Groups
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
