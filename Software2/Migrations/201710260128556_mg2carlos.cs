namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg2carlos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Controls",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        historia = c.String(maxLength: 128),
                        anamnesis = c.String(nullable: false),
                        temperatura = c.Double(nullable: false),
                        fc = c.Double(nullable: false),
                        mucosas = c.String(),
                        fr = c.Double(nullable: false),
                        tiempo = c.Double(nullable: false),
                        piel = c.Int(nullable: false),
                        muscolo = c.Int(nullable: false),
                        ojos = c.Int(nullable: false),
                        cardiovascular = c.Int(nullable: false),
                        respiratorio = c.Int(nullable: false),
                        digestivo = c.Int(nullable: false),
                        genito = c.Int(nullable: false),
                        reproducor = c.Int(nullable: false),
                        nervioso = c.Int(nullable: false),
                        linfatico = c.Int(nullable: false),
                        des_piel = c.String(),
                        des_muscolo = c.String(),
                        des_ojos = c.String(),
                        des_cardiovascular = c.String(),
                        des_respiratorio = c.String(),
                        des_digestivo = c.String(),
                        des_genito = c.String(),
                        des_reproducor = c.String(),
                        des_nervioso = c.String(),
                        des_linfatico = c.String(),
                        anormalidades = c.String(),
                        problemas = c.String(),
                        ayudas = c.String(),
                        fianl = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HistoriaClinicas", t => t.historia)
                .Index(t => t.historia);
            
            CreateTable(
                "dbo.HistoriaClinicas",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Mascotas", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.Mascotas",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
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
                        mascotaID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.vacunaID)
                .ForeignKey("dbo.Mascotas", t => t.mascotaID)
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
            
            CreateTable(
                "dbo.Razas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 30),
                        idEspecie = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Especies", t => t.idEspecie, cascadeDelete: true)
                .Index(t => t.idEspecie);
            
            CreateTable(
                "dbo.Especies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.id);
            
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
                "dbo.Practicantes",
                c => new
                    {
                        practicanteID = c.Int(nullable: false),
                        nombre = c.String(nullable: false),
                        apellido = c.String(nullable: false),
                        correo = c.String(nullable: false),
                        password = c.String(nullable: false),
                        repetirPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.practicanteID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SolicitudExamen",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        numeroRecibo = c.Int(nullable: false),
                        mascota = c.String(maxLength: 128),
                        muestraRemitida = c.String(nullable: false),
                        examenSolicitado = c.String(nullable: false),
                        diagnosticoPresuntivo = c.String(nullable: false),
                        idPracticante = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Mascotas", t => t.mascota)
                .ForeignKey("dbo.Practicantes", t => t.idPracticante, cascadeDelete: true)
                .Index(t => t.mascota)
                .Index(t => t.idPracticante);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SolicitudExamen", "idPracticante", "dbo.Practicantes");
            DropForeignKey("dbo.SolicitudExamen", "mascota", "dbo.Mascotas");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Controls", "historia", "dbo.HistoriaClinicas");
            DropForeignKey("dbo.HistoriaClinicas", "id", "dbo.Mascotas");
            DropForeignKey("dbo.Mascotas", "raza", "dbo.Razas");
            DropForeignKey("dbo.Razas", "idEspecie", "dbo.Especies");
            DropForeignKey("dbo.Mascotas", "propietario", "dbo.Propietarios");
            DropForeignKey("dbo.GestionVacunacions", "mascotaID", "dbo.Mascotas");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SolicitudExamen", new[] { "idPracticante" });
            DropIndex("dbo.SolicitudExamen", new[] { "mascota" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Razas", new[] { "idEspecie" });
            DropIndex("dbo.GestionVacunacions", new[] { "mascotaID" });
            DropIndex("dbo.Mascotas", new[] { "propietario" });
            DropIndex("dbo.Mascotas", new[] { "raza" });
            DropIndex("dbo.HistoriaClinicas", new[] { "id" });
            DropIndex("dbo.Controls", new[] { "historia" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SolicitudExamen");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Practicantes");
            DropTable("dbo.Doctors");
            DropTable("dbo.Especies");
            DropTable("dbo.Razas");
            DropTable("dbo.Propietarios");
            DropTable("dbo.GestionVacunacions");
            DropTable("dbo.Mascotas");
            DropTable("dbo.HistoriaClinicas");
            DropTable("dbo.Controls");
        }
    }
}
