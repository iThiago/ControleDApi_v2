namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agendamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hora = c.DateTime(nullable: false),
                        Paciente_Id = c.Int(),
                        Insulina_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.Paciente_Id)
                .ForeignKey("dbo.Insulinas", t => t.Insulina_Id)
                .Index(t => t.Paciente_Id)
                .Index(t => t.Insulina_Id);
            
            CreateTable(
                "dbo.Insulinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Refeicaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QtdCarboidrato = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QtdInsulina = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Insulina_Id = c.Int(),
                        Pessoa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Insulinas", t => t.Insulina_Id)
                .ForeignKey("dbo.Pessoas", t => t.Pessoa_Id)
                .Index(t => t.Insulina_Id)
                .Index(t => t.Pessoa_Id);
            
            CreateTable(
                "dbo.AlimentoConsumoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QtdAlimento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QtdCarboidrato = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QtdInsulina = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Alimento_Id = c.Int(),
                        Refeicao_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alimentoes", t => t.Alimento_Id)
                .ForeignKey("dbo.Refeicaos", t => t.Refeicao_Id)
                .Index(t => t.Alimento_Id)
                .Index(t => t.Refeicao_Id);
            
            CreateTable(
                "dbo.Alimentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        QtdCarboidrato = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Email = c.String(),
                        QtdInsulinaPorGramaCarbo = c.Decimal(precision: 18, scale: 2),
                        Cpf = c.Long(nullable: false),
                        Crm = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agendamentoes", "Insulina_Id", "dbo.Insulinas");
            DropForeignKey("dbo.Refeicaos", "Pessoa_Id", "dbo.Pessoas");
            DropForeignKey("dbo.Agendamentoes", "Paciente_Id", "dbo.Pessoas");
            DropForeignKey("dbo.Refeicaos", "Insulina_Id", "dbo.Insulinas");
            DropForeignKey("dbo.AlimentoConsumoes", "Refeicao_Id", "dbo.Refeicaos");
            DropForeignKey("dbo.AlimentoConsumoes", "Alimento_Id", "dbo.Alimentoes");
            DropIndex("dbo.Agendamentoes", new[] { "Insulina_Id" });
            DropIndex("dbo.Refeicaos", new[] { "Pessoa_Id" });
            DropIndex("dbo.Agendamentoes", new[] { "Paciente_Id" });
            DropIndex("dbo.Refeicaos", new[] { "Insulina_Id" });
            DropIndex("dbo.AlimentoConsumoes", new[] { "Refeicao_Id" });
            DropIndex("dbo.AlimentoConsumoes", new[] { "Alimento_Id" });
            DropTable("dbo.Pessoas");
            DropTable("dbo.Alimentoes");
            DropTable("dbo.AlimentoConsumoes");
            DropTable("dbo.Refeicaos");
            DropTable("dbo.Insulinas");
            DropTable("dbo.Agendamentoes");
        }
    }
}
