namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajusteNomeColuna : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlimentoUnidade", "EquivalenteEmGramas", c => c.Double(nullable: false));
            DropColumn("dbo.AlimentoUnidade", "Double");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlimentoUnidade", "Double", c => c.Double(nullable: false));
            DropColumn("dbo.AlimentoUnidade", "EquivalenteEmGramas");
        }
    }
}
