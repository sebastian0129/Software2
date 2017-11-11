namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1andres10112017 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SolicitudExamen", "idPracticante", "dbo.Practicantes");
            DropIndex("dbo.SolicitudExamen", new[] { "idPracticante" });
            DropPrimaryKey("dbo.Practicantes");
            CreateTable(
                "dbo.Administradors",
                c => new
                    {
                        adminID = c.String(nullable: false, maxLength: 128),
                        nombre = c.String(nullable: false),
                        apellido = c.String(nullable: false),
                        correo = c.String(nullable: false),
                        password = c.String(nullable: false),
                        repetirPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.adminID);
            
            CreateTable(
                "dbo.Auto_Cirugia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        observaciones = c.String(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        historia = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HistoriaClinicas", t => t.historia)
                .Index(t => t.historia);
            
            CreateTable(
                "dbo.Formulae",
                c => new
                    {
                        formulaID = c.Int(nullable: false, identity: true),
                        mascotaID = c.String(maxLength: 128),
                        fecha = c.DateTime(nullable: false),
                        practicanteID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.formulaID)
                .ForeignKey("dbo.Mascotas", t => t.mascotaID)
                .ForeignKey("dbo.Practicantes", t => t.practicanteID)
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
            
            CreateTable(
                "dbo.Remisions",
                c => new
                    {
                        remisionID = c.Int(nullable: false, identity: true),
                        fechaRemision = c.DateTime(nullable: false),
                        mascotaID = c.String(maxLength: 128),
                        practicanteID = c.String(maxLength: 128),
                        region = c.String(nullable: false),
                        vista = c.String(nullable: false),
                        diagnostico = c.String(nullable: false),
                        ecografia = c.String(nullable: false),
                        evaluacion = c.String(nullable: false),
                        resultado = c.String(nullable: false),
                        observacion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.remisionID)
                .ForeignKey("dbo.Mascotas", t => t.mascotaID)
                .ForeignKey("dbo.Practicantes", t => t.practicanteID)
                .Index(t => t.mascotaID)
                .Index(t => t.practicanteID);
            
            CreateTable(
                "dbo.Auto_Consentimiento",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        valor = c.Double(nullable: false),
                        interes = c.Double(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        historia = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HistoriaClinicas", t => t.historia)
                .Index(t => t.historia);
            
            CreateTable(
                "dbo.Auto_Eutanasia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        causa = c.String(nullable: false),
                        seccion = c.String(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        historia = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HistoriaClinicas", t => t.historia)
                .Index(t => t.historia);
            
            CreateTable(
                "dbo.Auto_Necropsia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Diagnostico = c.String(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        historia = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HistoriaClinicas", t => t.historia)
                .Index(t => t.historia);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        medicoID = c.String(nullable: false, maxLength: 128),
                        nombre = c.String(nullable: false),
                        apellido = c.String(nullable: false),
                        correo = c.String(nullable: false),
                        password = c.String(nullable: false),
                        repetirPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.medicoID);
            
            AddColumn("dbo.Controls", "masacorporal", c => c.Double(nullable: false));
            AlterColumn("dbo.Practicantes", "practicanteID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.SolicitudExamen", "idPracticante", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Practicantes", "practicanteID");
            CreateIndex("dbo.SolicitudExamen", "idPracticante");
            AddForeignKey("dbo.SolicitudExamen", "idPracticante", "dbo.Practicantes", "practicanteID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SolicitudExamen", "idPracticante", "dbo.Practicantes");
            DropForeignKey("dbo.Auto_Necropsia", "historia", "dbo.HistoriaClinicas");
            DropForeignKey("dbo.Auto_Eutanasia", "historia", "dbo.HistoriaClinicas");
            DropForeignKey("dbo.Auto_Consentimiento", "historia", "dbo.HistoriaClinicas");
            DropForeignKey("dbo.Auto_Cirugia", "historia", "dbo.HistoriaClinicas");
            DropForeignKey("dbo.Remisions", "practicanteID", "dbo.Practicantes");
            DropForeignKey("dbo.Remisions", "mascotaID", "dbo.Mascotas");
            DropForeignKey("dbo.Formulae", "practicanteID", "dbo.Practicantes");
            DropForeignKey("dbo.Medicamentoes", "Formula_formulaID", "dbo.Formulae");
            DropForeignKey("dbo.Formulae", "mascotaID", "dbo.Mascotas");
            DropIndex("dbo.SolicitudExamen", new[] { "idPracticante" });
            DropIndex("dbo.Auto_Necropsia", new[] { "historia" });
            DropIndex("dbo.Auto_Eutanasia", new[] { "historia" });
            DropIndex("dbo.Auto_Consentimiento", new[] { "historia" });
            DropIndex("dbo.Remisions", new[] { "practicanteID" });
            DropIndex("dbo.Remisions", new[] { "mascotaID" });
            DropIndex("dbo.Medicamentoes", new[] { "Formula_formulaID" });
            DropIndex("dbo.Formulae", new[] { "practicanteID" });
            DropIndex("dbo.Formulae", new[] { "mascotaID" });
            DropIndex("dbo.Auto_Cirugia", new[] { "historia" });
            DropPrimaryKey("dbo.Practicantes");
            AlterColumn("dbo.SolicitudExamen", "idPracticante", c => c.Int(nullable: false));
            AlterColumn("dbo.Practicantes", "practicanteID", c => c.Int(nullable: false));
            DropColumn("dbo.Controls", "masacorporal");
            DropTable("dbo.Medicos");
            DropTable("dbo.Auto_Necropsia");
            DropTable("dbo.Auto_Eutanasia");
            DropTable("dbo.Auto_Consentimiento");
            DropTable("dbo.Remisions");
            DropTable("dbo.Medicamentoes");
            DropTable("dbo.Formulae");
            DropTable("dbo.Auto_Cirugia");
            DropTable("dbo.Administradors");
            AddPrimaryKey("dbo.Practicantes", "practicanteID");
            CreateIndex("dbo.SolicitudExamen", "idPracticante");
            AddForeignKey("dbo.SolicitudExamen", "idPracticante", "dbo.Practicantes", "practicanteID", cascadeDelete: true);
        }
    }
}
