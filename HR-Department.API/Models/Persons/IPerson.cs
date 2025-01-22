using HR_Department.API.Models.Other;
using System.Collections;

namespace HR_Department.API.Models.Persons
{
    public interface IPerson
    {
        public int ID { get; set; }
        public string? Name { get; set; } // Может быть null
        public string? Surname { get; set; } // Может быть null
        public string? Patronymic { get; set; }  // Может быть null
        public string? Phone { get; set; } // Может быть null
        public string? Email { get; set; } // Может быть null
        public DateTime? Birthday { get; set; } // Может быть null
        public BitArray? GetDocument(string? DocumentType);
    }
}
