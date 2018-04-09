namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tirandoUnderlineVitminac : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alimentoes", "vitaminaC", c => c.String());
            DropColumn("dbo.Alimentoes", "vitamina_c");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Alimentoes", "vitamina_c", c => c.String());
            DropColumn("dbo.Alimentoes", "vitaminaC");
        }
    }
}
