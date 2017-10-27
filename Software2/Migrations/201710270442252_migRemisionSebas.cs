namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migRemisionSebas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Remisions",
                c => new
                    {
                        remisionID = c.Int(nullable: false, identity: true),
                        mascotaID = c.Int(nullable: false),
                        practicanteID = c.Int(nullable: false),
                        region = c.String(nullable: false),
                        vista = c.String(nullable: false),
                        diagnostico = c.String(nullable: false),
                        ecografia = c.String(nullable: false),
                        evaluacion = c.String(nullable: false),
                        resultado = c.String(nullable: false),
                        observacion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.remisionID)
                .ForeignKey("dbo.Mascotas", t => t.mascotaID, cascadeDelete: true)
                .ForeignKey("dbo.Practicantes", t => t.practicanteID, cascadeDelete: true)
                .Index(t => t.mascotaID)
                .Index(t => t.practicanteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Remisions", "practicanteID", "dbo.Practicantes");
            DropForeignKey("dbo.Remisions", "mascotaID", "dbo.Mascotas");
            DropIndex("dbo.Remisions", new[] { "practicanteID" });
            DropIndex("dbo.Remisions", new[] { "mascotaID" });
            DropTable("dbo.Remisions");
        }
    }
}
