using FilmKiralama.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmKiralama.MVC.Controllers
{
    public class MusteriController : Controller
    {
        FilmKiralamaContext db = new FilmKiralamaContext();
        // GET: Musteri

        public ActionResult Index()
        {
            List<Musteri> musteriler = db.Musteri.Where(x => x.MusteriDurumu == true).ToList();
            return View(musteriler);

        }

        public ActionResult Sil(int id)
        {
            Musteri musteri = db.Musteri.Find(id);
            musteri.MusteriDurumu = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Ekle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Musteri pMusteri)
        {
            pMusteri.MusteriDurumu = true;
            db.Musteri.Add(pMusteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Musteri musteri = db.Musteri.Find(id);

            return View(musteri);
        }

        [HttpPost]
        public ActionResult Guncelle(Musteri pMusteri)
        {
            Musteri musteri = db.Musteri.Find(pMusteri.MusteriID);
            musteri.MusteriAdi = pMusteri.MusteriAdi;
            musteri.MusteriSoyadi = pMusteri.MusteriSoyadi;
            musteri.MusteriCinsiyeti = pMusteri.MusteriCinsiyeti;
            musteri.MusteriDogumTarihi = pMusteri.MusteriDogumTarihi;
            musteri.MusteriEposta = pMusteri.MusteriEposta;
            musteri.MusteriSifre = pMusteri.MusteriSifre;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}