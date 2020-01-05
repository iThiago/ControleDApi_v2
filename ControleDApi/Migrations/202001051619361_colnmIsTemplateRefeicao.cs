namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colnmIsTemplateRefeicao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Refeicao", "IsTemplate", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Refeicao", "IsTemplate");
        }
    }
}
