namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sexoString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Sexo", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Sexo");
        }
    }
}
