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

            EvlerKiralik.DAL.Entities.User CurrentUser = _database.Users.Where(x => x.UserId == LoggedUser).First();
            model.SonIlanlarım = _database.KirayaVermes.Where(x => x.UserId == CurrentUser.UserId).TakeLast(5);
            ViewBag.RezervasyonSayisi = _database.Reservations.Where(x=>x.UserId==CurrentUser.UserId).Count();
            ViewBag.YorumSayisi = _database.Comments.Where(x=>x.UserId== CurrentUser.UserId).Count();

            model.CurrentUserPosts = _database.KirayaVermes.Where(x => x.UserId == CurrentUser.UserId).ToList();

            

            return View(model);
	    }

        public IActionResult OverView()
        {

            int LoggedUser = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);

            dynamic model = new ExpandoObject();
            EvlerKiralik.DAL.Entities.User CurrentUser = _database.Users.Where(x => x.UserId == LoggedUser).First();

            model.KiralikEv = _database.KirayaVermes.Where(x => x.UserId == CurrentUser.UserId).ToList();
            // model.messages = MESAJ SİSTEMİ EKLENECEK LİSTELENECEK
            foreach (KirayaVerme item in model.KiralikEv)
            {
                var olusturan = _database.Users.Where(x => x.UserId == item.UserId).FirstOrDefault();
                if (olusturan != null)
                {
                    if (olusturan.UserStatus != "Verificated" && olusturan != null)
                    {
                        model.KiralikEvler.Remove(item);
                    }
                }
            }


            return PartialView(model);
        }


    }
}
