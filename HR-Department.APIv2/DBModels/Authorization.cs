using System;
using System.Collections.Generic;

namespace HR_Department.APIv2.DBModels;

public partial class Authorization
{
    public long Id { get; set; }

    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? PasswordSalt { get; set; }

    public string? Role { get; set; }

    public DateOnly CreateAt { get; set; }

    public DateOnly? UpdateAt { get; set; }

    public virtual ICollection<PersonAuthorization> PersonAuthorizations { get; set; } = new List<PersonAuthorization>();
}
