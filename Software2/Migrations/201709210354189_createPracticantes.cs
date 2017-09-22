namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createPracticantes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Practicantes",
                c => new
                    {
                        practicanteID = c.Int(nullable: false),
                        nombre = c.String(nullable: false),
                        apellido = c.String(nullable: false),
                        correo = c.String(nullable: false),
                        password = c.String(nullable: false),
                        repetirPassword = c.String(),
                    })
                .PrimaryKey(t => t.practicanteID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Practicantes");
        }
    }
}
