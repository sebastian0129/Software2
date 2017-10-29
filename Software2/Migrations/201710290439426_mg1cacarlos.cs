namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1cacarlos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HistoriaClinicas", "fecha_creacion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HistoriaClinicas", "fecha_creacion");
        }
    }
}
