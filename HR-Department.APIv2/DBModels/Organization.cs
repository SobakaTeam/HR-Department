using System;
using System.Collections.Generic;

namespace HR_Department.APIv2.DBModels;

public partial class Organization
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly RegistrDate { get; set; }

    public string? Adress { get; set; }

    public DateOnly CreateAt { get; set; }

    public DateOnly? UpdateAt { get; set; }

    public virtual ICollection<DepartmentOrganization> DepartmentOrganizations { get; set; } = new List<DepartmentOrganization>();
}
