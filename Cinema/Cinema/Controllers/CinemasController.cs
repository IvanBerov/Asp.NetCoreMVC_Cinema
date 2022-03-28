using CinemaApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext context;

        public CinemasController(AppDbContext _context)
        {
            this.context = _context;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas =await context.Cinemas.ToListAsync();

            return View();
        }
    }
}
