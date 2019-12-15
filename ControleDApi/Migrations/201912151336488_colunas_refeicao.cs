namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colunas_refeicao : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Refeicao", new[] { "Insulina_Id" });
            DropIndex("dbo.Refeicao", new[] { "Pessoa_Id" });
            DropIndex("dbo.AlimentoConsumo", new[] { "Alimento_Id" });
            DropIndex("dbo.AlimentoConsumo", new[] { "Refeicao_Id" });
            RenameColumn(table: "dbo.Refeicao", name: "Insulina_Id", newName: "InsulinaId");
            RenameColumn(table: "dbo.AlimentoConsumo", name: "Refeicao_Id", newName: "RefeicaoId");
            RenameColumn(table: "dbo.Refeicao", name: "Pessoa_Id", newName: "PessoaId");
            RenameColumn(table: "dbo.AlimentoConsumo", name: "Alimento_Id", newName: "AlimentoId");
            AlterColumn("dbo.Refeicao", "InsulinaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Refeicao", "PessoaId", c => c.Int(nullable: false));
            AlterColumn("dbo.AlimentoConsumo", "AlimentoId", c => c.Int(nullable: false));
            AlterColumn("dbo.AlimentoConsumo", "RefeicaoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Refeicao", "InsulinaId");
            CreateIndex("dbo.Refeicao", "PessoaId");
            CreateIndex("dbo.AlimentoConsumo", "AlimentoId");
            CreateIndex("dbo.AlimentoConsumo", "RefeicaoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AlimentoConsumo", new[] { "RefeicaoId" });
            DropIndex("dbo.AlimentoConsumo", new[] { "AlimentoId" });
            DropIndex("dbo.Refeicao", new[] { "PessoaId" });
            DropIndex("dbo.Refeicao", new[] { "InsulinaId" });
            AlterColumn("dbo.AlimentoConsumo", "RefeicaoId", c => c.Int());
            AlterColumn("dbo.AlimentoConsumo", "AlimentoId", c => c.Int());
            AlterColumn("dbo.Refeicao", "PessoaId", c => c.Int());
            AlterColumn("dbo.Refeicao", "InsulinaId", c => c.Int());
            RenameColumn(table: "dbo.AlimentoConsumo", name: "AlimentoId", newName: "Alimento_Id");
            RenameColumn(table: "dbo.Refeicao", name: "PessoaId", newName: "Pessoa_Id");
            RenameColumn(table: "dbo.AlimentoConsumo", name: "RefeicaoId", newName: "Refeicao_Id");
            RenameColumn(table: "dbo.Refeicao", name: "InsulinaId", newName: "Insulina_Id");
            CreateIndex("dbo.AlimentoConsumo", "Refeicao_Id");
            CreateIndex("dbo.AlimentoConsumo", "Alimento_Id");
            CreateIndex("dbo.Refeicao", "Pessoa_Id");
            CreateIndex("dbo.Refeicao", "Insulina_Id");
        }
    }
}
