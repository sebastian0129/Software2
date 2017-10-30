namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class andresm1 : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.HistoriaClinicas", "fecha_creacion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auto_Cirugia", "historia", "dbo.HistoriaClinicas");
            DropIndex("dbo.Auto_Cirugia", new[] { "historia" });
            DropColumn("dbo.HistoriaClinicas", "fecha_creacion");
            DropTable("dbo.Auto_Cirugia");
        }
    }
}
