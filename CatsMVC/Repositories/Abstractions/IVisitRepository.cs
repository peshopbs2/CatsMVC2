using CatsMVC.Data.Entities;

namespace CatsMVC.Repositories.Abstractions
{
    public interface IVisitRepository
    {
        Task CreateAsync(Visit visit);
        //TODO: edit visit
        //TODO: get all visits
        //TODO: get visit by id
        //TODO: delete visit
    }
}
