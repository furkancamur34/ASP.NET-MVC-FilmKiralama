using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKiralama.Entities.Model
{
    public class Musteri
    {
        public int MusteriID { get; set; }

        public string MusteriAdi { get; set; }

        public string MusteriSoyadi { get; set; }

        public string MusteriCinsiyeti { get; set; }

        public DateTime MusteriDogumTarihi { get; set; }

        public bool MusteriDurumu { get; set; }

        public string MusteriEposta { get; set; }

        public string MusteriSifre { get; set; }

        public virtual ICollection<Sepet> Sepets { get; set; }
    }
}
