using System;
using System.Collections.Generic;

namespace HR_Department.APIv2.DBModels;

public partial class Department
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly CreateAt { get; set; }

    public DateOnly? UpdatbiginteAt { get; set; }

    public virtual ICollection<DepartmentOrganization> DepartmentOrganizations { get; set; } = new List<DepartmentOrganization>();

    public virtual ICollection<PersonDepartment> PersonDepartments { get; set; } = new List<PersonDepartment>();
}
