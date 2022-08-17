using FilmKiralama.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FilmKiralama.MVC.Controllers.Api
{
    public class SepetController : ApiController
    {
        private FilmKiralamaContext db;
        public SepetController()
        {
            db = new FilmKiralamaContext();
        }

        public IHttpActionResult GetSepets()
        {
            var sepets = db.Sepet.Where(x => x.SepetDurumu == true).ToList();

            return Ok(sepets);
        }

        [HttpGet]
        public IHttpActionResult GetSepet(int id)
        {
            var sepet = db.Sepet.SingleOrDefault(x => x.SepetID == id);
            if (sepet == null)
                return NotFound();

            return Ok(sepet);
        }

        [HttpPost]
        public IHttpActionResult AddSepet(Sepet pSepet)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            db.Sepet.Add(pSepet);
            pSepet.SepetDurumu = true;
            db.SaveChanges();

            return Ok(pSepet);
        }

        [HttpPut]
        public IHttpActionResult UpdateSepet(int id, Sepet pSepet)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sepet = db.Sepet.SingleOrDefault(x => x.SepetID == id);
            if (sepet == null)
                return NotFound();


            sepet.SepetMusteriId = pSepet.SepetMusteriId;
            sepet.SepetFilmId = pSepet.SepetFilmId;
            sepet.SepetAlisTarihi = pSepet.SepetAlisTarihi;
            sepet.SepetTeslimTarihi = pSepet.SepetTeslimTarihi;
            sepet.SepetMiktar = pSepet.SepetMiktar;

            db.SaveChanges();
            return Ok(sepet);
        }

        [HttpDelete]
        public IHttpActionResult DeleteSepet(int id)
        {
            var sepet = db.Sepet.SingleOrDefault(x => x.SepetID == id);

            if (sepet == null)
                return NotFound();

            sepet.SepetDurumu = false;
            db.SaveChanges();

            return Ok();
        }
    }
}
