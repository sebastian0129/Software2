namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class esteban2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        cedula = c.String(nullable: false, maxLength: 15),
                        nombre = c.String(nullable: false),
                        apellido = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.cedula);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Doctors");
        }
    }
}
