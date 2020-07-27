namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuarioConfigs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsuarioConfigInsulina",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        TipoRefeicao = c.Int(nullable: false),
                        MinGlicemia = c.Double(nullable: false),
                        MaxGlicemia = c.Double(nullable: false),
                        Dose = c.Double(nullable: false),
                        GramaCarbo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioConfigInsulina", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.UsuarioConfigInsulina", new[] { "UsuarioId" });
            DropTable("dbo.UsuarioConfigInsulina");
        }
    }
}
