using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKiralama.Entities.Model
{
    public class Film
    {
        public int FilmID { get; set; }

        public string FilmAdi { get; set; }

        public DateTime FilmYayinYili { get; set; }

        public int FilmKategoriId { get; set; }

        public decimal FilmKiralamaUcreti { get; set; }

        public bool FilmDurumu { get; set; }

        public bool FilmKiraDurumu { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual ICollection<Sepet> Sepets { get; set; }
    }
}
