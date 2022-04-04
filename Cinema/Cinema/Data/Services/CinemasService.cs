using CinemaApp.Data.BaseRepo;
using CinemaApp.Models;

namespace CinemaApp.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
