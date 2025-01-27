using Microsoft.AspNetCore.SignalR;
using HR_Department.APIv2.Models.DBModels.Persons;

namespace HR_Department.APIv2.Models.DBModels.Other
{
    public class Organization : AbstractBaseData
    {
        public string? Name { get; set; }
        public DateTime? RegistrDate { get; set; }
        public string? Adress { get; set; }
        public int? EmployerId { get; set; }
        public Person GetEmployer()
        {
            return new Person();
        }
    }
}
