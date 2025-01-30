using System;
using System.Collections.Generic;

namespace HR_Department.APIv2.DBModels;

public partial class Position
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Desctription { get; set; }

    public DateOnly CreateAt { get; set; }

    public DateOnly? UpdateAt { get; set; }

    public virtual ICollection<PersonPosition> PersonPositions { get; set; } = new List<PersonPosition>();
}
