namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyMascotaSebas : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Mascotas", name: "propietario", newName: "propietarioID");
            RenameIndex(table: "dbo.Mascotas", name: "IX_propietario", newName: "IX_propietarioID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Mascotas", name: "IX_propietarioID", newName: "IX_propietario");
            RenameColumn(table: "dbo.Mascotas", name: "propietarioID", newName: "propietario");
        }
    }
}
