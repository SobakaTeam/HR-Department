using System;
using System.Collections.Generic;

namespace HR_Department.APIv2.DBModels;

public partial class Child
{
    public long Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MidleName { get; set; }

    public DateOnly? Birthday { get; set; }

    public DateOnly CreateAt { get; set; }

    public DateOnly? UpdateAt { get; set; }

    public virtual ICollection<PersonChild> PersonChildren { get; set; } = new List<PersonChild>();
}
