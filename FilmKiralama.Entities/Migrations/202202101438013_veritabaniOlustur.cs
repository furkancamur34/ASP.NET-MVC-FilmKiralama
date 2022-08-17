namespace FilmKiralama.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class veritabaniOlustur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Film",
                c => new
                    {
                        FilmID = c.Int(nullable: false, identity: true),
                        FilmAdi = c.String(maxLength: 50),
                        FilmYayinYili = c.DateTime(nullable: false, storeType: "date"),
                        FilmKategoriId = c.Int(nullable: false),
                        FilmKiralamaUcreti = c.Decimal(nullable: false, precision: 11, scale: 2),
                    })
                .PrimaryKey(t => t.FilmID)
                .ForeignKey("dbo.tblKategori", t => t.FilmKategoriId, cascadeDelete: true)
                .Index(t => t.FilmKategoriId);
            
            CreateTable(
                "dbo.tblKategori",
                c => new
                    {
                        KategoriID = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(maxLength: 100, unicode: false),
                        KategoriAciklama = c.String(maxLength: 500, unicode: false),
                        KategoriDurumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KategoriID);
            
            CreateTable(
                "dbo.tbl_Sepet",
                c => new
                    {
                        SepetID = c.Int(nullable: false, identity: true),
                        SepetMusteriId = c.Int(nullable: false),
                        SepetFilmId = c.Int(nullable: false),
                        SepetAlisTarihi = c.DateTime(nullable: false, storeType: "date"),
                        SepetTeslimTarihi = c.DateTime(nullable: false, storeType: "date"),
                        SepetMiktar = c.Decimal(nullable: false, precision: 11, scale: 2),
                        SepetDurumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SepetID)
                .ForeignKey("dbo.tbl_Film", t => t.SepetFilmId, cascadeDelete: true)
                .ForeignKey("dbo.tbl_Musteri", t => t.SepetMusteriId, cascadeDelete: true)
                .Index(t => t.SepetMusteriId)
                .Index(t => t.SepetFilmId);
            
            CreateTable(
                "dbo.tbl_Musteri",
                c => new
                    {
                        MusteriID = c.Int(nullable: false, identity: true),
                        MusteriAdi = c.String(maxLength: 100, unicode: false),
                        MusteriSoyadi = c.String(maxLength: 100, unicode: false),
                        MusteriCinsiyeti = c.String(maxLength: 10, unicode: false),
                        MusteriDogumTarihi = c.DateTime(nullable: false, storeType: "date"),
                        MusteriDurumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MusteriID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Sepet", "SepetMusteriId", "dbo.tbl_Musteri");
            DropForeignKey("dbo.tbl_Sepet", "SepetFilmId", "dbo.tbl_Film");
            DropForeignKey("dbo.tbl_Film", "FilmKategoriId", "dbo.tblKategori");
            DropIndex("dbo.tbl_Sepet", new[] { "SepetFilmId" });
            DropIndex("dbo.tbl_Sepet", new[] { "SepetMusteriId" });
            DropIndex("dbo.tbl_Film", new[] { "FilmKategoriId" });
            DropTable("dbo.tbl_Musteri");
            DropTable("dbo.tbl_Sepet");
            DropTable("dbo.tblKategori");
            DropTable("dbo.tbl_Film");
        }
    }
}
