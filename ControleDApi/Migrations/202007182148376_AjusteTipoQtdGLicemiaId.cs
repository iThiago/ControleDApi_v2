namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteTipoQtdGLicemiaId : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.UsuarioConfigInsulina", new[] { "TipoQtdGlicemia_Id" });
            //RenameColumn(table: "dbo.UsuarioConfigInsulina", name: "TipoQtdGlicemia_Id", newName: "TipoQtdGlicemiaId");
            //AlterColumn("dbo.UsuarioConfigInsulina", "TipoQtdGlicemiaId", c => c.Int(nullable: false));
            //CreateIndex("dbo.UsuarioConfigInsulina", "TipoQtdGlicemiaId");
            //DropColumn("dbo.UsuarioConfigInsulina", "IdTipoQtdGlicemia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsuarioConfigInsulina", "IdTipoQtdGlicemia", c => c.Int(nullable: false));
            DropIndex("dbo.UsuarioConfigInsulina", new[] { "TipoQtdGlicemiaId" });
            AlterColumn("dbo.UsuarioConfigInsulina", "TipoQtdGlicemiaId", c => c.Int());
            RenameColumn(table: "dbo.UsuarioConfigInsulina", name: "TipoQtdGlicemiaId", newName: "TipoQtdGlicemia_Id");
            CreateIndex("dbo.UsuarioConfigInsulina", "TipoQtdGlicemia_Id");
        }
    }
}
