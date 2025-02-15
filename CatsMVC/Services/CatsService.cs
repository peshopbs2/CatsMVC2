using AutoMapper;
using CatsMVC.Data.Entities;
using CatsMVC.DTOs;
using CatsMVC.Repositories.Abstractions;
using CatsMVC.Services.Abstractions;

namespace CatsMVC.Services
{
    public class CatsService : ICatService
    {
        private readonly ICatsRepository _catsRepository;
        private readonly IVisitRepository _visitRepository;
        private readonly IMapper _mapper;
        public CatsService(ICatsRepository catsRepository, IVisitRepository visitRepository, IMapper mapper)
        {
            _catsRepository = catsRepository;
            _visitRepository = visitRepository;
            _mapper = mapper;
        }

        public async Task AddCatVisitAsync(CatVisitDTO catVisitDTO)
        {
            var visit = _mapper.Map<Visit>(catVisitDTO);
            await _visitRepository.CreateAsync(visit);
        }

        public async Task CreateAsync(CatDTO catDto)
        {
            var cat = _mapper.Map<Cat>(catDto);
            await _catsRepository.CreateAsync(cat);
        }

        public async Task DeleteAsync(int catId)
        {
            await _catsRepository.DeleteByIdAsync(catId);
        }

        public async Task<ICollection<CatDTO>> GetAllAsync()
        {
            var cats = await _catsRepository.GetAllAsync();
            return _mapper.Map<ICollection<CatDTO>>(cats);
        }

        public async Task<CatDTO> GetByIdAsync(int id)
        {
            var cat = await _catsRepository.GetByIdAsync(id);
            return _mapper.Map<CatDTO>(cat);
        }

        public ICollection<CatDTO> GetByName(string name)
        {
            var cats = _catsRepository.GetByFilter(cat => cat.Name == name);
            return _mapper.Map<ICollection<CatDTO>>(cats);
        }

        public async Task UpdateAsync(CatDTO catDto)
        {
            var cat = _mapper.Map<Cat>(catDto);
            await _catsRepository.UpdateAsync(cat);
        }
    }
}
