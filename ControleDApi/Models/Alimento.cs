using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ControleDApi.Models;

namespace ControleDApi.Models
{
    public class Alimento
    {
        public Alimento()
        {
            this.AlimentosConsumo = new List<AlimentoConsumo>();
            this.Unidades = new List<AlimentoUnidade>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "A Descrição é obrigatória!")]
        public string Descricao { get; set; }
        public string UnidadeBase { get; set; }
        public EnumUnidade QtdBase { get; set; }

        // public decimal QtdCarboidrato { get; set; }
        public int Classificacao { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int? UmidadeId { get; set; }
        public virtual AtributoAlimento Umidade { get; set; }
        public int? EnergiaId { get; set; }
        public virtual Energia Energia { get; set; }
        public int? ProteinaId { get; set; }
        public virtual AtributoAlimento Proteina { get; set; }
        public int? LipideoId { get; set; }
        public virtual AtributoAlimento Lipideo { get; set; }
        public int? ColesterolId { get; set; }
        public virtual AtributoAlimento Colesterol { get; set; }
        public int? CarboidratoId { get; set; }
        [Required(ErrorMessage = "Carboidrato é obrigatório!")]
        public virtual AtributoAlimento Carboidrato { get; set; } 
        public int? FibraAlimentarId { get; set; }
        public virtual AtributoAlimento FibraAlimentar { get; set; }
        public int? CinzasId { get; set; }
        public virtual AtributoAlimento Cinzas { get; set; }
        public int? CalcioId { get; set; }
        public virtual AtributoAlimento Calcio { get; set; }
        public int? MagnezioId { get; set; }
        public virtual AtributoAlimento Magnezio { get; set; }
        


        public virtual AtributoAlimento Manganes { get; set; }
        public int? ManganesId { get; set; }
        public virtual AtributoAlimento Fosforo { get; set; }
        public int? FosforoId { get; set; }
        public virtual AtributoAlimento Ferro { get; set; }
        public int? FerroId { get; set; }
        public virtual AtributoAlimento Sodio { get; set; }
        public int? SodioId { get; set; }
        public virtual AtributoAlimento Potassio { get; set; }
        public int? PotassioId { get; set; }
        public virtual AtributoAlimento Cobre { get; set; }
        public int? CobreId { get; set; }
        public virtual AtributoAlimento Zinco { get; set; }
        public int? ZincoId { get; set; }
        public virtual AtributoAlimento Retinol { get; set; }
        public int? RetinolId { get; set; }
        public virtual AtributoAlimento Tiamina { get; set; }
        public int? TiaminaId { get; set; }
        public virtual AtributoAlimento Piridoxina { get; set; }
        public virtual int? PiridoxinaId { get; set; }
        public int? NiacinaId { get; set; }
        public virtual AtributoAlimento Niacina { get; set; }
        public int? VitaminaCId { get; set; }
        public virtual AtributoAlimento VitaminaC { get; set; }
        public virtual List<AlimentoConsumo> AlimentosConsumo { get; set; }
        public virtual List<AlimentoUnidade> Unidades { get; set; }
        public string AtualizadoPor { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}