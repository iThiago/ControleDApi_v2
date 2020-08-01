namespace ControleDApi.Migrations
{
    using ControleDApi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ControleDApi.DAL.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ControleDApi.DAL.Context context)
        {
            //Atualiza usuairos e alimentos com data de cadastro e de atualização.
            var dataAtual = DateTime.UtcNow.ToLocalTime();
            context.Users.ToList().ForEach(u =>
            {
                u.AtualizadoPor = "Thiago Neto";
                u.CadastradoPor = "Thiago Neto";
                u.DataAtualizacao = dataAtual;
            });

            context.Alimento.ToList().ForEach(u =>
            {
                u.CadastradoPor = "Sistema";
                u.AtualizadoPor = "Sistema";
                u.DataAtualizacao = dataAtual;
            });

            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
