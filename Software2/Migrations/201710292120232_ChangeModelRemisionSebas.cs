namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModelRemisionSebas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Remisions", "practicanteID", "dbo.Practicantes");
            DropIndex("dbo.Remisions", new[] { "practicanteID" });
            DropColumn("dbo.Remisions", "practicanteID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Remisions", "practicanteID", c => c.Int(nullable: false));
            CreateIndex("dbo.Remisions", "practicanteID");
            AddForeignKey("dbo.Remisions", "practicanteID", "dbo.Practicantes", "practicanteID", cascadeDelete: true);
        }
    }
}
