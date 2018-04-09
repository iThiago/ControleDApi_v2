using ControleDApi.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControleDApi.DAL
{
    public class Context : IdentityDbContext<Usuario>
    {

        public Context()
            : base("BD_ControleD")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;
        }
        public static Context Create()
        {
            return new Context();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Usuarios")
                .Property(p => p.Id)
                .HasColumnName("UsuarioId");

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")
                .Property(p => p.Id)
                .HasColumnName("UsuarioId");
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UsuarioRole");
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("Logins");
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("Claims");
            modelBuilder.Entity<IdentityRole>()
                 .ToTable("Roles");
        }


        public DbSet<Alimento> Alimento { get; set; }
        //public DbSet<Energia> Energia { get; set; }
        public DbSet<AlimentoConsumo> AlimentoConsumo { get; set; }
        public DbSet<Refeicao> Refeicao { get; set; }
        public DbSet<Insulina> Insulina { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        

    }
}