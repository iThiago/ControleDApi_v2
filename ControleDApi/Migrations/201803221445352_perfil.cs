namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class perfil : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Perfils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Usuarios", "idPerfil", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "Perfil_Id", c => c.Int());
            CreateIndex("dbo.Usuarios", "Perfil_Id");
            AddForeignKey("dbo.Usuarios", "Perfil_Id", "dbo.Perfils", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "Perfil_Id", "dbo.Perfils");
            DropIndex("dbo.Usuarios", new[] { "Perfil_Id" });
            DropColumn("dbo.Usuarios", "Perfil_Id");
            DropColumn("dbo.Usuarios", "idPerfil");
            DropTable("dbo.Perfils");
        }
    }
}
