using CatsMVC.Data;
using CatsMVC.Data.Entities;
using CatsMVC.Repositories.Abstractions;

namespace CatsMVC.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        private ApplicationDbContext _context;
        public VisitRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public async Task CreateAsync(Visit visit)
        {
            _context.Visit.Add(visit);
            await _context.SaveChangesAsync();
        }
    }
}
