namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoQtdGlicemia : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.TipoQtdInsulina", newName: "TipoQtdGlicemia");
            //RenameColumn(table: "dbo.UsuarioConfigInsulina", name: "TipoQtdInsulina_Id", newName: "TipoQtdGlicemia_Id");
            //RenameIndex(table: "dbo.UsuarioConfigInsulina", name: "IX_TipoQtdInsulina_Id", newName: "IX_TipoQtdGlicemia_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UsuarioConfigInsulina", name: "IX_TipoQtdGlicemia_Id", newName: "IX_TipoQtdInsulina_Id");
            RenameColumn(table: "dbo.UsuarioConfigInsulina", name: "TipoQtdGlicemia_Id", newName: "TipoQtdInsulina_Id");
            RenameTable(name: "dbo.TipoQtdGlicemia", newName: "TipoQtdInsulina");
        }
    }
}
