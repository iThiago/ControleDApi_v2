namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alimentoUnidades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlimentoUnidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(unicode: false),
                        Double = c.Double(nullable: false),
                        Alimento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alimento", t => t.Alimento_Id)
                .Index(t => t.Alimento_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlimentoUnidade", "Alimento_Id", "dbo.Alimento");
            DropIndex("dbo.AlimentoUnidade", new[] { "Alimento_Id" });
            DropTable("dbo.AlimentoUnidade");
        }
    }
}
