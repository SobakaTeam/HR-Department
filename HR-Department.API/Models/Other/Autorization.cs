using HR_Department.API.Models.Persons;
namespace HR_Department.API.Models.Other
{
    public class Autorization : AbstractBaseData 
    {
        public string Login {  get; set; }
        public HashCode Password { get; set; }
        public int RoleId { get; set; }
        public int PersonId { get; set; }
        public Person GetPerson()
        {
            return new Person();
        }

    }
}
