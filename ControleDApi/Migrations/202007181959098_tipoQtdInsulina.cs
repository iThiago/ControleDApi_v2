namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipoQtdInsulina : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoQtdInsulina",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinGlicemia = c.Double(nullable: false),
                        MaxGlicemia = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UsuarioConfigInsulina", "IdTipoQtdInsulina", c => c.Int(nullable: false));
            AddColumn("dbo.UsuarioConfigInsulina", "TipoQtdInsulina_Id", c => c.Int());
            CreateIndex("dbo.UsuarioConfigInsulina", "TipoQtdInsulina_Id");
            AddForeignKey("dbo.UsuarioConfigInsulina", "TipoQtdInsulina_Id", "dbo.TipoQtdInsulina", "Id");
            DropColumn("dbo.UsuarioConfigInsulina", "MinGlicemia");
            DropColumn("dbo.UsuarioConfigInsulina", "MaxGlicemia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsuarioConfigInsulina", "MaxGlicemia", c => c.Double(nullable: false));
            AddColumn("dbo.UsuarioConfigInsulina", "MinGlicemia", c => c.Double(nullable: false));
            DropForeignKey("dbo.UsuarioConfigInsulina", "TipoQtdInsulina_Id", "dbo.TipoQtdInsulina");
            DropIndex("dbo.UsuarioConfigInsulina", new[] { "TipoQtdInsulina_Id" });
            DropColumn("dbo.UsuarioConfigInsulina", "TipoQtdInsulina_Id");
            DropColumn("dbo.UsuarioConfigInsulina", "IdTipoQtdInsulina");
            DropTable("dbo.TipoQtdInsulina");
        }
    }
}
