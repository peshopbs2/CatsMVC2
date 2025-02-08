using CatsMVC.Data;
using CatsMVC.Data.Entities;
using CatsMVC.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CatsMVC.Repositories
{
    public class CatsRepository : ICatsRepository
    {
        private readonly ApplicationDbContext _context;
        public CatsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Cat cat)
        {
            _context.Add(cat);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            Cat cat = await GetByIdAsync(id);
            if (cat != null)
            {
                _context.Remove(cat);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Item with id {id} does not exist.");
            }
        }

        public async Task<ICollection<Cat>> GetAllAsync()
        {
            return await _context.Cat.ToListAsync();
        }

        public ICollection<Cat> GetByFilter(Func<Cat, bool> predicate)
        {
            return _context.Cat
                .Where(predicate)
                .ToList();
        }

        public async Task<Cat?> GetByIdAsync(int id)
        {
            return await _context.Cat.FindAsync(id);
        }

        public async Task<Cat> UpdateAsync(Cat cat)
        {
            _context.Cat.Update(cat);
            await _context.SaveChangesAsync();
            return cat;
        }
    }
}
