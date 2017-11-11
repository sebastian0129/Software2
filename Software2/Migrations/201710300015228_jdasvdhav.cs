namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jdasvdhav : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Monitoreos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        historia = c.String(maxLength: 128),
                        peso = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HistoriaClinicas", t => t.historia)
                .Index(t => t.historia);
            
            CreateTable(
                "dbo.MonitoreoPacientes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha_hora = c.DateTime(nullable: false),
                        temperatura = c.Double(nullable: false),
                        pulso = c.Double(nullable: false),
                        trc = c.String(),
                        fr = c.Double(nullable: false),
                        peritaltismo = c.String(),
                        mucosas = c.String(),
                        observacion = c.String(),
                        monitoreoFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Monitoreos", t => t.monitoreoFk, cascadeDelete: true)
                .Index(t => t.monitoreoFk);
            
            CreateTable(
                "dbo.PlanTerapeuticoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha_hora = c.DateTime(nullable: false),
                        tipo = c.Int(nullable: false),
                        nombre = c.String(),
                        observacion = c.String(),
                        monitoreoFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Monitoreos", t => t.monitoreoFk, cascadeDelete: true)
                .Index(t => t.monitoreoFk);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlanTerapeuticoes", "monitoreoFk", "dbo.Monitoreos");
            DropForeignKey("dbo.MonitoreoPacientes", "monitoreoFk", "dbo.Monitoreos");
            DropForeignKey("dbo.Monitoreos", "historia", "dbo.HistoriaClinicas");
            DropIndex("dbo.PlanTerapeuticoes", new[] { "monitoreoFk" });
            DropIndex("dbo.MonitoreoPacientes", new[] { "monitoreoFk" });
            DropIndex("dbo.Monitoreos", new[] { "historia" });
            DropTable("dbo.PlanTerapeuticoes");
            DropTable("dbo.MonitoreoPacientes");
            DropTable("dbo.Monitoreos");
        }
    }
}
