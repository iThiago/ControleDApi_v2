namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsuarioUsuarios", "Medico_Id", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioUsuarios", "Paciente_Id", "dbo.Usuarios");
            CreateTable(
                "dbo.UsuarioUsuarios",
                c => new
                    {
                        Medico_Id = c.Int(nullable: false),
                        Paciente_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Medico_Id, t.Paciente_Id })
                .ForeignKey("dbo.Usuarios", t => t.Medico_Id)
                .ForeignKey("dbo.Usuarios", t => t.Paciente_Id);
            
          //  DropTable("dbo.UsuarioUsuarios");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsuarioUsuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ativo = c.Boolean(nullable: false),
                        Medico_Id = c.Int(),
                        Paciente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.UsuarioUsuarios", "Paciente_Id", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioUsuarios", "Medico_Id", "dbo.Usuarios");
            DropTable("dbo.UsuarioUsuarios");
            AddForeignKey("dbo.UsuarioUsuarios", "Paciente_Id", "dbo.Usuarios", "UsuarioId");
            AddForeignKey("dbo.UsuarioUsuarios", "Medico_Id", "dbo.Usuarios", "UsuarioId");
        }
    }
}
