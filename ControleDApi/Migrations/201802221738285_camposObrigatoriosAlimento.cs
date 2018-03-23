namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class camposObrigatoriosAlimento : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Alimentoes", "Descricao", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Alimentoes", "Descricao", c => c.String());
        }
    }
}
