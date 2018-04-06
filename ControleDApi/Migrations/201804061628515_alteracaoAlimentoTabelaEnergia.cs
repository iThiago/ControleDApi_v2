namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracaoAlimentoTabelaEnergia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Energias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        kcal = c.String(),
                        kj = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Alimentoes", "classificacao", c => c.Int(nullable: false));
            AddColumn("dbo.Alimentoes", "umidade", c => c.String());
            AddColumn("dbo.Alimentoes", "proteina", c => c.String());
            AddColumn("dbo.Alimentoes", "lipideos", c => c.String());
            AddColumn("dbo.Alimentoes", "colesterol", c => c.String());
            AddColumn("dbo.Alimentoes", "carboidrato", c => c.String());
            AddColumn("dbo.Alimentoes", "fibra_alimentar", c => c.String());
            AddColumn("dbo.Alimentoes", "cinzas", c => c.String());
            AddColumn("dbo.Alimentoes", "calcio", c => c.String());
            AddColumn("dbo.Alimentoes", "magnesio", c => c.String());
            AddColumn("dbo.Alimentoes", "manganes", c => c.String());
            AddColumn("dbo.Alimentoes", "fosforo", c => c.String());
            AddColumn("dbo.Alimentoes", "ferro", c => c.String());
            AddColumn("dbo.Alimentoes", "sodio", c => c.String());
            AddColumn("dbo.Alimentoes", "potassio", c => c.String());
            AddColumn("dbo.Alimentoes", "cobre", c => c.String());
            AddColumn("dbo.Alimentoes", "zinco", c => c.String());
            AddColumn("dbo.Alimentoes", "retinol", c => c.String());
            AddColumn("dbo.Alimentoes", "re", c => c.String());
            AddColumn("dbo.Alimentoes", "rae", c => c.String());
            AddColumn("dbo.Alimentoes", "tiamina", c => c.String());
            AddColumn("dbo.Alimentoes", "riboflavina", c => c.String());
            AddColumn("dbo.Alimentoes", "piridoxina", c => c.String());
            AddColumn("dbo.Alimentoes", "niacina", c => c.String());
            AddColumn("dbo.Alimentoes", "vitamina_c", c => c.String());
            AddColumn("dbo.Alimentoes", "energia_Id", c => c.Int());
            CreateIndex("dbo.Alimentoes", "energia_Id");
            AddForeignKey("dbo.Alimentoes", "energia_Id", "dbo.Energias", "Id");
            DropColumn("dbo.Alimentoes", "QtdCarboidrato");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Alimentoes", "QtdCarboidrato", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Alimentoes", "energia_Id", "dbo.Energias");
            DropIndex("dbo.Alimentoes", new[] { "energia_Id" });
            DropColumn("dbo.Alimentoes", "energia_Id");
            DropColumn("dbo.Alimentoes", "vitamina_c");
            DropColumn("dbo.Alimentoes", "niacina");
            DropColumn("dbo.Alimentoes", "piridoxina");
            DropColumn("dbo.Alimentoes", "riboflavina");
            DropColumn("dbo.Alimentoes", "tiamina");
            DropColumn("dbo.Alimentoes", "rae");
            DropColumn("dbo.Alimentoes", "re");
            DropColumn("dbo.Alimentoes", "retinol");
            DropColumn("dbo.Alimentoes", "zinco");
            DropColumn("dbo.Alimentoes", "cobre");
            DropColumn("dbo.Alimentoes", "potassio");
            DropColumn("dbo.Alimentoes", "sodio");
            DropColumn("dbo.Alimentoes", "ferro");
            DropColumn("dbo.Alimentoes", "fosforo");
            DropColumn("dbo.Alimentoes", "manganes");
            DropColumn("dbo.Alimentoes", "magnesio");
            DropColumn("dbo.Alimentoes", "calcio");
            DropColumn("dbo.Alimentoes", "cinzas");
            DropColumn("dbo.Alimentoes", "fibra_alimentar");
            DropColumn("dbo.Alimentoes", "carboidrato");
            DropColumn("dbo.Alimentoes", "colesterol");
            DropColumn("dbo.Alimentoes", "lipideos");
            DropColumn("dbo.Alimentoes", "proteina");
            DropColumn("dbo.Alimentoes", "umidade");
            DropColumn("dbo.Alimentoes", "classificacao");
            DropTable("dbo.Energias");
        }
    }
}
