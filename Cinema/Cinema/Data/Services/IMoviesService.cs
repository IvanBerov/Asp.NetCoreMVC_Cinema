using CinemaApp.Data.BaseRepo;
using CinemaApp.Data.ViewModels;
using CinemaApp.Models;
using System.Threading.Tasks;

namespace CinemaApp.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);

        Task<NewMovieDropdownsViewModel> GetNewMovieDropdownsValue();

        Task AddNewMovieAsync(NewMovieViewModel movieModel);

        Task UpdateMovieAsync(NewMovieViewModel model);
    }
}
