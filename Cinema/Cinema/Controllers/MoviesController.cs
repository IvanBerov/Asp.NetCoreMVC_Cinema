using CinemaApp.Data;
using CinemaApp.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies =await _moviesService.GetAllAsync(a => a.Cinema);

            return View(allMovies);
        }

        //Get
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _moviesService.GetMovieByIdAsync(id);

            return View(movie);
        }

        //Get
        public async Task<IActionResult> Create() 
        {
            var movieDropdownsData = await _moviesService.GetNewMovieDropdownsValue();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(); 
        }
    }
}
