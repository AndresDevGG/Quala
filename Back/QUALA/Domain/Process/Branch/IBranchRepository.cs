using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Process.Branch
{
    public interface IBranchRepository
    {
        Task<List<BranchDomain>> GetAll();
        Task<BranchDomain> GetById(Guid id);
        void Save(BranchDomain branch);
        void Update(BranchDomain branch);
        void Delete(Guid id);

    }
}
