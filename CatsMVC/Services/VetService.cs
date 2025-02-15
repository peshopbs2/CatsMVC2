using CatsMVC.DTOs;
using CatsMVC.Data.Entities;
using CatsMVC.Repositories.Abstractions;
using CatsMVC.Services.Abstractions;
using AutoMapper;

namespace CatsMVC.Services
{
    public class VetService : IVetService
    {
        private IVetRepository _vetRepository;
        private IMapper _mapper;
        public VetService(IVetRepository vetRepository, IMapper mapper)
        {
            _vetRepository = vetRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(VetDTO vetDto)
        {
            Vet vet = _mapper.Map<Vet>(vetDto);
            await _vetRepository.CreateAsync(vet);
        }

        public async Task DeleteAsync(int vetId)
        {
            await _vetRepository.DeleteByIdAsync(vetId);
        }

        public async Task<ICollection<VetDTO>> GetAllAsync()
        {
            var vets = await _vetRepository.GetAllAsync();
            return _mapper.Map<ICollection<VetDTO>>(vets);
        }

        public async Task<VetDTO> GetByIdAsync(int id)
        {
            var vet = await _vetRepository.GetByIdAsync(id);
            return _mapper.Map<VetDTO>(vet);
        }

        public ICollection<VetDTO> GetByName(string name)
        {
            var vets = _vetRepository
                .GetByFilter(vet => vet.FirstName == name 
                    || vet.LastName == name);
            return _mapper.Map<ICollection<VetDTO>>(vets);
        }

        public async Task UpdateAsync(VetDTO vetDto)
        {
            Vet vet = _mapper.Map<Vet>(vetDto);
            await _vetRepository.UpdateAsync(vet);
        }
    }
}
