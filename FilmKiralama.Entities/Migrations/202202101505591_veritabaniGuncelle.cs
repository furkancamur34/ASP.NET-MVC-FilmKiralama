﻿namespace FilmKiralama.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class veritabaniGuncelle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Film", "FilmDurumu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Film", "FilmDurumu");
        }
    }
}
