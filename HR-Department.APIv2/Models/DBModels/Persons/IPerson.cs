﻿using HR_Department.APIv2.Models.DBModels.Other;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace HR_Department.APIv2.Models.DBModels.Persons
{
    public interface IPerson
    {
        [Required]
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; } // Может быть null
        public string? Surname { get; set; } // Может быть null
        public string? Patronymic { get; set; }  // Может быть null
        public string? Phone { get; set; } // Может быть null
        public string? Email { get; set; } // Может быть null
        public DateTime? Birthday { get; set; } // Может быть null
        //public int PasportId { get; set; }
        public BitArray? GetDocument(string? DocumentType);
    }
}