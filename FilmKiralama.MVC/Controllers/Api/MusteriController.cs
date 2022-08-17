using FilmKiralama.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FilmKiralama.MVC.Controllers.Api
{
    public class MusteriController : ApiController
    {
        private FilmKiralamaContext db;
        public MusteriController()
        {
            db = new FilmKiralamaContext();
        }

        public IHttpActionResult GetMusteris()
        {
            var musteris = db.Musteri.Where(x => x.MusteriDurumu == true).ToList();

            return Ok(musteris);
        }

        [HttpGet]
        public IHttpActionResult GetSepet(int id)
        {
            var musteri = db.Musteri.SingleOrDefault(x => x.MusteriID == id);
            if (musteri == null)
                return NotFound();

            return Ok(musteri);
        }

        [HttpPost]
        public IHttpActionResult AddMusteri(Musteri pMusteri)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.Musteri.Add(pMusteri);
            pMusteri.MusteriDurumu = true;
            db.SaveChanges();

            return Ok(pMusteri);
        }

        [HttpPut]
        public IHttpActionResult UpdateMusteri(int id, Musteri pMusteri)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var musteri = db.Musteri.SingleOrDefault(x => x.MusteriID == id);
            if (musteri == null)
                return NotFound();

            musteri.MusteriAdi = pMusteri.MusteriAdi;
            musteri.MusteriSoyadi = pMusteri.MusteriSoyadi;
            musteri.MusteriCinsiyeti = pMusteri.MusteriCinsiyeti;
            musteri.MusteriDogumTarihi = pMusteri.MusteriDogumTarihi;

            db.SaveChanges();
            return Ok(musteri);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMusteri(int id)
        {
            var musteri = db.Musteri.SingleOrDefault(x => x.MusteriID == id);

            if (musteri == null)
                return NotFound();

            musteri.MusteriDurumu = false;
            db.SaveChanges();

            return Ok();
        }
    }
}
