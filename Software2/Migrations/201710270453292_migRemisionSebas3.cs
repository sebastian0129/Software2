namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migRemisionSebas3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Remisions", "fechaRemision", c => c.DateTime(nullable: false));
            DropColumn("dbo.Remisions", "fechaVacunacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Remisions", "fechaVacunacion", c => c.DateTime(nullable: false));
            DropColumn("dbo.Remisions", "fechaRemision");
        }
    }
}
