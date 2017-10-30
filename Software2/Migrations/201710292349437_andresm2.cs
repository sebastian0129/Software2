namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class andresm2 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auto_Necropsia", "historia", "dbo.HistoriaClinicas");
            DropIndex("dbo.Auto_Necropsia", new[] { "historia" });
            DropTable("dbo.Auto_Necropsia");
        }
    }
}
