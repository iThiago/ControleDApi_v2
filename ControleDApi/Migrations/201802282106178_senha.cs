namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class senha : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Pessoas", newName: "Usuarios");
            AddColumn("dbo.Usuarios", "Senha", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Senha");
            RenameTable(name: "dbo.Usuarios", newName: "Pessoas");
        }
    }
}
