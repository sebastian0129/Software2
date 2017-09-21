namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgcarlos2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mascotas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        fecha_nacimiento = c.DateTime(nullable: false),
                        sexo = c.Int(nullable: false),
                        color = c.Int(nullable: false),
                        raza = c.Int(nullable: false),
                        propietario = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Propietarios", t => t.propietario, cascadeDelete: true)
                .ForeignKey("dbo.Razas", t => t.raza, cascadeDelete: true)
                .Index(t => t.raza)
                .Index(t => t.propietario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mascotas", "raza", "dbo.Razas");
            DropForeignKey("dbo.Mascotas", "propietario", "dbo.Propietarios");
            DropIndex("dbo.Mascotas", new[] { "propietario" });
            DropIndex("dbo.Mascotas", new[] { "raza" });
            DropTable("dbo.Mascotas");
        }
    }
}
