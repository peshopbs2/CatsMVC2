using CatsMVC.Data.Entities;

namespace CatsMVC.Repositories.Abstractions
{
    public interface ICatsRepository
    {
        Task CreateAsync(Cat cat);
        Task<Cat> UpdateAsync(Cat cat);
        Task DeleteByIdAsync(int id);
        Task<ICollection<Cat>> GetAllAsync();
        ICollection<Cat> GetByFilter(Func<Cat, bool> predicate);
        Task<Cat?> GetByIdAsync(int id);
    }
}