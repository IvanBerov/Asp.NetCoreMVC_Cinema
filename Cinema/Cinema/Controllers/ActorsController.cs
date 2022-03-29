using CinemaApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CinemaApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext context;

        public ActorsController(AppDbContext _context)
        {
            this.context = _context;
        }

        public IActionResult Index()
        {
            var data = context.Actors.ToList();

            return View(data);
        }
    }
}
