using CinemaApp.Data;
using CinemaApp.Data.ViewModels;
using CinemaApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() => View(new LoginViewModel());

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (!ModelState.IsValid) return View(loginModel);

            var user = await _userManager.FindByEmailAsync(loginModel.EmailAddress);

            if (user != null)
            {
                var passCheck = await _userManager.CheckPasswordAsync(user, loginModel.Password);

                if (passCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }

                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginModel);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginModel);
        }

        public IActionResult Register() => View(new RegisterViewModel());

    }
}
