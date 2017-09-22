namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePassword : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Practicantes", "repetirPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Practicantes", "repetirPassword", c => c.String());
        }
    }
}
