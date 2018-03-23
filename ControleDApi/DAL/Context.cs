using ControleDApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControleDApi.DAL
{
    public class Context : DbContext
    {

        public Context()
            : base("BD_ControleD")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Alimento> Alimento { get; set; }
        public DbSet<AlimentoConsumo> AlimentoConsumo { get; set; }
        public DbSet<Refeicao> Refeicao { get; set; }
        public DbSet<Insulina> Insulina { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Usuario> Pessoa { get; set; }

    }
}