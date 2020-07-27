namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Refeicao", "Data", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Refeicao", "Data");
        }
    }
}
