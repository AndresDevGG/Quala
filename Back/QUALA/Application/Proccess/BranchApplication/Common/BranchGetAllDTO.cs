using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Proccess.BranchApplication.Common
{
    public record BranchGetAllDTO(
        Guid Id,
        int Code,
        string Description,
        string Address,
        string Identify,
        DateTime? Created,
        string Currency,
        bool? Active
    );
}
