using HR_Department.APIv2.Models.DBModels.Other;

namespace HR_Department.APIv2.Models.DBModels.Persons
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
