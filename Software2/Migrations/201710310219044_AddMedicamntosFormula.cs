namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMedicamntosFormula : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medicamentoes", "Formula_formulaID", "dbo.Formulae");
            DropForeignKey("dbo.Formulae", "practicanteID", "dbo.Practicantes");
            DropIndex("dbo.Formulae", new[] { "practicanteID" });
            DropIndex("dbo.Medicamentoes", new[] { "Formula_formulaID" });
            CreateTable(
                "dbo.MedicamentosFormulas",
                c => new
                    {
                        formulaID = c.Int(nullable: false),
                        MedicamentoID = c.Int(nullable: false),
                        frecuenciaHora = c.String(),
                        dosis = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.formulaID, t.MedicamentoID })
                .ForeignKey("dbo.Formulae", t => t.formulaID, cascadeDelete: true)
                .ForeignKey("dbo.Medicamentoes", t => t.MedicamentoID, cascadeDelete: true)
                .Index(t => t.formulaID)
                .Index(t => t.MedicamentoID);
            
            AddColumn("dbo.Medicamentoes", "expresion", c => c.Int(nullable: false));
            DropColumn("dbo.Formulae", "practicanteID");
            DropColumn("dbo.Medicamentoes", "dosis");
            DropColumn("dbo.Medicamentoes", "frecuencia");
            DropColumn("dbo.Medicamentoes", "cantidad");
            DropColumn("dbo.Medicamentoes", "Formula_formulaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicamentoes", "Formula_formulaID", c => c.Int());
            AddColumn("dbo.Medicamentoes", "cantidad", c => c.Int(nullable: false));
            AddColumn("dbo.Medicamentoes", "frecuencia", c => c.String());
            AddColumn("dbo.Medicamentoes", "dosis", c => c.Int(nullable: false));
            AddColumn("dbo.Formulae", "practicanteID", c => c.Int(nullable: false));
            DropForeignKey("dbo.MedicamentosFormulas", "MedicamentoID", "dbo.Medicamentoes");
            DropForeignKey("dbo.MedicamentosFormulas", "formulaID", "dbo.Formulae");
            DropIndex("dbo.MedicamentosFormulas", new[] { "MedicamentoID" });
            DropIndex("dbo.MedicamentosFormulas", new[] { "formulaID" });
            DropColumn("dbo.Medicamentoes", "expresion");
            DropTable("dbo.MedicamentosFormulas");
            CreateIndex("dbo.Medicamentoes", "Formula_formulaID");
            CreateIndex("dbo.Formulae", "practicanteID");
            AddForeignKey("dbo.Formulae", "practicanteID", "dbo.Practicantes", "practicanteID", cascadeDelete: true);
            AddForeignKey("dbo.Medicamentoes", "Formula_formulaID", "dbo.Formulae", "formulaID");
        }
    }
}
