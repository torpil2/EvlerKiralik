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
        public IActionResult Dashboard()
        {
           

			int LoggedUser = Convert.ToInt32(User.Claims.FirstOrDefault(c=>c.Type== "UserId").Value);
           
          
        
            dynamic model = new ExpandoObject();

            model.CurrentUser = _database.Users.Where(x => x.UserId == LoggedUser).ToList();

            model.CurrentUserPosts = _database.KirayaVermes.Where(x => x.UserId == LoggedUser).ToList();

            

            return View(model);
			}
         
		


    }
}
