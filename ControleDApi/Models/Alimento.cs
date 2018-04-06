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
        public string descricao { get; set; }
        [Required(ErrorMessage = "Qtd. Carboidrato é obrigatório!")]
       // public decimal QtdCarboidrato { get; set; }
        public int classificacao { get; set; }
        public string umidade { get; set; }
        public Energia energia { get; set; }
        public string proteina { get; set; }
        public string lipideos { get; set; }
        public string colesterol { get; set; }
        public string carboidrato { get; set; }
        public string fibra_alimentar { get; set; }
        public string cinzas { get; set; }
        public string calcio { get; set; }
        public string magnesio { get; set; }
        public string manganes { get; set; }
        public string fosforo { get; set; }
        public string ferro { get; set; }
        public string sodio { get; set; }
        public string potassio { get; set; }
        public string cobre { get; set; }
        public string zinco { get; set; }
        public string retinol { get; set; }
        public string re { get; set; }
        public string rae { get; set; }
        public string tiamina { get; set; }
        public string riboflavina { get; set; }
        public string piridoxina { get; set; }
        public string niacina { get; set; }
        public string vitamina_c { get; set; }
        public virtual List<AlimentoConsumo> AlimentosConsumo { get; set; }
    }
}