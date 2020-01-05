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
       // public decimal QtdCarboidrato { get; set; }
        public int Classificacao { get; set; }
        public string Categoria { get; set; }
        public string Umidade { get; set; }
        public Energia Energia { get; set; }
        public string Proteina { get; set; }
        public string Lipideos { get; set; }
        public string ColesterolMGrama { get; set; }
        public string Carboidrato { get; set; }
        public string FibraAlimentar { get; set; }
        public string CinzasMGrama { get; set; }
        public string CalcioMGrama { get; set; }
        public string MagnezioMGrama { get; set; }
        public string ManganesMGrama { get; set; }
        public string FosforoMGrama { get; set; }
        public string FerroMGrama { get; set; }
        public string SodioMGrama { get; set; }
        public string PotassioMGrama { get; set; }
        public string CobreMGrama { get; set; }
        public string ZincoMGrama { get; set; }
        public string RetinolMGrama { get; set; }
        public string ReMgc { get; set; }
        public string RaeMgc { get; set; }
        public string TiaminaMGrama { get; set; }
        public string RiboflavinaMGrama { get; set; }
        public string PiridoxinaMGrama { get; set; }
        public string NiacinaMGrama { get; set; }
        public string VitaminaCMGrama { get; set; }
        public virtual List<AlimentoConsumo> AlimentosConsumo { get; set; }
    }
}