using CinemaApp.Data.BaseRepo;
using CinemaApp.Data.ViewModels;
using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _appDbContext;

        public MoviesService(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;    
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _appDbContext.Movies
                .Include(c=> c.Cinema)
                .Include(p=> p.Producer)
                .Include(am=> am.Actors_Movies).ThenInclude(a=>a.Actor)
                .FirstOrDefaultAsync(n=> n.Id == id);

            return movie;
        }

        public async Task<NewMovieDropdownsViewModel> GetNewMovieDropdownsValue()
        {
            var respose = new NewMovieDropdownsViewModel()
            {
                Actors = await _appDbContext.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _appDbContext.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _appDbContext.Producers.OrderBy(n => n.FullName).ToListAsync(),
            };

            return respose;
        }
    }
}
