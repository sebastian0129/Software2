namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyPropietarioSebas : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Mascotas", name: "propietarioID", newName: "propietario");
            RenameIndex(table: "dbo.Mascotas", name: "IX_propietarioID", newName: "IX_propietario");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Mascotas", name: "IX_propietario", newName: "IX_propietarioID");
            RenameColumn(table: "dbo.Mascotas", name: "propietario", newName: "propietarioID");
        }
    }
}
