﻿using System;
using System.Collections.Generic;

namespace HR_Department.APIv2.DBModels;

public partial class PersonDepartment
{
    public long Id { get; set; }

    public long PersonId { get; set; }

    public long DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
