using System;
using System.Collections.Generic;

namespace HR_Department.APIv2.DBModels;

public partial class DepartmentOrganization
{
    public long Id { get; set; }

    public long DepartmentId { get; set; }

    public long OrganizationId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Organization Organization { get; set; } = null!;
}
