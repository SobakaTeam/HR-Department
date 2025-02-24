using HR_Department.APIv2.DBModels.Types;
using System;
using System.Collections.Generic;

namespace HR_Department.APIv2.DBModels;

public partial class PersonVacation : IJunction
{
    public long Id { get; set; }

    public long PersonId { get; set; }

    public long VacationId { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Vacation Vacation { get; set; } = null!;
}
