namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgcarlos1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Propietarios",
                c => new
                    {
                        cedula = c.Long(nullable: false),
                        nombre = c.String(nullable: false),
                        apellido = c.String(nullable: false),
                        celular = c.String(nullable: false),
                        correo = c.String(),
                    })
                .PrimaryKey(t => t.cedula);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Propietarios");
        }
    }
}
