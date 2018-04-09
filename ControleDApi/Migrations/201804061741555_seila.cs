namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seila : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Alimentoes", "energia_Id", "dbo.Energias");
            DropIndex("dbo.Alimentoes", new[] { "energia_Id" });
            DropColumn("dbo.Alimentoes", "energia_Id");
            DropTable("dbo.Energias");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Energias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        kcal = c.String(),
                        kj = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Alimentoes", "energia_Id", c => c.Int());
            CreateIndex("dbo.Alimentoes", "energia_Id");
            AddForeignKey("dbo.Alimentoes", "energia_Id", "dbo.Energias", "Id");
        }
    }
}
