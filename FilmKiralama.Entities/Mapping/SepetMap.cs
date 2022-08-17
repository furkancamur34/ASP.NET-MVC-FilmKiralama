using FilmKiralama.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKiralama.Entities.Mapping
{
    public class SepetMap : EntityTypeConfiguration<Sepet>
    {
        public SepetMap()
        {
            this.ToTable("tbl_Sepet");
            this.Property(p => p.SepetID).HasColumnType("int");
            this.Property(p => p.SepetID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.SepetAlisTarihi).HasColumnType("date");
            this.Property(p => p.SepetTeslimTarihi).HasColumnType("date");
            this.Property(p => p.SepetMiktar).HasPrecision(11, 2);


            this.HasRequired(p => p.Musteri).WithMany(p => p.Sepets).HasForeignKey(p => p.SepetMusteriId);
            this.HasRequired(p => p.Film).WithMany(p => p.Sepets).HasForeignKey(p => p.SepetFilmId);


        }
    }
}
