using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDApi.Models
{
    public class UsuarioConfigInsulina
    {
        public int Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public int TipoRefeicao { get; set; }
        public int TipoQtdGlicemiaId { get; set; }
        public virtual TipoQtdGlicemia TipoQtdGlicemia { get; set; }
        public double Dose { get; set; }
        public double GramaCarbo { get; set; }

    }

    public class TipoQtdGlicemia
    {
        public int Id { get; set; }
        public double MinGlicemia { get; set; }
        public double MaxGlicemia { get; set; }
        public string Descricao => MaxGlicemia > 0 && MinGlicemia > 0 ? $"{MinGlicemia} - {MaxGlicemia}" : (MinGlicemia > 0 && MaxGlicemia == 0 ? $">= {MinGlicemia}" : $"<= {MaxGlicemia}");
    }
}