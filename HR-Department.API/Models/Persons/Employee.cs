using System.Security.Principal;
using HR_Department.API.Models.Groups;
using HR_Department.API.Models.Other;

namespace HR_Department.API.Models.Persons
{
    public class Employee : Person
    {
        public bool IsWorking { get; set; }
        public bool IsMaried { get; set; }
        public string NowPlaceLiving { get; set; }
        public DateTime HireDate { get; set; }
        public int OrganizationId { get; set; }
        public int VacationId { get; set; }
        public int SalaryId { get; set; }
        public Salary GetSalary()
        {
            return new Salary();
        }
        public Vacation GetVacation()
        {
            return new Vacation();
        }
        public Organization GetOrganization()
        {
            return new Organization();
        }
        public Posotion GetPosotion()
        {

            return new Posotion();
        }
        public List<Children> GetChildrens()
        {
            return new List<Children>();
        }
    }
}
