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
    public class FilmMap : EntityTypeConfiguration<Film>
    {
        public FilmMap()
        {
            this.ToTable("tbl_Film");
            this.Property(p => p.FilmID).HasColumnType("int");
            this.Property(p => p.FilmID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.FilmAdi).HasColumnType("nvarchar").HasMaxLength(50);
            this.Property(p => p.FilmYayinYili).HasColumnType("date");
            this.Property(p => p.FilmKiralamaUcreti).HasPrecision(11, 2);


            this.HasRequired(p => p.Kategori).WithMany(p => p.Films).HasForeignKey(p => p.FilmKategoriId);

        }
    }
}
