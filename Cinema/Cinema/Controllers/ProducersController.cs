using CinemaApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext context;

        public ProducersController(AppDbContext _context)
        {
            this.context = _context;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers =await context.Producers.ToListAsync();

            return View(allProducers);
        }
    }
}
