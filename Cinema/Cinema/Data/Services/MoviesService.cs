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

        public async Task AddNewMovieAsync(NewMovieViewModel movieModel)
        {
            var newMovie = new Movie()
            {
                Name = movieModel.Name,
                Description = movieModel.Description,
                Price = movieModel.Price,
                ImageUrl = movieModel.ImageUrl,
                CinemaId = movieModel.CinemaId,
                StartDate = movieModel.StartDate,
                EndDate = movieModel.EndDate,
                MovieCategory = movieModel.MovieCategory,
                ProducerId = movieModel.ProducerId
            };

            await _appDbContext.Movies.AddAsync(newMovie);
            
            await _appDbContext.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in movieModel.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId,
                };

                await _appDbContext.Actors_Movies.AddAsync(newActorMovie);
            }

            await _appDbContext.SaveChangesAsync();
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

        public async Task UpdateMovieAsync(NewMovieViewModel model)
        {
            var currMovie = await _appDbContext
                .Movies
                .FirstOrDefaultAsync(m=> m.Id == model.Id);

            if (currMovie != null)
            {
                currMovie.Name = model.Name;
                currMovie.Description = model.Description;
                currMovie.Price = model.Price;
                currMovie.ImageUrl = model.ImageUrl;
                currMovie.CinemaId = model.CinemaId;
                currMovie.StartDate = model.StartDate;
                currMovie.EndDate = model.EndDate;
                currMovie.MovieCategory = model.MovieCategory;
                currMovie.ProducerId = model.ProducerId;

                await _appDbContext.SaveChangesAsync();
            }

            //Remove existing actors
            var actorsToRemove = _appDbContext
                .Actors_Movies
                .Where(n => n.MovieId == model.Id)
                .ToList();

            _appDbContext.Actors_Movies.RemoveRange(actorsToRemove);

            await _appDbContext.SaveChangesAsync();


            //Add Movie Actors
            foreach (var actorId in model.ActorIds)
            {
                var actorMovie = new Actor_Movie()
                {
                    MovieId = model.Id,
                    ActorId = actorId
                };

                await _appDbContext.Actors_Movies.AddAsync(actorMovie);
            }

            await _appDbContext.SaveChangesAsync();
        }
    }
}
