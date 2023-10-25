
using AutoMapper;
using Domain.Process.Branch;
using Infraestructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories.BranchRepo
{
    internal class BranchRepository : IBranchRepository
    {
        private readonly QualaDbContext _context;
        private IMapper _mapper;

        public BranchRepository(QualaDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
        }

        public async Task<List<BranchDomain>> GetAll()
        {
            var currencies = await _context.Branches
                .Include(i => i.Currency)
                .ToListAsync();
            var result = _mapper.Map<List<BranchDomain>>(currencies);

            return result;
        }

        public Task<BranchDomain> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(BranchDomain branch)
        {

            var result = _mapper.Map<Branch>(branch);
            _context.Add(result);
            _context.SaveChanges();
            
        }

        public void Update(BranchDomain branch)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            Branch branch = _context.Branches.FirstOrDefault(x => x.Id == id);
            _context.Branches.Remove(branch);
            _context.SaveChanges();
        }
    }
}
