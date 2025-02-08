using CatsMVC.DTOs;

namespace CatsMVC.Services.Abstractions
{
    public interface ICatService
    {
        Task<CatDTO> GetByIdAsync(int id);
        Task<ICollection<CatDTO>> GetAllAsync();
        Task CreateAsync(CatDTO catDto);
        Task UpdateAsync(CatDTO catDto);
        Task DeleteAsync(int catId);
        ICollection<CatDTO> GetByNameAsync(string name);
    }
}
