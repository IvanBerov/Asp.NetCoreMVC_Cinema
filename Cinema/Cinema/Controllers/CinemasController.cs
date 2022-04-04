using CinemaApp.Data;
using CinemaApp.Data.Services;
using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _cinemasService;

        public CinemasController(ICinemasService cinemasService)
        {
            _cinemasService = cinemasService;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas =await _cinemasService.GetAllAsync();

            return View(allCinemas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _cinemasService.AddAsync(cinema);

            return RedirectToAction(nameof(Index));
        }

        //Get
        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _cinemasService.GetByIdAsync(id);

            if (cinema == null) return View("NotFound");

            return View(cinema);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _cinemasService.GetByIdAsync(id);

            if (cinema == null) return View("NotFound");

            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _cinemasService.UpdateAsync(id, cinema);

            return RedirectToAction(nameof(Index));
        }

        //Get
        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _cinemasService.GetByIdAsync(id);

            if (cinema == null) return View("NotFound");

            return View(cinema);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinema = await _cinemasService.GetByIdAsync(id);

            if (cinema == null) return View("NotFound");

            await _cinemasService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
