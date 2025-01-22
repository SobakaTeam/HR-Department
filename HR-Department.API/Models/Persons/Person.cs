using HR_Department.API.Models.Other;
using System.Collections;

namespace HR_Department.API.Models.Persons
{
    public class Person : IPerson , IEquatable<Person>
    {
        public int ID { get; set; }
        public string? Name { get; set; } // Может быть null
        public string? Surname { get; set; } // Может быть null
        public string? Patronymic { get; set; }  // Может быть null
        public string? Phone { get; set; } // Может быть null
        public string? Email { get; set; } // Может быть null
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? Birthday { get; set; } // Может быть null
        public BitArray? GetDocument(string? DocumentType)
        {
            return null;
        }
        public bool Equals(Person? other)
        {
            if (other == null) return false;
            if (this.ID == other.ID)
            {
                return true;
            }
            return false;
        }
    }
}
