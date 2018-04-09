namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tirandoUnderlineFibraAlimentar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alimentoes", "fibraAlimentar", c => c.String());
            DropColumn("dbo.Alimentoes", "fibra_alimentar");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Alimentoes", "fibra_alimentar", c => c.String());
            DropColumn("dbo.Alimentoes", "fibraAlimentar");
        }
    }
}
