using FilmKiralama.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmKiralama.MVC.Controllers
{
    public class KategoriController : Controller
    {
        FilmKiralamaContext db = new FilmKiralamaContext();
        // GET: Kategori
        public ActionResult Index()
        {
            List<Kategori> kategoriler = db.Kategori.Where(x => x.KategoriDurumu == true).ToList();

            return View(kategoriler);
        }

        
            public ActionResult Sil(int id)
            {
                Kategori kategori = db.Kategori.Find(id);
                kategori.KategoriDurumu = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            // Kategori Ekle

            [HttpGet]
            public ActionResult Ekle()
            {

                return View();
            }

            [HttpPost]
            public ActionResult Ekle(Kategori pKategori)
            {
                Kategori kategori = new Kategori();
                kategori.KategoriAciklama = pKategori.KategoriAciklama;
                kategori.KategoriAdi = pKategori.KategoriAdi;
                kategori.KategoriDurumu = true;
                db.Kategori.Add(kategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            [HttpGet]
            public ActionResult Guncelle(int id)
            {
                Kategori kategori = db.Kategori.Find(id);
                return View(kategori);
            }

            [HttpPost]
            public ActionResult Guncelle(Kategori pKategori)
            {
                Kategori kategori = db.Kategori.Find(pKategori.KategoriID);
                kategori.KategoriAdi = pKategori.KategoriAdi;
                kategori.KategoriAciklama = pKategori.KategoriAciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
