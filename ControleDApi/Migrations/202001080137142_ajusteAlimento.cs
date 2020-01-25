namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajusteAlimento : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Alimento", name: "Energia_Id", newName: "EnergiaId");
            RenameIndex(table: "dbo.Alimento", name: "IX_Energia_Id", newName: "IX_EnergiaId");
            CreateTable(
                "dbo.AtributoAlimento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qtd = c.Double(nullable: false),
                        Unidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Alimento", "UnidadeBase", c => c.String());
            AddColumn("dbo.Alimento", "QtdBase", c => c.Int(nullable: false));
            AddColumn("dbo.Alimento", "CategoriaId", c => c.Int(nullable: false));
            AddColumn("dbo.Alimento", "UmidadeId", c => c.Int());
            AddColumn("dbo.Alimento", "ProteinaId", c => c.Int());
            AddColumn("dbo.Alimento", "LipideoId", c => c.Int());
            AddColumn("dbo.Alimento", "ColesterolId", c => c.Int());
            AddColumn("dbo.Alimento", "CarboidratoId", c => c.Int(nullable: false));
            AddColumn("dbo.Alimento", "FibraAlimentarId", c => c.Int());
            AddColumn("dbo.Alimento", "CinzasId", c => c.Int());
            AddColumn("dbo.Alimento", "CalcioId", c => c.Int());
            AddColumn("dbo.Alimento", "MagnezioId", c => c.Int());
            AddColumn("dbo.Alimento", "ManganesId", c => c.Int());
            AddColumn("dbo.Alimento", "FosforoId", c => c.Int());
            AddColumn("dbo.Alimento", "FerroId", c => c.Int());
            AddColumn("dbo.Alimento", "SodioId", c => c.Int());
            AddColumn("dbo.Alimento", "PotassioId", c => c.Int());
            AddColumn("dbo.Alimento", "CobreId", c => c.Int());
            AddColumn("dbo.Alimento", "ZincoId", c => c.Int());
            AddColumn("dbo.Alimento", "RetinolId", c => c.Int());
            AddColumn("dbo.Alimento", "TiaminaId", c => c.Int());
            AddColumn("dbo.Alimento", "PiridoxinaId", c => c.Int());
            AddColumn("dbo.Alimento", "NiacinaId", c => c.Int());
            AddColumn("dbo.Alimento", "VitaminaCId", c => c.Int());
            CreateIndex("dbo.Alimento", "CategoriaId");
            CreateIndex("dbo.Alimento", "UmidadeId");
            CreateIndex("dbo.Alimento", "ProteinaId");
            CreateIndex("dbo.Alimento", "LipideoId");
            CreateIndex("dbo.Alimento", "ColesterolId");
            CreateIndex("dbo.Alimento", "CarboidratoId");
            CreateIndex("dbo.Alimento", "FibraAlimentarId");
            CreateIndex("dbo.Alimento", "CinzasId");
            CreateIndex("dbo.Alimento", "CalcioId");
            CreateIndex("dbo.Alimento", "MagnezioId");
            CreateIndex("dbo.Alimento", "ManganesId");
            CreateIndex("dbo.Alimento", "FosforoId");
            CreateIndex("dbo.Alimento", "FerroId");
            CreateIndex("dbo.Alimento", "SodioId");
            CreateIndex("dbo.Alimento", "PotassioId");
            CreateIndex("dbo.Alimento", "CobreId");
            CreateIndex("dbo.Alimento", "ZincoId");
            CreateIndex("dbo.Alimento", "RetinolId");
            CreateIndex("dbo.Alimento", "TiaminaId");
            CreateIndex("dbo.Alimento", "PiridoxinaId");
            CreateIndex("dbo.Alimento", "NiacinaId");
            CreateIndex("dbo.Alimento", "VitaminaCId");
            AddForeignKey("dbo.Alimento", "CalcioId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "CarboidratoId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "CategoriaId", "dbo.Categoria", "Id");
            AddForeignKey("dbo.Alimento", "CinzasId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "CobreId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "ColesterolId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "FerroId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "FibraAlimentarId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "FosforoId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "LipideoId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "MagnezioId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "ManganesId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "NiacinaId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "PiridoxinaId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "PotassioId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "ProteinaId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "RetinolId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "SodioId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "TiaminaId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "UmidadeId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "VitaminaCId", "dbo.AtributoAlimento", "Id");
            AddForeignKey("dbo.Alimento", "ZincoId", "dbo.AtributoAlimento", "Id");
            DropColumn("dbo.Alimento", "Categoria");
            DropColumn("dbo.Alimento", "Umidade");
            DropColumn("dbo.Alimento", "Proteina");
            DropColumn("dbo.Alimento", "Lipideos");
            DropColumn("dbo.Alimento", "ColesterolMGrama");
            DropColumn("dbo.Alimento", "Carboidrato");
            DropColumn("dbo.Alimento", "FibraAlimentar");
            DropColumn("dbo.Alimento", "CinzasMGrama");
            DropColumn("dbo.Alimento", "CalcioMGrama");
            DropColumn("dbo.Alimento", "MagnezioMGrama");
            DropColumn("dbo.Alimento", "ManganesMGrama");
            DropColumn("dbo.Alimento", "FosforoMGrama");
            DropColumn("dbo.Alimento", "FerroMGrama");
            DropColumn("dbo.Alimento", "SodioMGrama");
            DropColumn("dbo.Alimento", "PotassioMGrama");
            DropColumn("dbo.Alimento", "CobreMGrama");
            DropColumn("dbo.Alimento", "ZincoMGrama");
            DropColumn("dbo.Alimento", "RetinolMGrama");
            DropColumn("dbo.Alimento", "ReMgc");
            DropColumn("dbo.Alimento", "RaeMgc");
            DropColumn("dbo.Alimento", "TiaminaMGrama");
            DropColumn("dbo.Alimento", "RiboflavinaMGrama");
            DropColumn("dbo.Alimento", "PiridoxinaMGrama");
            DropColumn("dbo.Alimento", "NiacinaMGrama");
            DropColumn("dbo.Alimento", "VitaminaCMGrama");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Alimento", "VitaminaCMGrama", c => c.String());
            AddColumn("dbo.Alimento", "NiacinaMGrama", c => c.String());
            AddColumn("dbo.Alimento", "PiridoxinaMGrama", c => c.String());
            AddColumn("dbo.Alimento", "RiboflavinaMGrama", c => c.String());
            AddColumn("dbo.Alimento", "TiaminaMGrama", c => c.String());
            AddColumn("dbo.Alimento", "RaeMgc", c => c.String());
            AddColumn("dbo.Alimento", "ReMgc", c => c.String());
            AddColumn("dbo.Alimento", "RetinolMGrama", c => c.String());
            AddColumn("dbo.Alimento", "ZincoMGrama", c => c.String());
            AddColumn("dbo.Alimento", "CobreMGrama", c => c.String());
            AddColumn("dbo.Alimento", "PotassioMGrama", c => c.String());
            AddColumn("dbo.Alimento", "SodioMGrama", c => c.String());
            AddColumn("dbo.Alimento", "FerroMGrama", c => c.String());
            AddColumn("dbo.Alimento", "FosforoMGrama", c => c.String());
            AddColumn("dbo.Alimento", "ManganesMGrama", c => c.String());
            AddColumn("dbo.Alimento", "MagnezioMGrama", c => c.String());
            AddColumn("dbo.Alimento", "CalcioMGrama", c => c.String());
            AddColumn("dbo.Alimento", "CinzasMGrama", c => c.String());
            AddColumn("dbo.Alimento", "FibraAlimentar", c => c.String());
            AddColumn("dbo.Alimento", "Carboidrato", c => c.String());
            AddColumn("dbo.Alimento", "ColesterolMGrama", c => c.String());
            AddColumn("dbo.Alimento", "Lipideos", c => c.String());
            AddColumn("dbo.Alimento", "Proteina", c => c.String());
            AddColumn("dbo.Alimento", "Umidade", c => c.String());
            AddColumn("dbo.Alimento", "Categoria", c => c.String());
            DropForeignKey("dbo.Alimento", "ZincoId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "VitaminaCId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "UmidadeId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "TiaminaId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "SodioId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "RetinolId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "ProteinaId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "PotassioId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "PiridoxinaId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "NiacinaId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "ManganesId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "MagnezioId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "LipideoId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "FosforoId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "FibraAlimentarId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "FerroId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "ColesterolId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "CobreId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "CinzasId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.Alimento", "CarboidratoId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "CalcioId", "dbo.AtributoAlimento");
            DropIndex("dbo.Alimento", new[] { "VitaminaCId" });
            DropIndex("dbo.Alimento", new[] { "NiacinaId" });
            DropIndex("dbo.Alimento", new[] { "PiridoxinaId" });
            DropIndex("dbo.Alimento", new[] { "TiaminaId" });
            DropIndex("dbo.Alimento", new[] { "RetinolId" });
            DropIndex("dbo.Alimento", new[] { "ZincoId" });
            DropIndex("dbo.Alimento", new[] { "CobreId" });
            DropIndex("dbo.Alimento", new[] { "PotassioId" });
            DropIndex("dbo.Alimento", new[] { "SodioId" });
            DropIndex("dbo.Alimento", new[] { "FerroId" });
            DropIndex("dbo.Alimento", new[] { "FosforoId" });
            DropIndex("dbo.Alimento", new[] { "ManganesId" });
            DropIndex("dbo.Alimento", new[] { "MagnezioId" });
            DropIndex("dbo.Alimento", new[] { "CalcioId" });
            DropIndex("dbo.Alimento", new[] { "CinzasId" });
            DropIndex("dbo.Alimento", new[] { "FibraAlimentarId" });
            DropIndex("dbo.Alimento", new[] { "CarboidratoId" });
            DropIndex("dbo.Alimento", new[] { "ColesterolId" });
            DropIndex("dbo.Alimento", new[] { "LipideoId" });
            DropIndex("dbo.Alimento", new[] { "ProteinaId" });
            DropIndex("dbo.Alimento", new[] { "UmidadeId" });
            DropIndex("dbo.Alimento", new[] { "CategoriaId" });
            DropColumn("dbo.Alimento", "VitaminaCId");
            DropColumn("dbo.Alimento", "NiacinaId");
            DropColumn("dbo.Alimento", "PiridoxinaId");
            DropColumn("dbo.Alimento", "TiaminaId");
            DropColumn("dbo.Alimento", "RetinolId");
            DropColumn("dbo.Alimento", "ZincoId");
            DropColumn("dbo.Alimento", "CobreId");
            DropColumn("dbo.Alimento", "PotassioId");
            DropColumn("dbo.Alimento", "SodioId");
            DropColumn("dbo.Alimento", "FerroId");
            DropColumn("dbo.Alimento", "FosforoId");
            DropColumn("dbo.Alimento", "ManganesId");
            DropColumn("dbo.Alimento", "MagnezioId");
            DropColumn("dbo.Alimento", "CalcioId");
            DropColumn("dbo.Alimento", "CinzasId");
            DropColumn("dbo.Alimento", "FibraAlimentarId");
            DropColumn("dbo.Alimento", "CarboidratoId");
            DropColumn("dbo.Alimento", "ColesterolId");
            DropColumn("dbo.Alimento", "LipideoId");
            DropColumn("dbo.Alimento", "ProteinaId");
            DropColumn("dbo.Alimento", "UmidadeId");
            DropColumn("dbo.Alimento", "CategoriaId");
            DropColumn("dbo.Alimento", "QtdBase");
            DropColumn("dbo.Alimento", "UnidadeBase");
            DropTable("dbo.Categoria");
            DropTable("dbo.AtributoAlimento");
            RenameIndex(table: "dbo.Alimento", name: "IX_EnergiaId", newName: "IX_Energia_Id");
            RenameColumn(table: "dbo.Alimento", name: "EnergiaId", newName: "Energia_Id");
        }
    }
}
