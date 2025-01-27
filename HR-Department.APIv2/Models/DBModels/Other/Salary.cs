using HR_Department.APIv2.Models.DBModels.Persons;
namespace HR_Department.APIv2.Models.DBModels.Other
{
    public class Salary : AbstractBaseData
    {
        public int? PersonId { get; set; }  
        public decimal? Amount { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Person GetPerson()
        {
            return new Person();
        }
    }
}
