namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeSetPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Practicantes", "repetirPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Practicantes", "repetirPassword");
        }
    }
}
