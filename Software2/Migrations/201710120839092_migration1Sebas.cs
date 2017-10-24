namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1Sebas : DbMigration
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
            
            CreateTable(
                "dbo.GestionVacunacions",
                c => new
                    {
                        vacunaID = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        fechaVacunacion = c.DateTime(nullable: false),
                        dosis = c.Double(nullable: false),
                        lote = c.Double(nullable: false),
                        mascotaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.vacunaID)
                .ForeignKey("dbo.Mascotas", t => t.mascotaID, cascadeDelete: true)
                .Index(t => t.mascotaID);
            
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
            DropForeignKey("dbo.Mascotas", "raza", "dbo.Razas");
            DropForeignKey("dbo.Mascotas", "propietario", "dbo.Propietarios");
            DropForeignKey("dbo.GestionVacunacions", "mascotaID", "dbo.Mascotas");
            DropIndex("dbo.GestionVacunacions", new[] { "mascotaID" });
            DropIndex("dbo.Mascotas", new[] { "propietario" });
            DropIndex("dbo.Mascotas", new[] { "raza" });
            DropTable("dbo.Propietarios");
            DropTable("dbo.GestionVacunacions");
            DropTable("dbo.Mascotas");
            DropTable("dbo.Doctors");
        }
    }
}
