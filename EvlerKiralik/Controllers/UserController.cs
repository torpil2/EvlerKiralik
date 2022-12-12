using EvlerKiralik.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

namespace EvlerKiralik.Controllers
{

	[Authorize]
	public class UserController : Controller
    {
        public PostgresContext _database;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor accessor;




        public UserController(PostgresContext database, IWebHostEnvironment webHostEnvironment)
        {
            _database = database;
            _webHostEnvironment = webHostEnvironment;

        }

    
        [HttpGet]
        public IActionResult UserDashboard(int id)
        {
           

			var LoggedUser = User.Claims.FirstOrDefault(c=>c.Type== "UserId").Value;
           
            if(id == Convert.ToInt32(LoggedUser))
            {

        
            dynamic model = new ExpandoObject();

            model.CurrentUser = _database.Users.Where(x => x.UserId == id).ToList();

            model.CurrentUserPosts = _database.KirayaVermes.Where(x => x.UserId == id).ToList();

            

            return View(model);
			}
            else
            {
                return RedirectToAction("TabPage", "Home");
            }
		}


    }
}
