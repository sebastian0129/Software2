namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgajsndjasndsda : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medicos");
            DropTable("dbo.Administradors");
        }
    }
}
