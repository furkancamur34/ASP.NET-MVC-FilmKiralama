using FilmKiralama.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FilmKiralama.MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        FilmKiralamaContext db = new FilmKiralamaContext();
        // GET: Login
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult GirisYap(Musteri pMusteri) 
        {
            Musteri musteri = db.Musteri.AsNoTracking().Where(x => x.MusteriEposta == pMusteri.MusteriEposta && x.MusteriSifre == pMusteri.MusteriSifre).FirstOrDefault();

            if(musteri!=null)
            {
                FormsAuthentication.SetAuthCookie(musteri.MusteriEposta, false);
                Session["MusteriID"] = musteri.MusteriID;
                Session["MusteriAdSoyad"] = musteri.MusteriAdi + " " + musteri.MusteriSoyadi;
                Session["MusteriEposta"] = musteri.MusteriEposta;

                return RedirectToAction("Index", "Film");

            }

            return RedirectToAction("Index","Home");
        }

        public ActionResult CikisYap() 
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}