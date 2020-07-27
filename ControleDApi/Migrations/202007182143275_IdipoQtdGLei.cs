namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdipoQtdGLei : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.UsuarioConfigInsulina", "IdTipoQtdGlicemia", c => c.Int(nullable: false));
            //DropColumn("dbo.UsuarioConfigInsulina", "IdTipoQtdInsulina");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsuarioConfigInsulina", "IdTipoQtdInsulina", c => c.Int(nullable: false));
            DropColumn("dbo.UsuarioConfigInsulina", "IdTipoQtdGlicemia");
        }
    }
}
