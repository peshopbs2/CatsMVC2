using CatsMVC.Data;
using CatsMVC.Data.Entities;
using CatsMVC.Repositories.Abstractions;

namespace CatsMVC.Repositories
{
    public class VetRepository : CrudRepository<Vet>, IVetRepository
    {
        public VetRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
