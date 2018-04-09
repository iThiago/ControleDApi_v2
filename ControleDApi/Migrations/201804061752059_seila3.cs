namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seila3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alimentoes", "Energia_EnergiaId", c => c.Int());
            CreateIndex("dbo.Alimentoes", "Energia_EnergiaId");
            AddForeignKey("dbo.Alimentoes", "Energia_EnergiaId", "dbo.Energias", "EnergiaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alimentoes", "Energia_EnergiaId", "dbo.Energias");
            DropIndex("dbo.Alimentoes", new[] { "Energia_EnergiaId" });
            DropColumn("dbo.Alimentoes", "Energia_EnergiaId");
        }
    }
}
