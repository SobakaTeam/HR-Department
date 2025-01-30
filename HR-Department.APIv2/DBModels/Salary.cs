using System;
using System.Collections.Generic;

namespace HR_Department.APIv2.DBModels;

public partial class Salary
{
    public long Id { get; set; }

    public decimal Amount { get; set; }

    public DateOnly BeginDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateOnly CreateAt { get; set; }

    public DateOnly? UpdateAt { get; set; }

    public virtual ICollection<PersonSalary> PersonSalaries { get; set; } = new List<PersonSalary>();
}
