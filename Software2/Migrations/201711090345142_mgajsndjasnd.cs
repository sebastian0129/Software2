namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgajsndjasnd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SolicitudExamen", "idPracticante", "dbo.Practicantes");
            DropIndex("dbo.SolicitudExamen", new[] { "idPracticante" });
            DropPrimaryKey("dbo.Practicantes");
            AlterColumn("dbo.Practicantes", "practicanteID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.SolicitudExamen", "idPracticante", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Practicantes", "practicanteID");
            CreateIndex("dbo.SolicitudExamen", "idPracticante");
            AddForeignKey("dbo.SolicitudExamen", "idPracticante", "dbo.Practicantes", "practicanteID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SolicitudExamen", "idPracticante", "dbo.Practicantes");
            DropIndex("dbo.SolicitudExamen", new[] { "idPracticante" });
            DropPrimaryKey("dbo.Practicantes");
            AlterColumn("dbo.SolicitudExamen", "idPracticante", c => c.Int(nullable: false));
            AlterColumn("dbo.Practicantes", "practicanteID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Practicantes", "practicanteID");
            CreateIndex("dbo.SolicitudExamen", "idPracticante");
            AddForeignKey("dbo.SolicitudExamen", "idPracticante", "dbo.Practicantes", "practicanteID", cascadeDelete: true);
        }
    }
}
