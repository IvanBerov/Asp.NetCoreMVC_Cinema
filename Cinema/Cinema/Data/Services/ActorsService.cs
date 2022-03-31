using CinemaApp.Data.BaseRepo;
using CinemaApp.Models;

namespace CinemaApp.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
