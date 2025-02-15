using CatsMVC.Data;
using CatsMVC.Data.Entities;
using CatsMVC.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CatsMVC.Repositories
{
    public class CatsRepository : CrudRepository<Cat>, ICatsRepository
    {
        private readonly ApplicationDbContext _context;

        public CatsRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
