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
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.Differencing;
using NuGet.Protocol;
using EvlerKiralik.Model;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using System.Collections;

namespace EvlerKiralik.Controllers
{
    public class AdminController : Controller
    {
        public PostgresContext _database;


        public AdminController(PostgresContext database)
        {
            _database = database;
         

        }

        public IActionResult Index()
        {

            dynamic model = new ExpandoObject();
            model.KirayaVermeList = _database.KirayaVermes.ToList();
            model.UserList = _database.Users.ToList();
           
	





			return View(model);
        }
        
                        


        public IActionResult Categories()
        {

            dynamic model = new ExpandoObject();
            model.OdaSayiListe = _database.OdaSayisis.ToList();//
            model.BinayasiListe = _database.BinaYasis.ToList();//
            model.DaireKatListe = _database.DaireKats.ToList();//
            model.IsitmaListe = _database.IsitmaTurs.ToList();//
            model.BanyoSayiListe = _database.BanyoSayis.ToList(); // 
            model.BalkonSayiListe = _database.BalkonSayis.ToList(); //
            model.EsyaliCheckListe = _database.IsEsyalis.ToList();//
            model.SiteCheckListe = _database.IsinSites.ToList();//
            model.KimdenListe = _database.Kimdens.ToList();//
            model.OdemeTurListe = _database.OdemeTurs.ToList();//
            model.BoostTipListe = _database.BoostTips.ToList();//
            model.EvTipListe = _database.EvTips.ToList();//
            model.ToplamKatListe = _database.ToplamKats.ToList();           


            return View(model);
        }

        //Oda Sayı Ekle/Sil
        [HttpPost]
        public async Task<IActionResult> OdaSayiEkle(string odasayi)
        {
           
            OdaSayisi newodasayi = new OdaSayisi() { OdaSayisi1=odasayi};
           _database.OdaSayisis.Add(newodasayi);
            await _database.SaveChangesAsync();                 
            return RedirectToAction("Categories", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> OdaSayiSil(string silinecekodasayi)
        {
            var silinecekoda = from o in _database.OdaSayisis where o.OdaSayisi1 == silinecekodasayi select o;
            foreach (var odasa in silinecekoda)
            {
                _database.OdaSayisis.Remove(odasa);
            }
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        //Bina Yaşı Ekle/Sil

        [HttpPost]
        public async Task<IActionResult> BinyaYasiEkle(string binayasi)
        {

            BinaYasi newbinayasi = new BinaYasi() { BinaYasi1 = binayasi };
            _database.BinaYasis.Add(newbinayasi);
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> BinaYasiSil(string silinecekbinayasi)
        {
            var silinecekbina = from o in _database.BinaYasis where o.BinaYasi1 == silinecekbinayasi select o;
            foreach (var binaya in silinecekbina)
            {
                _database.BinaYasis.Remove(binaya);
            }
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        //Daire Kat Ekle/Sil
        [HttpPost]
        public async Task<IActionResult> DaireKatEkle(string dairekat)
        {

            DaireKat newdairekat = new DaireKat() { DaireKat1 = dairekat };
            _database.DaireKats.Add(newdairekat);
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> DaireKatSil(string silinecekdairekat)
        {
            var silinecekdaire = from o in _database.DaireKats where o.DaireKat1 == silinecekdairekat select o;
            foreach (var daireka in silinecekdaire)
            {
                _database.DaireKats.Remove(daireka);
            }
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        //Isıtma Tür Ekle/Sil
        [HttpPost]
        public async Task<IActionResult> IsitmaTurEkle(string isitmatur)
        {

            IsitmaTur newisitmatur = new IsitmaTur() { IsitmaTur1 = isitmatur };
            _database.IsitmaTurs.Add(newisitmatur);
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> IsitmaTurSil(string silinecekisitmatur)
        {
            var silinecekisitma = from o in _database.IsitmaTurs where o.IsitmaTur1 == silinecekisitmatur select o;
            foreach (var isitmaTu in silinecekisitma)
            {
                _database.IsitmaTurs.Remove(isitmaTu);
            }
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        //Banyo Sayı EKle/Sil

        [HttpPost]
        public async Task<IActionResult> BanyoSayıEkle(string banyosayi)
        {

            BanyoSayi newbanyosayi = new BanyoSayi() { BanyoSayi1 = banyosayi };
            _database.BanyoSayis.Add(newbanyosayi);
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> BanyoSayıSil(string silinecekbanyosayi)
        {
            var silinecekbanyo = from o in _database.BanyoSayis where o.BanyoSayi1 == silinecekbanyosayi select o;
            foreach (var banyosa in silinecekbanyo)
            {
                _database.BanyoSayis.Remove(banyosa);
            }
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        //Balkon Sayı Ekle/Sil
        [HttpPost]
        public async Task<IActionResult> BalkonSayıEkle(string balkonsayi)
        {

            BalkonSayi newbalkonsayi = new BalkonSayi() { BalkonSayi1 = balkonsayi };
            _database.BalkonSayis.Add(newbalkonsayi);
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> BalkonSayıSil(string silinecekbalkonsayi)
        {
            var silinecekbalkon = from o in _database.BalkonSayis where o.BalkonSayi1 == silinecekbalkonsayi select o;
            foreach (var balkonsa in silinecekbalkon)
            {
                _database.BalkonSayis.Remove(balkonsa);
            }
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }


        //Eşyalı Check Ekle/Sil
        [HttpPost]
        public async Task<IActionResult> EsyaliCheckEkle(string esyalicheck)
        {

            IsEsyali newesyalicheck = new IsEsyali() { IsEsyali1 = esyalicheck };
            _database.IsEsyalis.Add(newesyalicheck);
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> EsyaliCheckSil(string silinecekesyalicheck)
        {
            var silinecekesyali = from o in _database.IsEsyalis where o.IsEsyali1 == silinecekesyalicheck select o;
            foreach (var esyaliche in silinecekesyali)
            {
                _database.IsEsyalis.Remove(esyaliche);
            }
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        //InSite Check Ekle/Sil
        [HttpPost]
        public async Task<IActionResult> SiteCheckEkle(string sitecheck)
        {

            IsinSite newsitecheck = new IsinSite() { IsinSite1 = sitecheck };
            _database.IsinSites.Add(newsitecheck);
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> SiteCheckSil(string silineceksitecheck)
        {
            var silineceksite = from o in _database.IsinSites where o.IsinSite1 == silineceksitecheck select o;
            foreach (var siteche in silineceksite)
            {
                _database.IsinSites.Remove(siteche);
            }
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }


        //Kimden Ekle/sil
        [HttpPost]
        public async Task<IActionResult> KimdenListeEkle(string kimden)
        {

            Kimden newkimden = new Kimden() { KimdenAdi = kimden };
            _database.Kimdens.Add(newkimden);
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> KimdenListeSil(string silinecekkimden)
        {
            var silinecekkim = from o in _database.Kimdens where o.KimdenAdi == silinecekkimden select o;
            foreach (var kimden in silinecekkim)
            {
                _database.Kimdens.Remove(kimden);
            }
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        //Ödeme Tür

        [HttpPost]
        public async Task<IActionResult> OdemeTurEkle(string odemetur)
        {

            OdemeTur newodemetur = new OdemeTur() { OdemeTurName = odemetur };
            _database.OdemeTurs.Add(newodemetur);
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> OdemeTurSil(string silinecekodemetur)
        {
            var silinecekodeme = from o in _database.OdemeTurs where o.OdemeTurName == silinecekodemetur select o;
            foreach (var odemetur in silinecekodeme)
            {
                _database.OdemeTurs.Remove(odemetur);
            }
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        //Boost Tip Ekle/Sil

        [HttpPost]
        public async Task<IActionResult> BoostTipEkle(string boostTip)
        {

            BoostTip newboostTip = new BoostTip() { BoostTipAdi = boostTip };
            _database.BoostTips.Add(newboostTip);
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> BoostTipSil(string silinecekBoostTip)
        {
            var silinecekBoost = from o in _database.BoostTips where o.BoostTipAdi == silinecekBoostTip select o;
            foreach (var boostTip in silinecekBoost)
            {
                _database.BoostTips.Remove(boostTip);
            }
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        //Ev Türleri Ekle/Sil

        [HttpPost]
        public async Task<IActionResult> EvTipEkle(string evTip)
        {

            EvTip newEvTip = new EvTip() { EvTipName = evTip };
            _database.EvTips.Add(newEvTip);
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> EvTipSil(string silinecekEvTip)
        {
            var silinecekEv = from o in _database.EvTips where o.EvTipName == silinecekEvTip select o;
            foreach (var evTip in silinecekEv)
            {
                _database.EvTips.Remove(evTip);
            }
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        //Toplam Kat Ekle/Sil
        [HttpPost]
        public async Task<IActionResult> ToplamKatEkle(string toplamKat)
        {

            ToplamKat newToplamKat = new ToplamKat() { ToplamKatAdi = toplamKat };
            _database.ToplamKats.Add(newToplamKat);
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> ToplamKatSil(string silinecekToplamKat)
        {
            var silinecekToplam = from o in _database.ToplamKats where o.ToplamKatAdi == silinecekToplamKat select o;
            foreach (var toplamKat in silinecekToplam)
            {
                _database.ToplamKats.Remove(toplamKat);
            }
            await _database.SaveChangesAsync();
            return RedirectToAction("Categories", "Admin");
        }

        public IActionResult UsersView() 
        {
            dynamic model = new ExpandoObject();

            model.UserList = _database.Users.ToList();
            return View(model);
        }


        [HttpGet]
        public  IActionResult EditUser(int? Id)
        {


            var user = _database.Users.Where(x => x.UserId == Id).SingleOrDefault();
                       
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> EditUserAct(int userId,string userMail,string userName,string userPassword,string userType)
        {
            var edituser = _database.Users.Where(x=>x.UserId== userId).FirstOrDefault();
            if(edituser!= null)
            {
                edituser.UserName = userName;
                edituser.UserMail = userMail;
                edituser.UserPassword = userPassword;
                edituser.UserType = userType;
                _database.Users.Update(edituser);
                await _database.SaveChangesAsync();
                return RedirectToAction("UsersView", "Admin");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult IlanDetay( int? id) 
        {

            dynamic model = new ExpandoObject();
            model.GonderiKirayaVerme = _database.KirayaVermes.Where(x => x.IlanId == id).ToList();
         var gonderiuserid = _database.KirayaVermes.Where(x=>x.IlanId==id).FirstOrDefault();
            var idd = gonderiuserid.UserId;
            model.GonderiPic = _database.Pictures.Where(x => x.PostId == id).ToList();
           model.GonderiUser = _database.Users.Where(x=>x.UserId==idd).ToList();


            //model.GecerliIlan = _database.KirayaVermes.Where(x=>x.IlanId == id).SingleOrDefault();
            if (model != null)
            {
                return View(model);


            }
            else
            {
                return View("Index", "Admin");
            }

            
		//	return View(Gonderi);
        }


        public IActionResult GonderiOnay()
        {
            dynamic model = new ExpandoObject();
            model.onayilan = _database.KirayaVermes.Where(x => x.IsApproved == false).ToList().Take(1);
            //var list = _database.KirayaVermes.Where(x => x.IsApproved == false).FirstOrDefault(); 
                        

            return View(model);
        }

       

        [HttpPost]
        public async Task<IActionResult> GonderiOnayla(int gonderiId)
        {
            var gonderi = _database.KirayaVermes.Where(x=>x.IlanId==gonderiId).FirstOrDefault();
            gonderi.IsApproved =true;
            await _database.SaveChangesAsync();

            return RedirectToAction("GonderiOnay", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> GonderiReddet(int gonderiId)
        {
            
            var gonderi = _database.KirayaVermes.Where(x => x.IlanId == gonderiId).FirstOrDefault();
            gonderi.IsApproved = false;
            await _database.SaveChangesAsync();
            return RedirectToAction("GonderiOnay", "Admin");
        }


        public JsonResult GonderisTek(int p)
        {
            var gonderiler = _database.KirayaVermes.ToList();

            List<KirayaVerme> gonderilist = _database.KirayaVermes.ToList();
            if(p<gonderilist.Count())
            {

          
            var gonder = gonderilist[p];
  
            return Json(gonder);
            }
            else
            {

                return Json(gonderilist[0]);
            }




        }



    }
    }
