using CinemaApp.Data.Services;
using CinemaApp.Data.Static;
using CinemaApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducersController : Controller
    {
        private readonly IProducersService _producersService;

        public ProducersController(IProducersService producersService)
        {
            _producersService = producersService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducers =await _producersService.GetAllAsync();

            return View(allProducers);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producer = await _producersService.GetByIdAsync(id);

            if (producer == null) return View("NotFound");

            return View(producer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("PictureUrl,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _producersService.AddAsync(producer);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var producer = await _producersService.GetByIdAsync(id);

            if (producer == null) return View("NotFound");

            return View(producer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PictureUrl,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);
            
            if (producer.Id == id)
            {
                await _producersService.UpdateAsync(id, producer);

                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        //Get
        public async Task<IActionResult> Delete(int id)
        {
            var producer = await _producersService.GetByIdAsync(id);

            if (producer == null) return View("NotFound");

            return View(producer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producer = await _producersService.GetByIdAsync(id);

            if (producer == null) return View("NotFound");

            await _producersService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
