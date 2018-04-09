namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tirandotudo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Alimentoes", "Energia_EnergiaId", "dbo.Energias");
            DropIndex("dbo.Alimentoes", new[] { "Energia_EnergiaId" });
            AddColumn("dbo.Alimentoes", "QtdCarboidrato", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Alimentoes", "classificacao");
            DropColumn("dbo.Alimentoes", "umidade");
            DropColumn("dbo.Alimentoes", "proteina");
            DropColumn("dbo.Alimentoes", "lipideos");
            DropColumn("dbo.Alimentoes", "colesterol");
            DropColumn("dbo.Alimentoes", "carboidrato");
            DropColumn("dbo.Alimentoes", "fibraAlimentar");
            DropColumn("dbo.Alimentoes", "cinzas");
            DropColumn("dbo.Alimentoes", "calcio");
            DropColumn("dbo.Alimentoes", "magnesio");
            DropColumn("dbo.Alimentoes", "manganes");
            DropColumn("dbo.Alimentoes", "fosforo");
            DropColumn("dbo.Alimentoes", "ferro");
            DropColumn("dbo.Alimentoes", "sodio");
            DropColumn("dbo.Alimentoes", "potassio");
            DropColumn("dbo.Alimentoes", "cobre");
            DropColumn("dbo.Alimentoes", "zinco");
            DropColumn("dbo.Alimentoes", "retinol");
            DropColumn("dbo.Alimentoes", "re");
            DropColumn("dbo.Alimentoes", "rae");
            DropColumn("dbo.Alimentoes", "tiamina");
            DropColumn("dbo.Alimentoes", "riboflavina");
            DropColumn("dbo.Alimentoes", "piridoxina");
            DropColumn("dbo.Alimentoes", "niacina");
            DropColumn("dbo.Alimentoes", "vitaminaC");
            DropColumn("dbo.Alimentoes", "Energia_EnergiaId");
            DropTable("dbo.Energias");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Energias",
                c => new
                    {
                        EnergiaId = c.Int(nullable: false, identity: true),
                        kcal = c.String(),
                        kj = c.String(),
                    })
                .PrimaryKey(t => t.EnergiaId);
            
            AddColumn("dbo.Alimentoes", "Energia_EnergiaId", c => c.Int());
            AddColumn("dbo.Alimentoes", "vitaminaC", c => c.String());
            AddColumn("dbo.Alimentoes", "niacina", c => c.String());
            AddColumn("dbo.Alimentoes", "piridoxina", c => c.String());
            AddColumn("dbo.Alimentoes", "riboflavina", c => c.String());
            AddColumn("dbo.Alimentoes", "tiamina", c => c.String());
            AddColumn("dbo.Alimentoes", "rae", c => c.String());
            AddColumn("dbo.Alimentoes", "re", c => c.String());
            AddColumn("dbo.Alimentoes", "retinol", c => c.String());
            AddColumn("dbo.Alimentoes", "zinco", c => c.String());
            AddColumn("dbo.Alimentoes", "cobre", c => c.String());
            AddColumn("dbo.Alimentoes", "potassio", c => c.String());
            AddColumn("dbo.Alimentoes", "sodio", c => c.String());
            AddColumn("dbo.Alimentoes", "ferro", c => c.String());
            AddColumn("dbo.Alimentoes", "fosforo", c => c.String());
            AddColumn("dbo.Alimentoes", "manganes", c => c.String());
            AddColumn("dbo.Alimentoes", "magnesio", c => c.String());
            AddColumn("dbo.Alimentoes", "calcio", c => c.String());
            AddColumn("dbo.Alimentoes", "cinzas", c => c.String());
            AddColumn("dbo.Alimentoes", "fibraAlimentar", c => c.String());
            AddColumn("dbo.Alimentoes", "carboidrato", c => c.String());
            AddColumn("dbo.Alimentoes", "colesterol", c => c.String());
            AddColumn("dbo.Alimentoes", "lipideos", c => c.String());
            AddColumn("dbo.Alimentoes", "proteina", c => c.String());
            AddColumn("dbo.Alimentoes", "umidade", c => c.String());
            AddColumn("dbo.Alimentoes", "classificacao", c => c.Int(nullable: false));
            DropColumn("dbo.Alimentoes", "QtdCarboidrato");
            CreateIndex("dbo.Alimentoes", "Energia_EnergiaId");
            AddForeignKey("dbo.Alimentoes", "Energia_EnergiaId", "dbo.Energias", "EnergiaId");
        }
    }
}
