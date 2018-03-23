using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ControleDApi.Models
{
    public class Alimento
    {
        public Alimento()
        {
            this.AlimentosConsumo = new List<AlimentoConsumo>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Descrição é obrigatório!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Qtd. Carboidrato é obrigatório!")]
        public decimal QtdCarboidrato { get; set; }
        public virtual List<AlimentoConsumo> AlimentosConsumo { get; set; }
    }
}