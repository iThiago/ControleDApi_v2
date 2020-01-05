using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDApi.Models
{
    public class Refeicao
    {
        public Refeicao()
        {
            this.AlimentosConsumo = new List<AlimentoConsumo>();
            this.Usuarios = new List<Usuario>();
        }
        public int Id { get; set; }
        public decimal QtdCarboidrato { get; set; }
        public decimal QtdInsulina { get; set; }
        public int InsulinaId { get; set; }
        public virtual Insulina Insulina { get; set; }
        //public int PessoaId { get; set; }
        public virtual List<Usuario> Usuarios { get; set; }
        public virtual List<AlimentoConsumo> AlimentosConsumo { get; set; }
        public bool IsTemplate { get; set; }

    }
}