using HR_Department.APIv2.DBModels.Types;
using System;
using System.Collections.Generic;

namespace HR_Department.APIv2.DBModels;

public partial class PersonAuthorization 
{
    public long Id { get; set; }

    public long PersonId { get; set; }

    public long AuthorizationId { get; set; }

    public virtual Authorization Authorization { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
