using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKiralama.Entities.Model
{
    public class Sepet
    {
        public int SepetID { get; set; }

        public int SepetMusteriId { get; set; }

        public int SepetFilmId { get; set; }

        public DateTime SepetAlisTarihi { get; set; }

        public DateTime SepetTeslimTarihi { get; set; }

        public decimal SepetMiktar { get; set; }

        public bool SepetDurumu { get; set; }


        public virtual Musteri Musteri { get; set; }

        public virtual Film Film { get; set; }
    }
}
