namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agendamentoes", "Paciente_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Refeicaos", "Pessoa_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Claims", "IdentityUser_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Logins", "IdentityUser_Id", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioRole", "IdentityUser_Id", "dbo.Usuarios");
            DropPrimaryKey("dbo.Usuarios");
            AlterColumn("dbo.Usuarios", "UsuarioId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Usuarios", "UsuarioId");
            AddForeignKey("dbo.Agendamentoes", "Paciente_Id", "dbo.Usuarios", "UsuarioId");
            AddForeignKey("dbo.Refeicaos", "Pessoa_Id", "dbo.Usuarios", "UsuarioId");
            AddForeignKey("dbo.Claims", "IdentityUser_Id", "dbo.Usuarios", "UsuarioId");
            AddForeignKey("dbo.Logins", "IdentityUser_Id", "dbo.Usuarios", "UsuarioId");
            AddForeignKey("dbo.UsuarioRole", "IdentityUser_Id", "dbo.Usuarios", "UsuarioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioRole", "IdentityUser_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Logins", "IdentityUser_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Claims", "IdentityUser_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Refeicaos", "Pessoa_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Agendamentoes", "Paciente_Id", "dbo.Usuarios");
            DropPrimaryKey("dbo.Usuarios");
            AlterColumn("dbo.Usuarios", "UsuarioId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Usuarios", "UsuarioId");
            AddForeignKey("dbo.UsuarioRole", "IdentityUser_Id", "dbo.Usuarios", "UsuarioId");
            AddForeignKey("dbo.Logins", "IdentityUser_Id", "dbo.Usuarios", "UsuarioId");
            AddForeignKey("dbo.Claims", "IdentityUser_Id", "dbo.Usuarios", "UsuarioId");
            AddForeignKey("dbo.Refeicaos", "Pessoa_Id", "dbo.Usuarios", "UsuarioId");
            AddForeignKey("dbo.Agendamentoes", "Paciente_Id", "dbo.Usuarios", "UsuarioId");
        }
    }
}
