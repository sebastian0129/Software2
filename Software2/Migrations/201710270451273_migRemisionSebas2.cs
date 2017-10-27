namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migRemisionSebas2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Remisions", "fechaVacunacion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Remisions", "fechaVacunacion");
        }
    }
}
