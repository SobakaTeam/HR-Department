using HR_Department.API.Models.Other;

namespace HR_Department.API.Models.Persons
{
    public class Employer : Employee
    {
        public int OrganizationId { get; set; }
        public Organization GetOrganization()
        {
            return new Organization();
        }
    }
}
