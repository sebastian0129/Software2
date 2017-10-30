namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1andresm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Controls", "masacorporal", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Controls", "masacorporal");
        }
    }
}
