namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2Andresss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mascotas", "raza", "dbo.Razas");
            DropIndex("dbo.Mascotas", new[] { "raza" });
            AddColumn("dbo.Mascotas", "especie", c => c.Int(nullable: false));
            CreateIndex("dbo.Mascotas", "especie");
            AddForeignKey("dbo.Mascotas", "especie", "dbo.Especies", "id", cascadeDelete: true);
            DropColumn("dbo.Mascotas", "raza");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mascotas", "raza", c => c.Int(nullable: false));
            DropForeignKey("dbo.Mascotas", "especie", "dbo.Especies");
            DropIndex("dbo.Mascotas", new[] { "especie" });
            DropColumn("dbo.Mascotas", "especie");
            CreateIndex("dbo.Mascotas", "raza");
            AddForeignKey("dbo.Mascotas", "raza", "dbo.Razas", "id", cascadeDelete: true);
        }
    }
}
