namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class senhaTemporariaField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "senhaTemporaria", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "senhaTemporaria");
        }
    }
}
