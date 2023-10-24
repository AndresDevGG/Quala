using System;
using System.Collections.Generic;

namespace Infraestructure.Model;

public partial class Branch
{
    public Guid Id { get; set; }

    public int Code { get; set; }

    public string Description { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Identify { get; set; } = null!;

    public DateTime? Created { get; set; }

    public Guid? CurrencyId { get; set; }

    public bool? Active { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Currency? Currency { get; set; }
}
