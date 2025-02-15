using CatsMVC.DTOs;

namespace CatsMVC.Services.Abstractions
{
    public interface IVetService
    {
        Task<VetDTO> GetByIdAsync(int id);
        Task<ICollection<VetDTO>> GetAllAsync();
        Task CreateAsync(VetDTO vetDto);
        Task UpdateAsync(VetDTO vetDto);
        Task DeleteAsync(int vetId);
        ICollection<VetDTO> GetByName(string name);
    }
}
