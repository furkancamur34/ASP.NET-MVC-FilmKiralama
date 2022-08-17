namespace FilmKiralama.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class musteriLogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Musteri", "MusteriEposta", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.tbl_Musteri", "MusteriSifre", c => c.String(maxLength: 16, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Musteri", "MusteriSifre");
            DropColumn("dbo.tbl_Musteri", "MusteriEposta");
        }
    }
}
