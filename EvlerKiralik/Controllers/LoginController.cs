using EvlerKiralik.DAL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Policy;

namespace EvlerKiralik.Controllers
{
    public class LoginController : Controller
    {
        public PostgresContext _database;

        public LoginController(PostgresContext database)
        {
            _database = database;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string txtUserName, string txtPassword)
        {
            User UserCurrent = new User();
            PostgresContext db = new PostgresContext();

            var userget =  _database.Users.Where(x=>x.UserName == txtUserName && x.UserPassword == txtPassword).FirstOrDefault();
            if (userget != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userget.UserName),
                    new Claim ("UserMail",userget.UserMail),
                    new Claim("UserId",userget.UserId.ToString())

            };
                var identity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                ViewBag.UserId = userget.UserMail;
                return RedirectToAction("TabPage", "Home");
            }
            else
            {
                return RedirectToAction("TabPage","Home");
            }
        }

        

        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogoutAct()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("TabPage", "Home");
        }
    }
}
