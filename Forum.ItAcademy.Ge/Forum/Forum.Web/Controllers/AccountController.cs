using Forum.Application.Accounts.Requests;
using Forum.Application.Exceptions;
using Forum.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginRequestModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
                throw new UserNotFoundException();

            var signInResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (signInResult.Succeeded)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Username or password is incorrect");

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterRequestModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var user = new User { Email = model.Email, UserName = model.Username };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                await _signInManager.SignInAsync(user, false);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);

                    return View();
                }
            }

            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
