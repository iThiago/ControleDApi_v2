namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameCounmsFoodAddCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alimento", "Categoria", c => c.String());
            AddColumn("dbo.Alimento", "ColesterolMGrama", c => c.String());
            AddColumn("dbo.Alimento", "CinzasMGrama", c => c.String());
            AddColumn("dbo.Alimento", "CalcioMGrama", c => c.String());
            AddColumn("dbo.Alimento", "MagnezioMGrama", c => c.String());
            AddColumn("dbo.Alimento", "ManganesMGrama", c => c.String());
            AddColumn("dbo.Alimento", "FosforoMGrama", c => c.String());
            AddColumn("dbo.Alimento", "FerroMGrama", c => c.String());
            AddColumn("dbo.Alimento", "SodioMGrama", c => c.String());
            AddColumn("dbo.Alimento", "PotassioMGrama", c => c.String());
            AddColumn("dbo.Alimento", "CobreMGrama", c => c.String());
            AddColumn("dbo.Alimento", "ZincoMGrama", c => c.String());
            AddColumn("dbo.Alimento", "RetinolMGrama", c => c.String());
            AddColumn("dbo.Alimento", "ReMgc", c => c.String());
            AddColumn("dbo.Alimento", "RaeMgc", c => c.String());
            AddColumn("dbo.Alimento", "TiaminaMGrama", c => c.String());
            AddColumn("dbo.Alimento", "RiboflavinaMGrama", c => c.String());
            AddColumn("dbo.Alimento", "PiridoxinaMGrama", c => c.String());
            AddColumn("dbo.Alimento", "NiacinaMGrama", c => c.String());
            AddColumn("dbo.Alimento", "VitaminaCMGrama", c => c.String());
            DropColumn("dbo.Alimento", "Colesterol");
            DropColumn("dbo.Alimento", "Cinzas");
            DropColumn("dbo.Alimento", "Calcio");
            DropColumn("dbo.Alimento", "Magnesio");
            DropColumn("dbo.Alimento", "Manganes");
            DropColumn("dbo.Alimento", "Fosforo");
            DropColumn("dbo.Alimento", "Ferro");
            DropColumn("dbo.Alimento", "Sodio");
            DropColumn("dbo.Alimento", "Potassio");
            DropColumn("dbo.Alimento", "Cobre");
            DropColumn("dbo.Alimento", "Zinco");
            DropColumn("dbo.Alimento", "Retinol");
            DropColumn("dbo.Alimento", "Re");
            DropColumn("dbo.Alimento", "Rae");
            DropColumn("dbo.Alimento", "Tiamina");
            DropColumn("dbo.Alimento", "Riboflavina");
            DropColumn("dbo.Alimento", "Piridoxina");
            DropColumn("dbo.Alimento", "Niacina");
            DropColumn("dbo.Alimento", "VitaminaC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Alimento", "VitaminaC", c => c.String());
            AddColumn("dbo.Alimento", "Niacina", c => c.String());
            AddColumn("dbo.Alimento", "Piridoxina", c => c.String());
            AddColumn("dbo.Alimento", "Riboflavina", c => c.String());
            AddColumn("dbo.Alimento", "Tiamina", c => c.String());
            AddColumn("dbo.Alimento", "Rae", c => c.String());
            AddColumn("dbo.Alimento", "Re", c => c.String());
            AddColumn("dbo.Alimento", "Retinol", c => c.String());
            AddColumn("dbo.Alimento", "Zinco", c => c.String());
            AddColumn("dbo.Alimento", "Cobre", c => c.String());
            AddColumn("dbo.Alimento", "Potassio", c => c.String());
            AddColumn("dbo.Alimento", "Sodio", c => c.String());
            AddColumn("dbo.Alimento", "Ferro", c => c.String());
            AddColumn("dbo.Alimento", "Fosforo", c => c.String());
            AddColumn("dbo.Alimento", "Manganes", c => c.String());
            AddColumn("dbo.Alimento", "Magnesio", c => c.String());
            AddColumn("dbo.Alimento", "Calcio", c => c.String());
            AddColumn("dbo.Alimento", "Cinzas", c => c.String());
            AddColumn("dbo.Alimento", "Colesterol", c => c.String());
            DropColumn("dbo.Alimento", "VitaminaCMGrama");
            DropColumn("dbo.Alimento", "NiacinaMGrama");
            DropColumn("dbo.Alimento", "PiridoxinaMGrama");
            DropColumn("dbo.Alimento", "RiboflavinaMGrama");
            DropColumn("dbo.Alimento", "TiaminaMGrama");
            DropColumn("dbo.Alimento", "RaeMgc");
            DropColumn("dbo.Alimento", "ReMgc");
            DropColumn("dbo.Alimento", "RetinolMGrama");
            DropColumn("dbo.Alimento", "ZincoMGrama");
            DropColumn("dbo.Alimento", "CobreMGrama");
            DropColumn("dbo.Alimento", "PotassioMGrama");
            DropColumn("dbo.Alimento", "SodioMGrama");
            DropColumn("dbo.Alimento", "FerroMGrama");
            DropColumn("dbo.Alimento", "FosforoMGrama");
            DropColumn("dbo.Alimento", "ManganesMGrama");
            DropColumn("dbo.Alimento", "MagnezioMGrama");
            DropColumn("dbo.Alimento", "CalcioMGrama");
            DropColumn("dbo.Alimento", "CinzasMGrama");
            DropColumn("dbo.Alimento", "ColesterolMGrama");
            DropColumn("dbo.Alimento", "Categoria");
        }
    }
}
