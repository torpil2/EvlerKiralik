using EvlerKiralik.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using Npgsql;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Dynamic;
using Newtonsoft.Json;
using System.Web.Helpers;
using System.IO;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Filters;
using NuGet.Versioning;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
using System.IO;
using NuGet.Packaging.Signing;
using System.Security.Principal;

namespace EvlerKiralik.Controllers
{
    // [Authorize]
    public class HomeController : Controller
    {
        public PostgresContext _database;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor accessor;





        public HomeController(PostgresContext database, IWebHostEnvironment webHostEnvironment)
        {
            _database = database;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult ShowSokaks()
        {
            return View();

        }



        public IActionResult Index()
        {

            dynamic model = new ExpandoObject();
            model.IlListesi = _database.Illers.ToList();
            model.IlListesiIlan = _database.Illers.ToList();
            //model.IlceListesi = _database.Ilcelers.ToList();
            //model.MahalleListesi = _database.Mahallelers.ToList();
            //model.SokakListesi = _database.Sokaklars.ToList();
            model.UserListesi = _database.Users.ToList();



            //var iller = _database.Illers.ToList();



            return View(model);

        }

        protected void il_selectedindexchanged(object sender, EventArgs e)
        {
            //var ilceler = _database.Ilcelers.Select(x=>x.IlId.Value=sender)
        }

        public IActionResult Privacy()
        {
            return View();
        }

        Iller IlClass = new Iller();
        Ilceler IlceClass = new Ilceler();
        PostgresContext db = new PostgresContext();
        public ActionResult Deneme()
        {
            //db.Illers = new SelectList(db.Illers, "il_id", "İl_adi");
            //db.Ilcelers = new SelectList(db.Ilcelers, "ilce_id", "ilce_adi");
            return View();
        }


        public JsonResult ilcegetir(int p)
        {
            var ilceler = (from x in db.Ilcelers
                           join y in db.Illers on x.IlId equals y.IlId
                           where x.IlId == p
                           select new
                           {
                               Text = x.IlceAdi,
                               Value = x.IlceId.ToString()
                           }).OrderBy(x => x.Text).ToList();
            return Json(ilceler);
        }

        public JsonResult mahallegetir(int m)
        {
            var mahalleler = (from x in db.Mahallelers
                              join y in db.Ilcelers on x.IlceId equals y.IlceId
                              where x.IlceId == m
                              select new
                              {
                                  Text = x.MahalleAdi,
                                  Value = x.MahalleId.ToString()
                              }).OrderBy(x => x.Text).ToList();

            return Json(mahalleler);
        }

        public JsonResult sokakgetir(int k)
        {
            var sokaklar = (from x in db.Sokaklars
                            join y in db.Mahallelers on x.MahalleId equals y.MahalleId
                            where x.MahalleId == k
                            select new
                            {
                                Text = x.SokakAdi,
                                Value = x.SokakId.ToString()
                            }).OrderBy(x => x.Text).ToList();
            return Json(sokaklar);
        }

        //İLAN VERME SEARCH
        public JsonResult ilcegetirilan(int a)
        {
            var ilcelerilan = (from x in db.Ilcelers
                               join y in db.Illers on x.IlId equals y.IlId
                               where x.IlId == a
                               select new
                               {
                                   Text = x.IlceAdi,
                                   Value = x.IlceId.ToString()
                               }).OrderBy(x => x.Text).ToList();
            return Json(ilcelerilan);
        }

        public JsonResult mahallegetirilan(int b)
        {
            var mahallelerilan = (from x in db.Mahallelers
                                  join y in db.Ilcelers on x.IlceId equals y.IlceId
                                  where x.IlceId == b
                                  select new
                                  {
                                      Text = x.MahalleAdi,
                                      Value = x.MahalleId.ToString()
                                  }).OrderBy(x => x.Text).ToList();
            return Json(mahallelerilan);
        }

        public JsonResult sokakgetirilan(int c)
        {
            var sokaklarilan = (from x in db.Sokaklars
                                join y in db.Mahallelers on x.MahalleId equals y.MahalleId
                                where x.MahalleId == c
                                select new
                                {
                                    Text = x.SokakAdi,
                                    Value = x.SokakId.ToString()
                                }).OrderBy(x => x.Text).ToList();
            return Json(sokaklarilan);
        }



        public IActionResult tabpage()
        {
            dynamic model = new ExpandoObject();
            model.IlListesi = _database.Illers.ToList();
            model.IlListesiIlan = _database.Illers.ToList();

            model.OdaSayiListe = _database.OdaSayisis.ToList();//2
            model.BinayasiListe = _database.BinaYasis.ToList();//9
            model.DaireKatListe = _database.DaireKats.ToList();//7
            model.IsitmaListe = _database.IsitmaTurs.ToList();//5
            model.BanyoSayiListe = _database.BanyoSayis.ToList(); //3 
            model.BalkonSayiListe = _database.BalkonSayis.ToList(); //4
            model.EsyaliCheckListe = _database.IsEsyalis.ToList();//6
            model.SiteCheckListe = _database.IsinSites.ToList();//10
            model.KimdenListe = _database.Kimdens.ToList();//11
            model.OdemeTurListe = _database.OdemeTurs.ToList();//12
            model.BoostTipListe = _database.BoostTips.ToList();//Optional
            model.EvTipListe = _database.EvTips.ToList();//1
            model.ToplamKatListe = _database.ToplamKats.ToList();//8
            model.ImageListe = _database.Pictures.ToList();
            model.KirayaVermeList = _database.KirayaVermes.ToList();

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> ImageUpload(IFormFile ifile, Picture pic)
        {



            string imgext = Path.GetExtension(ifile.FileName);
            if (imgext == ".jpg" || imgext == ".gif" || imgext == ".jpeg")
            {
                var saveimg = Path.Combine(_webHostEnvironment.WebRootPath, "imgs", ifile.FileName);
                var stream = new FileStream(saveimg, FileMode.Create);
                await ifile.CopyToAsync(stream);

                pic.ResimName = ifile.FileName;
                pic.ResimPath = saveimg.ToString();
                await _database.AddAsync(pic);
                await _database.SaveChangesAsync();
                ViewData["Message"] = "Selected Image File is Saved into folder & path into database";
            }
            else
            {
                ViewData["Message"] = "Please Upload only .jpeg,.jpg,.gif Images";
            }


            return RedirectToAction("TabPage", "Home");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteImage(int silinecekresimid, Picture pic)
        {
            try
            {


                string filedirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imgs/");
                ViewBag.filelist = Directory.EnumerateFiles(filedirectory, "*", SearchOption.AllDirectories).Select(Path.GetFileName);
                var silinecekresim = from o in _database.Pictures where o.ResimId == silinecekresimid select o;
                foreach (var resim in silinecekresim)
                {


                    var file = resim.ResimName;

                    string webRootPath = _webHostEnvironment.WebRootPath;
                    var filename = "";
                    filename = file;
                    var fullpath = webRootPath + "/imgs/" + file;

                    if (System.IO.File.Exists(fullpath))
                    {
                        _database.Pictures.Remove(resim);

                        System.IO.File.Delete(fullpath);
                        //ViewBag.deleteSuccess = "true";

                    }
                }
                _database.SaveChangesAsync();


                return RedirectToAction("TabPage", "Home");
            } catch (Exception ex)
            {
                return RedirectToAction("TabPage", "Home");
            }

        }


        [HttpPost]

        public async Task<IActionResult> ImagesUpload(IFormFile[] ifiles, Picture pic, int postid)
        {

            for (int i = 0; i < ifiles.Length; i++)
            {
                Picture pics = new Picture();
                var imgext = Path.GetExtension(ifiles[i].FileName);




                if (imgext == ".jpg" || imgext == ".gif" || imgext == ".jpeg")
                {
                    var saveimg = Path.Combine(_webHostEnvironment.WebRootPath, "imgs", ifiles[i].FileName);
                    var stream = new FileStream(saveimg, FileMode.Create);
                    await ifiles[i].CopyToAsync(stream);

                    pics.ResimName = ifiles[i].FileName;
                    pics.ResimPath = saveimg.ToString();
                    pics.PostId = postid;
                    await _database.AddAsync(pics);
                    await _database.SaveChangesAsync();


                    ViewData["Message"] = "Selected Image File is Saved into folder & path into database";
                }
                else
                {
                    ViewData["Message"] = "Please Upload only .jpeg,.jpg,.gif Images";
                }
            }

            return RedirectToAction("GonderiResimEkle", new { id = postid });
        }


        [HttpPost]
        public async Task<IActionResult> KiralikIlanOlustur(int ilanil, int ilanilce,
            int ilanmahalle, int ilansokak, string ilanadi, string ilanVerEvTip, string ilanVerOdaSayi,
            string ilanVerBanyoSayi, string ilanVerBalkonSayi, string ilanVerIsitmaTip, string ilanVerEsyaliCheck,
            string ilanVerDaireKat, string ilanVerToplamKat, string ilanVerBinaYas, string ilanVerSiteCheck, string ilanVerKimdenCheck, string ilanVerOdemeTip, string ilanVerAciklama)

        {
            KirayaVerme ilan = new KirayaVerme();
            var ilanili = from o in _database.Illers where o.IlId == ilanil select o.İlAdi;
            var ilceadi = from b in _database.Ilcelers where b.IlceId == ilanilce select b.IlceAdi;
            var mahalledadi = from c in _database.Mahallelers where c.MahalleId == ilanmahalle select c.MahalleAdi;
            var sokakadi = from d in _database.Sokaklars where d.SokakId == ilansokak select d.SokakAdi;
            var currentuser = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;

            //ez game ez life

            ilan.IlanIl = ilanili.FirstOrDefault();
            ilan.IlanIlce = ilceadi.FirstOrDefault();
            ilan.IlanMahalle = mahalledadi.FirstOrDefault();
            ilan.IlanSokak = sokakadi.FirstOrDefault();
            ilan.IlanDate = Convert.ToDateTime(DateTime.Now.ToString("G"));
            ilan.UserId = Convert.ToInt32(currentuser);
            ilan.IlanAdi = ilanadi;
            ilan.EvTip = ilanVerEvTip;
            ilan.OdaSayisi = ilanVerOdaSayi;
            ilan.BanyoSayisi = ilanVerBanyoSayi;
            ilan.Balkon = ilanVerBalkonSayi;
            ilan.IsitmaTuru = ilanVerIsitmaTip;
            ilan.Esyali = ilanVerEsyaliCheck;
            ilan.BulunduguKat = ilanVerDaireKat;
            ilan.ToplamKat = ilanVerToplamKat;
            ilan.BinaYasi = ilanVerBinaYas;
            ilan.SiteIcerisinde = ilanVerSiteCheck;
            ilan.Kimden = ilanVerKimdenCheck;
            ilan.OdemeTuru = ilanVerOdemeTip;
            ilan.Aciklama = ilanVerAciklama;



            await _database.AddAsync(ilan);

            await _database.SaveChangesAsync();

            var soneklenenilan = _database.KirayaVermes.OrderByDescending(p => p.IlanId).First().IlanId;


            //return RedirectToAction("TabPage","Home");,

            return RedirectToAction("GonderiResimEkle", new { id = soneklenenilan });



        }

        [HttpGet]
        public ActionResult GonderiResimEkle(int? id)
        {
            dynamic model = new ExpandoObject();
            //var GonderiResim = _database.Pictures.Where(x => x.PostId == id).ToList();
            model.ResimGonderiDetay = _database.KirayaVermes.Where(x => x.IlanId == id).ToList();
            model.KapakResimList = _database.Pictures.Where(x => x.IsKapak == true && x.PostId == id).ToList();
            model.GonderiResimler = _database.Pictures.Where(x => x.PostId == id).ToList().OrderBy(x=>x.ResimSira);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> resimOrder(int[] ids, int kapakresimid, int[] sira)
        {
           // var kapakresim = _database.Pictures.Where(x => x.ResimId == kapakresimid).FirstOrDefault();
            var gecerliilan = _database.Pictures.Where(x => x.ResimId == ids[0]).FirstOrDefault();
            var ilanid = gecerliilan.PostId;
         //   kapakresim.IsKapak = true;
          //  kapakresim.ResimSira = null;
            for (int i = 0; i < ids.Length; i++)
            {
                var resim = _database.Pictures.Where(x => x.ResimId == ids[i]).FirstOrDefault();
                if(resim.IsKapak!= false || resim.IsKapak != null)
                {
                    resim.IsKapak = false;
                }
              
                if(resim.ResimSira!=i+1)
                {
                    resim.ResimSira = i + 1;
                }
        

            }

            await _database.SaveChangesAsync();
            return RedirectToAction("GonderiResimEkle", new { id =  ilanid});

        }

     

    }
}