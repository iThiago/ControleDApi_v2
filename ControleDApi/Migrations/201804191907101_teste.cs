namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsuarioUsuarios", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.UsuarioUsuarios", new[] { "Usuario_Id" });
            DropColumn("dbo.UsuarioUsuarios", "Usuario_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsuarioUsuarios", "Usuario_Id", c => c.Int());
            CreateIndex("dbo.UsuarioUsuarios", "Usuario_Id");
            AddForeignKey("dbo.UsuarioUsuarios", "Usuario_Id", "dbo.Usuarios", "UsuarioId");
        }
    }
}
