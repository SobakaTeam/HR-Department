using System;
using System.Collections.Generic;

namespace HR_Department.APIv2.DBModels;

public partial class PersonSalary
{
    public long Id { get; set; }

    public long PersonId { get; set; }

    public long SalaryId { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Salary Salary { get; set; } = null!;
}
