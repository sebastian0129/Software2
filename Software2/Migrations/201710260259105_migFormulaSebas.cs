
namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migFormulaSebas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GestionVacunacions", "mascotaID", "dbo.Mascotas");
            CreateTable(
                "dbo.Formulae",
                c => new
                    {
                        formulaID = c.Int(nullable: false, identity: true),
                        mascotaID = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        practicanteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.formulaID)
                .ForeignKey("dbo.Mascotas", t => t.mascotaID, cascadeDelete: true)
                .ForeignKey("dbo.Practicantes", t => t.practicanteID, cascadeDelete: true)
                .Index(t => t.mascotaID)
                .Index(t => t.practicanteID);
            
            CreateTable(
                "dbo.Medicamentoes",
                c => new
                    {
                        medicamentoID = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        dosis = c.Int(nullable: false),
                        lote = c.Int(nullable: false),
                        viaSuministro = c.Int(nullable: false),
                        frecuencia = c.String(),
                        cantidad = c.Int(nullable: false),
                        Formula_formulaID = c.Int(),
                    })
                .PrimaryKey(t => t.medicamentoID)
                .ForeignKey("dbo.Formulae", t => t.Formula_formulaID)
                .Index(t => t.Formula_formulaID);
            
            AddColumn("dbo.GestionVacunacions", "Mascota_id", c => c.Int());
            AddColumn("dbo.GestionVacunacions", "Mascota_id1", c => c.Int());
            CreateIndex("dbo.GestionVacunacions", "Mascota_id");
            CreateIndex("dbo.GestionVacunacions", "Mascota_id1");
            AddForeignKey("dbo.GestionVacunacions", "Mascota_id", "dbo.Mascotas", "id");
            AddForeignKey("dbo.GestionVacunacions", "Mascota_id1", "dbo.Mascotas", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GestionVacunacions", "Mascota_id1", "dbo.Mascotas");
            DropForeignKey("dbo.Formulae", "practicanteID", "dbo.Practicantes");
            DropForeignKey("dbo.Medicamentoes", "Formula_formulaID", "dbo.Formulae");
            DropForeignKey("dbo.Formulae", "mascotaID", "dbo.Mascotas");
            DropForeignKey("dbo.GestionVacunacions", "Mascota_id", "dbo.Mascotas");
            DropIndex("dbo.Medicamentoes", new[] { "Formula_formulaID" });
            DropIndex("dbo.Formulae", new[] { "practicanteID" });
            DropIndex("dbo.Formulae", new[] { "mascotaID" });
            DropIndex("dbo.GestionVacunacions", new[] { "Mascota_id1" });
            DropIndex("dbo.GestionVacunacions", new[] { "Mascota_id" });
            DropColumn("dbo.GestionVacunacions", "Mascota_id1");
            DropColumn("dbo.GestionVacunacions", "Mascota_id");
            DropTable("dbo.Medicamentoes");
            DropTable("dbo.Formulae");
            AddForeignKey("dbo.GestionVacunacions", "mascotaID", "dbo.Mascotas", "id", cascadeDelete: true);
        }
    }
}
