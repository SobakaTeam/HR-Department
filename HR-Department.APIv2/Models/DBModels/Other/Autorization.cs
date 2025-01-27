using HR_Department.APIv2.Models.DBModels.Persons;
namespace HR_Department.APIv2.Models.DBModels.Other
{
    public class Autorization : AbstractBaseData 
    {
        public string? Login {  get; set; }
        public HashCode? PasswordHash { get; set; }
        public string? Role { get; set; }
        public int? PersonId { get; set; }
        public Person GetPerson()
        {
            return new Person();
        }

    }
}
