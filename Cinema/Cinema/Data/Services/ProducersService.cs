using CinemaApp.Data.BaseRepo;
using CinemaApp.Models;

namespace CinemaApp.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
