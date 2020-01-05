namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuariosrefeicoes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Refeicao", "PessoaId", "dbo.Usuarios");
            DropIndex("dbo.Refeicao", new[] { "PessoaId" });
            CreateTable(
                "dbo.UsuarioRefeicao",
                c => new
                    {
                        Usuario_Id = c.Int(nullable: false),
                        Refeicao_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_Id, t.Refeicao_Id })
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id, cascadeDelete: true)
                .ForeignKey("dbo.Refeicao", t => t.Refeicao_Id, cascadeDelete: true)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Refeicao_Id);
            
            DropColumn("dbo.Refeicao", "PessoaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Refeicao", "PessoaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UsuarioRefeicao", "Refeicao_Id", "dbo.Refeicao");
            DropForeignKey("dbo.UsuarioRefeicao", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.UsuarioRefeicao", new[] { "Refeicao_Id" });
            DropIndex("dbo.UsuarioRefeicao", new[] { "Usuario_Id" });
            DropTable("dbo.UsuarioRefeicao");
            CreateIndex("dbo.Refeicao", "PessoaId");
            AddForeignKey("dbo.Refeicao", "PessoaId", "dbo.Usuarios", "UsuarioId");
        }
    }
}
