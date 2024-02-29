using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using pasaj.mvc.Models;
using pasaj.Service;
using System.Security.Claims;

namespace pasaj.mvc.Controllers
{
    public class UserAccountController : Controller
    {

        private readonly IUserService userService;

        public UserAccountController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string? gidilecekUrl)
        {
            UserLoginModel userLoginModel = new UserLoginModel();
            userLoginModel.ReturnUrl = gidilecekUrl;
            return View(userLoginModel);
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                var user = userService.ValidateUser(userLoginModel.UserName, userLoginModel.Password);
                if (user != null)
                {
                    var claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role),

                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    HttpContext.SignInAsync(claimsPrincipal);

                    if (!string.IsNullOrEmpty(userLoginModel.ReturnUrl) && Url.IsLocalUrl(userLoginModel.ReturnUrl))
                    {
                        return Redirect(userLoginModel.ReturnUrl);
                    }
                    return Redirect("/");
                }

                ModelState.AddModelError("failed", "Hatalı giriş!");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");

        }
    }
}
