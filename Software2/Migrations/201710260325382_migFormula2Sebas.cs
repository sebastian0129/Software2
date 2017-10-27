namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migFormula2Sebas : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.GestionVacunacions", "Mascota_id", c => c.Int());
            DropForeignKey("dbo.GestionVacunacions", "mascotaID", "dbo.Mascotas");
            DropForeignKey("dbo.Formulae", "mascotaID", "dbo.Mascotas");
            DropIndex("dbo.GestionVacunacions", new[] { "mascotaID" });
            AlterColumn("dbo.GestionVacunacions", "mascotaID", c => c.Int());
            RenameColumn(table: "dbo.GestionVacunacions", name: "mascotaID", newName: "Mascota_id1");
            RenameColumn(table: "dbo.Formulae", name: "mascotaID", newName: "Mascota_id");
            AddColumn("dbo.Formulae", "mascotaID", c => c.Int(nullable: false));
            AddColumn("dbo.GestionVacunacions", "mascotaID", c => c.Int(nullable: false));
            CreateIndex("dbo.GestionVacunacions", "Mascota_id1");
            CreateIndex("dbo.GestionVacunacions", "Mascota_id");
            CreateIndex("dbo.GestionVacunacions", "mascotaID");
            AddForeignKey("dbo.GestionVacunacions", "Mascota_id1", "dbo.Mascotas", "id");
            AddForeignKey("dbo.GestionVacunacions", "Mascota_id", "dbo.Mascotas", "id");
        }
    }
}
