namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colunmQtdInsulinaNoAgendamento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agendamento", "QuantidadeInsulina", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agendamento", "QuantidadeInsulina");
        }
    }
}
