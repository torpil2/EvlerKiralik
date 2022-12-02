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

namespace EvlerKiralik.Controllers
{
   // [Authorize]
    public class HomeController : Controller
    {
        public PostgresContext _database;
        private readonly IWebHostEnvironment _webHostEnvironment;





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
                           }).OrderBy(x=>x.Text).ToList();
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
            return View(model);
        }

        
        



    }
}