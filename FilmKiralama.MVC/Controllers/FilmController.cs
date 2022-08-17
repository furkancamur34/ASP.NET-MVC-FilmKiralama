
using FilmKiralama.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace FilmKiralama.MVC.Controllers
{

    public class FilmController : Controller
    {
        FilmKiralamaContext db = new FilmKiralamaContext();
        // GET: Film
        public ActionResult Index()
        {

            ViewModel vm = new ViewModel();

            string parseSession = (string)Session["MusteriEposta"];

            var idGetir = db.Musteri.Where(x => x.MusteriEposta == parseSession).Select(x => x.MusteriID).FirstOrDefault();

            vm.Filmler = db.Film.AsNoTracking().Where(x=>x.FilmDurumu==true && x.FilmKiraDurumu==true).Include(x => x.Kategori).ToList();

            vm.Kategoriler = db.Kategori.AsNoTracking().Where(x => x.KategoriDurumu == true).ToList();

            return View(vm);
        }

        public ActionResult Sil(int id)
        {
            Film film = db.Film.Find(id);
            film.FilmDurumu = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Ekle() 
        {
            List<SelectListItem> kategoriler = db.Kategori.AsNoTracking().Where(x => x.KategoriDurumu == true)
                                    .Select(s => new SelectListItem
                                    {
                                        Value = s.KategoriID.ToString(),
                                        Text = s.KategoriAdi
                                    }).ToList();

            ViewBag.Kategoriler = kategoriler;

            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Film pFilm) 
        {
            
            pFilm.FilmDurumu = true;
            pFilm.FilmKiraDurumu = true;
            db.Film.Add(pFilm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Film film = db.Film.Find(id);

            List<SelectListItem> kategoriler = db.Kategori.AsNoTracking().Where(x => x.KategoriDurumu == true)
                                    .Select(s => new SelectListItem
                                    {
                                        Value = s.KategoriID.ToString(),
                                        Text = s.KategoriAdi
                                    }).ToList();

            ViewBag.Kategoriler = kategoriler;

            return View(film);

        }

        [HttpPost]
        public ActionResult Guncelle(Film pFilm) 
        {
            Film film = new Film();
            film = db.Film.Where(x => x.FilmID == pFilm.FilmID).SingleOrDefault();

            if (pFilm!=null)
            {
                film.FilmAdi = pFilm.FilmAdi;
                film.FilmKiralamaUcreti = pFilm.FilmKiralamaUcreti;
                film.FilmYayinYili = pFilm.FilmYayinYili;
                film.Kategori = db.Kategori.Find(pFilm.Kategori.KategoriID);

                db.SaveChanges();
            }
                
            
            return RedirectToAction("Index");
        }

        

        

        

    }
}