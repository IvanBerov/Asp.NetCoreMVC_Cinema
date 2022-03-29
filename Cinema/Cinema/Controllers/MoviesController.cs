using CinemaApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext context;

        public MoviesController(AppDbContext _context)
        {
            this.context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies =await context.Movies
                .Include(c => c.Cinema)
                .OrderBy(n => n.Name)
                .ToListAsync();

            return View(allMovies);
        }
    }
}
