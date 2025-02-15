using CatsMVC.Data.Entities;

namespace CatsMVC.Repositories.Abstractions
{
    public interface IVisitRepository
    {
        Task CreateAsync(Visit visit);
    }
}
