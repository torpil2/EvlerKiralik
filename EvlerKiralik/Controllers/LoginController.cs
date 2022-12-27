using EvlerKiralik.DAL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Policy;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security;
using System.Text;
using Newtonsoft.Json;

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
           
            PostgresContext db = new PostgresContext();

            var userget =  _database.Users.Where(x=>x.UserName == txtUserName && x.UserPassword == txtPassword).FirstOrDefault();
            if (userget != null)
            {
                var newclaims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName,txtUserName),
                    new Claim(JwtRegisteredClaimNames.NameId,Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name, userget.UserName),
                    new Claim ("UserMail",userget.UserMail),
                    new Claim("UserId",userget.UserId.ToString()),
                    new Claim("UserType", userget.UserType)



            };
                SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("evlerkiralik1234"));
                var token = new JwtSecurityToken(
                    issuer: "evlerkiralik.com",
                    audience: "evlerkiralik.com",
                    claims: newclaims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256
                    ));

                var identity = new ClaimsIdentity(
                    newclaims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
               
              HttpContext.Response.Cookies.Append("token",token.ToString(),new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTime.Now.AddHours(1)});
                //HttpContext.SignInAsync(
                //  CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                var newtoken = new JwtSecurityTokenHandler().WriteToken(token);
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


        [HttpPost]
        public async Task<IActionResult> Register(string username,string email,string password)
        {
            User newuser = new User();
            newuser.UserName = username;
            newuser.UserMail = email;
            newuser.UserPassword = password;
            newuser.UserType = "User";
            _database.Add(newuser);
            await _database.SaveChangesAsync();
            return RedirectToAction("Privacy", "Home");

        }


    }
}
