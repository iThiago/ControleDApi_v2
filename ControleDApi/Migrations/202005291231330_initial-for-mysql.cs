namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialformysql : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agendamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuantidadeInsulina = c.Boolean(nullable: false),
                        Hora = c.DateTime(nullable: false, precision: 0),
                        Paciente_Id = c.Int(),
                        Insulina_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Paciente_Id)
                .ForeignKey("dbo.Insulina", t => t.Insulina_Id)
                .Index(t => t.Paciente_Id)
                .Index(t => t.Insulina_Id);
            
            CreateTable(
                "dbo.Insulina",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Refeicao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QtdCarboidrato = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QtdInsulina = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InsulinaId = c.Int(nullable: false),
                        IsTemplate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Insulina", t => t.InsulinaId)
                .Index(t => t.InsulinaId);
            
            CreateTable(
                "dbo.AlimentoConsumo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QtdAlimento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QtdCarboidrato = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QtdInsulina = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AlimentoId = c.Int(nullable: false),
                        RefeicaoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alimento", t => t.AlimentoId)
                .ForeignKey("dbo.Refeicao", t => t.RefeicaoId)
                .Index(t => t.AlimentoId)
                .Index(t => t.RefeicaoId);
            
            CreateTable(
                "dbo.Alimento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, unicode: false),
                        UnidadeBase = c.String(unicode: false),
                        QtdBase = c.Int(nullable: false),
                        Classificacao = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        UmidadeId = c.Int(),
                        EnergiaId = c.Int(),
                        ProteinaId = c.Int(),
                        LipideoId = c.Int(),
                        ColesterolId = c.Int(),
                        CarboidratoId = c.Int(nullable: false),
                        FibraAlimentarId = c.Int(),
                        CinzasId = c.Int(),
                        CalcioId = c.Int(),
                        MagnezioId = c.Int(),
                        ManganesId = c.Int(),
                        FosforoId = c.Int(),
                        FerroId = c.Int(),
                        SodioId = c.Int(),
                        PotassioId = c.Int(),
                        CobreId = c.Int(),
                        ZincoId = c.Int(),
                        RetinolId = c.Int(),
                        TiaminaId = c.Int(),
                        PiridoxinaId = c.Int(),
                        NiacinaId = c.Int(),
                        VitaminaCId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AtributoAlimento", t => t.CalcioId)
                .ForeignKey("dbo.AtributoAlimento", t => t.CarboidratoId)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId)
                .ForeignKey("dbo.AtributoAlimento", t => t.CinzasId)
                .ForeignKey("dbo.AtributoAlimento", t => t.CobreId)
                .ForeignKey("dbo.AtributoAlimento", t => t.ColesterolId)
                .ForeignKey("dbo.Energia", t => t.EnergiaId)
                .ForeignKey("dbo.AtributoAlimento", t => t.FerroId)
                .ForeignKey("dbo.AtributoAlimento", t => t.FibraAlimentarId)
                .ForeignKey("dbo.AtributoAlimento", t => t.FosforoId)
                .ForeignKey("dbo.AtributoAlimento", t => t.LipideoId)
                .ForeignKey("dbo.AtributoAlimento", t => t.MagnezioId)
                .ForeignKey("dbo.AtributoAlimento", t => t.ManganesId)
                .ForeignKey("dbo.AtributoAlimento", t => t.NiacinaId)
                .ForeignKey("dbo.AtributoAlimento", t => t.PiridoxinaId)
                .ForeignKey("dbo.AtributoAlimento", t => t.PotassioId)
                .ForeignKey("dbo.AtributoAlimento", t => t.ProteinaId)
                .ForeignKey("dbo.AtributoAlimento", t => t.RetinolId)
                .ForeignKey("dbo.AtributoAlimento", t => t.SodioId)
                .ForeignKey("dbo.AtributoAlimento", t => t.TiaminaId)
                .ForeignKey("dbo.AtributoAlimento", t => t.UmidadeId)
                .ForeignKey("dbo.AtributoAlimento", t => t.VitaminaCId)
                .ForeignKey("dbo.AtributoAlimento", t => t.ZincoId)
                .Index(t => t.CategoriaId)
                .Index(t => t.UmidadeId)
                .Index(t => t.EnergiaId)
                .Index(t => t.ProteinaId)
                .Index(t => t.LipideoId)
                .Index(t => t.ColesterolId)
                .Index(t => t.CarboidratoId)
                .Index(t => t.FibraAlimentarId)
                .Index(t => t.CinzasId)
                .Index(t => t.CalcioId)
                .Index(t => t.MagnezioId)
                .Index(t => t.ManganesId)
                .Index(t => t.FosforoId)
                .Index(t => t.FerroId)
                .Index(t => t.SodioId)
                .Index(t => t.PotassioId)
                .Index(t => t.CobreId)
                .Index(t => t.ZincoId)
                .Index(t => t.RetinolId)
                .Index(t => t.TiaminaId)
                .Index(t => t.PiridoxinaId)
                .Index(t => t.NiacinaId)
                .Index(t => t.VitaminaCId);
            
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
                        Descricao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Energia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        kcal = c.String(unicode: false),
                        kj = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Sobrenome = c.String(unicode: false),
                        NomeCompleto = c.String(unicode: false),
                        Senha = c.String(unicode: false),
                        QtdInsulinaPorGramaCarbo = c.Decimal(precision: 18, scale: 2),
                        Cpf = c.Long(nullable: false),
                        Crm = c.Int(),
                        senhaTemporaria = c.Boolean(),
                        Email = c.String(maxLength: 256, storeType: "nvarchar"),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Usuarios", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UsuarioRole",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.UsuarioId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.RoleId)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UsuarioRefeicao",
                c => new
                    {
                        Usuario_Id = c.Int(nullable: false),
                        Refeicao_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_Id, t.Refeicao_Id })
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id, cascadeDelete: true)
                .ForeignKey("dbo.Refeicao", t => t.Refeicao_Id, cascadeDelete: true)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Refeicao_Id);
            
            CreateTable(
                "dbo.UsuarioUsuarios",
                c => new
                    {
                        Medico_Id = c.Int(nullable: false),
                        Paciente_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Medico_Id, t.Paciente_Id })
                .ForeignKey("dbo.Usuarios", t => t.Medico_Id)
                .ForeignKey("dbo.Usuarios", t => t.Paciente_Id)
                .Index(t => t.Medico_Id)
                .Index(t => t.Paciente_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agendamento", "Insulina_Id", "dbo.Insulina");
            DropForeignKey("dbo.UsuarioUsuarios", "Paciente_Id", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioUsuarios", "Medico_Id", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioRole", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioRole", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UsuarioRefeicao", "Refeicao_Id", "dbo.Refeicao");
            DropForeignKey("dbo.UsuarioRefeicao", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Logins", "UserId", "dbo.Usuarios");
            DropForeignKey("dbo.Claims", "UserId", "dbo.Usuarios");
            DropForeignKey("dbo.Agendamento", "Paciente_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Refeicao", "InsulinaId", "dbo.Insulina");
            DropForeignKey("dbo.AlimentoConsumo", "RefeicaoId", "dbo.Refeicao");
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
            DropForeignKey("dbo.Alimento", "EnergiaId", "dbo.Energia");
            DropForeignKey("dbo.Alimento", "ColesterolId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "CobreId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "CinzasId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.Alimento", "CarboidratoId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.Alimento", "CalcioId", "dbo.AtributoAlimento");
            DropForeignKey("dbo.AlimentoConsumo", "AlimentoId", "dbo.Alimento");
            DropIndex("dbo.UsuarioUsuarios", new[] { "Paciente_Id" });
            DropIndex("dbo.UsuarioUsuarios", new[] { "Medico_Id" });
            DropIndex("dbo.UsuarioRefeicao", new[] { "Refeicao_Id" });
            DropIndex("dbo.UsuarioRefeicao", new[] { "Usuario_Id" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.UsuarioRole", new[] { "Usuario_Id" });
            DropIndex("dbo.UsuarioRole", new[] { "RoleId" });
            DropIndex("dbo.UsuarioRole", new[] { "UsuarioId" });
            DropIndex("dbo.Logins", new[] { "UserId" });
            DropIndex("dbo.Claims", new[] { "UserId" });
            DropIndex("dbo.Usuarios", "UserNameIndex");
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
            DropIndex("dbo.Alimento", new[] { "EnergiaId" });
            DropIndex("dbo.Alimento", new[] { "UmidadeId" });
            DropIndex("dbo.Alimento", new[] { "CategoriaId" });
            DropIndex("dbo.AlimentoConsumo", new[] { "RefeicaoId" });
            DropIndex("dbo.AlimentoConsumo", new[] { "AlimentoId" });
            DropIndex("dbo.Refeicao", new[] { "InsulinaId" });
            DropIndex("dbo.Agendamento", new[] { "Insulina_Id" });
            DropIndex("dbo.Agendamento", new[] { "Paciente_Id" });
            DropTable("dbo.UsuarioUsuarios");
            DropTable("dbo.UsuarioRefeicao");
            DropTable("dbo.Roles");
            DropTable("dbo.UsuarioRole");
            DropTable("dbo.Logins");
            DropTable("dbo.Claims");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Energia");
            DropTable("dbo.Categoria");
            DropTable("dbo.AtributoAlimento");
            DropTable("dbo.Alimento");
            DropTable("dbo.AlimentoConsumo");
            DropTable("dbo.Refeicao");
            DropTable("dbo.Insulina");
            DropTable("dbo.Agendamento");
        }
    }
}
