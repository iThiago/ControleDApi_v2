namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class camposAtualizadoCadastradoPor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Alimento", "DataAtualizacao", c => c.DateTime(precision: 0));
            AlterColumn("dbo.Usuarios", "DataAtualizacao", c => c.DateTime(precision: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "DataAtualizacao", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Alimento", "DataAtualizacao", c => c.DateTime(nullable: false, precision: 0));
        }
    }
}
