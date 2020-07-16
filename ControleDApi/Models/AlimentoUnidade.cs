using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDApi.Models
{
    public class AlimentoUnidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double EquivalenteEmGramas { get; set; }

    }
}