namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1cahcbh : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Controls", "fianl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Controls", "fianl", c => c.String());
        }
    }
}
