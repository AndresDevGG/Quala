using System;
using System.Collections.Generic;

namespace Infraestructure.Model;

public partial class Currency
{
    public Guid Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool? Active { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();
}
