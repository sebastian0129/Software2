namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class andresm3a : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auto_Eutanasia", "historia", "dbo.HistoriaClinicas");
            DropForeignKey("dbo.Auto_Consentimiento", "historia", "dbo.HistoriaClinicas");
            DropIndex("dbo.Auto_Eutanasia", new[] { "historia" });
            DropIndex("dbo.Auto_Consentimiento", new[] { "historia" });
            DropTable("dbo.Auto_Eutanasia");
            DropTable("dbo.Auto_Consentimiento");
        }
    }
}
