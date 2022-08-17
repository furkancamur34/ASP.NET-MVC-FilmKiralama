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
    public class MusteriMap : EntityTypeConfiguration<Musteri>
    {
        public MusteriMap()
        {
            this.ToTable("tbl_Musteri");
            this.Property(p => p.MusteriID).HasColumnType("int");
            this.Property(p => p.MusteriID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.MusteriAdi).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.MusteriSoyadi).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.MusteriCinsiyeti).HasColumnType("varchar").HasMaxLength(10);
            this.Property(p => p.MusteriDogumTarihi).HasColumnType("date");
            this.Property(p => p.MusteriEposta).HasColumnType("varchar").HasMaxLength(150);
            this.Property(p => p.MusteriSifre).HasColumnType("varchar").HasMaxLength(16);

        }
    }
}
