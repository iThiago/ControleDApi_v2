namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seila2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Energias",
                c => new
                    {
                        EnergiaId = c.Int(nullable: false, identity: true),
                        kcal = c.String(),
                        kj = c.String(),
                    })
                .PrimaryKey(t => t.EnergiaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Energias");
        }
    }
}
