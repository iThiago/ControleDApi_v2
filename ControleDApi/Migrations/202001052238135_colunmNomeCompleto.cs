namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colunmNomeCompleto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "NomeCompleto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "NomeCompleto");
        }
    }
}
