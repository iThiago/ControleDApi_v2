namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnTipoDiabetePesoSexoDataNasc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "DataNascimento", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Usuarios", "Peso", c => c.Double(nullable: false));
            AddColumn("dbo.Usuarios", "TipoDiabetes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "TipoDiabetes");
            DropColumn("dbo.Usuarios", "Peso");
            DropColumn("dbo.Usuarios", "DataNascimento");
        }
    }
}
