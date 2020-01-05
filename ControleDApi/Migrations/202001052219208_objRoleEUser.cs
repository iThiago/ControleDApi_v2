namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class objRoleEUser : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.UsuarioRole", "Usuario_Id", c => c.Int());
            //CreateIndex("dbo.UsuarioRole", "Usuario_Id");
            //AddForeignKey("dbo.UsuarioRole", "RoleId", "dbo.Roles", "Id");
            //AddForeignKey("dbo.UsuarioRole", "Usuario_Id", "dbo.Usuarios", "UsuarioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioRole", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioRole", "RoleId", "dbo.Roles");
            DropIndex("dbo.UsuarioRole", new[] { "Usuario_Id" });
            DropColumn("dbo.UsuarioRole", "Usuario_Id");
        }
    }
}
