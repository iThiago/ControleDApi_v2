namespace ControleDApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstWithIdentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agendamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hora = c.DateTime(nullable: false),
                        Paciente_Id = c.String(maxLength: 128),
                        Insulina_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Paciente_Id)
                .ForeignKey("dbo.Insulinas", t => t.Insulina_Id)
                .Index(t => t.Paciente_Id)
                .Index(t => t.Insulina_Id);
            
            CreateTable(
                "dbo.Insulinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Refeicaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QtdCarboidrato = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QtdInsulina = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Insulina_Id = c.Int(),
                        Pessoa_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Insulinas", t => t.Insulina_Id)
                .ForeignKey("dbo.Usuarios", t => t.Pessoa_Id)
                .Index(t => t.Insulina_Id)
                .Index(t => t.Pessoa_Id);
            
            CreateTable(
                "dbo.AlimentoConsumoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QtdAlimento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QtdCarboidrato = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QtdInsulina = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Alimento_Id = c.Int(),
                        Refeicao_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alimentoes", t => t.Alimento_Id)
                .ForeignKey("dbo.Refeicaos", t => t.Refeicao_Id)
                .Index(t => t.Alimento_Id)
                .Index(t => t.Refeicao_Id);
            
            CreateTable(
                "dbo.Alimentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        QtdCarboidrato = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Senha = c.String(),
                        QtdInsulinaPorGramaCarbo = c.Decimal(precision: 18, scale: 2),
                        Cpf = c.Long(),
                        Crm = c.Int(),
                        idPerfil = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Perfil_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Perfils", t => t.Perfil_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Perfil_Id);
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Usuarios", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Perfils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsuarioRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioRole", "IdentityUser_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Logins", "IdentityUser_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Claims", "IdentityUser_Id", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Agendamentoes", "Insulina_Id", "dbo.Insulinas");
            DropForeignKey("dbo.Refeicaos", "Pessoa_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "Perfil_Id", "dbo.Perfils");
            DropForeignKey("dbo.Agendamentoes", "Paciente_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Refeicaos", "Insulina_Id", "dbo.Insulinas");
            DropForeignKey("dbo.AlimentoConsumoes", "Refeicao_Id", "dbo.Refeicaos");
            DropForeignKey("dbo.AlimentoConsumoes", "Alimento_Id", "dbo.Alimentoes");
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.UsuarioRole", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UsuarioRole", new[] { "RoleId" });
            DropIndex("dbo.Logins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Claims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Usuarios", new[] { "Perfil_Id" });
            DropIndex("dbo.Usuarios", "UserNameIndex");
            DropIndex("dbo.AlimentoConsumoes", new[] { "Refeicao_Id" });
            DropIndex("dbo.AlimentoConsumoes", new[] { "Alimento_Id" });
            DropIndex("dbo.Refeicaos", new[] { "Pessoa_Id" });
            DropIndex("dbo.Refeicaos", new[] { "Insulina_Id" });
            DropIndex("dbo.Agendamentoes", new[] { "Insulina_Id" });
            DropIndex("dbo.Agendamentoes", new[] { "Paciente_Id" });
            DropTable("dbo.Roles");
            DropTable("dbo.UsuarioRole");
            DropTable("dbo.Perfils");
            DropTable("dbo.Logins");
            DropTable("dbo.Claims");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Alimentoes");
            DropTable("dbo.AlimentoConsumoes");
            DropTable("dbo.Refeicaos");
            DropTable("dbo.Insulinas");
            DropTable("dbo.Agendamentoes");
        }
    }
}
