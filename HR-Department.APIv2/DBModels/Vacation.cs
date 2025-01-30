using System;
using System.Collections.Generic;

namespace HR_Department.APIv2.DBModels;

public partial class Vacation
{
    public long Id { get; set; }

    public DateOnly BeginDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? VacationType { get; set; }

    public DateOnly CreateAt { get; set; }

    public DateOnly? UpdateAt { get; set; }

    public virtual ICollection<PersonVacation> PersonVacations { get; set; } = new List<PersonVacation>();
}
