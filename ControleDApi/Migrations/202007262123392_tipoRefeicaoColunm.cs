namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipoRefeicaoColunm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Refeicao", "TipoRefeicao", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuarios", "Peso", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Peso", c => c.Double(nullable: false));
            DropColumn("dbo.Refeicao", "TipoRefeicao");
        }
    }
}
