using FilmKiralama.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace FilmKiralama.MVC.Controllers
{
    public class SepetController : Controller
    {
        FilmKiralamaContext db = new FilmKiralamaContext();
        // GET: Sepet
        [Authorize]
        public ActionResult Index()
        {
            string parseSession = (string)Session["MusteriEposta"];

            var idGetir = db.Musteri.Where(x => x.MusteriEposta == parseSession).Select(x => x.MusteriID).FirstOrDefault();

            List<Sepet> sepetler = db.Sepet.AsNoTracking().Include(x=>x.Musteri).Include(x => x.Film).Where(x => x.SepetMusteriId == idGetir && x.SepetDurumu==true).ToList();

            return View(sepetler);
        }

        
        public ActionResult Ekle(int id)
        {
            Film film = db.Film.Find(id);

            Sepet sepet = new Sepet();

            sepet.SepetFilmId = film.FilmID;

            string parseSession = (string)Session["MusteriEposta"];

            var idGetir = db.Musteri.Where(x => x.MusteriEposta == parseSession).Select(x => x.MusteriID).FirstOrDefault();

            sepet.SepetMusteriId = idGetir;

            sepet.SepetAlisTarihi = DateTime.Now;

            sepet.SepetMiktar = film.FilmKiralamaUcreti;

            sepet.SepetDurumu = true;

            film.FilmKiraDurumu = false;

            db.Sepet.Add(sepet);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id) 
        {
            Sepet sepet = db.Sepet.Find(id);
            sepet.SepetDurumu = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TeslimEt(int id) 
        {
            Sepet sepet = db.Sepet.Find(id);
            Film film = db.Film.Find(sepet.SepetFilmId);
            sepet.SepetTeslimTarihi = DateTime.Now;
            int cezaUcreti = 2;
            if ((sepet.SepetTeslimTarihi - sepet.SepetAlisTarihi).TotalDays > 7)
            {
                sepet.SepetMiktar += Convert.ToDecimal((sepet.SepetTeslimTarihi - sepet.SepetAlisTarihi).TotalDays - 7) * cezaUcreti;
            }
            film.FilmKiraDurumu = true;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}