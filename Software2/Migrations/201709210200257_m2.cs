namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Razas", "Especie_id", "dbo.Especies");
            DropIndex("dbo.Razas", new[] { "Especie_id" });
            RenameColumn(table: "dbo.Razas", name: "Especie_id", newName: "idEspecie");
            AddColumn("dbo.Razas", "nombre", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Razas", "idEspecie", c => c.Int(nullable: false));
            CreateIndex("dbo.Razas", "idEspecie");
            AddForeignKey("dbo.Razas", "idEspecie", "dbo.Especies", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Razas", "idEspecie", "dbo.Especies");
            DropIndex("dbo.Razas", new[] { "idEspecie" });
            AlterColumn("dbo.Razas", "idEspecie", c => c.Int());
            DropColumn("dbo.Razas", "nombre");
            RenameColumn(table: "dbo.Razas", name: "idEspecie", newName: "Especie_id");
            CreateIndex("dbo.Razas", "Especie_id");
            AddForeignKey("dbo.Razas", "Especie_id", "dbo.Especies", "id");
        }
    }
}
