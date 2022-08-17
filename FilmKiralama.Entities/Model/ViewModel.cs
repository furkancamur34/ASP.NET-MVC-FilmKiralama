using FilmKiralama.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmKiralama.Entities.Model
{
    public class ViewModel
    {
        FilmKiralamaContext db = new FilmKiralamaContext();

        public IEnumerable<Kategori> Kategoriler;

        public IEnumerable<Film> Filmler;
    }
}