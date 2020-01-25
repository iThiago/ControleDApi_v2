using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDApi.Models
{
    public class AtributoAlimento
    {
        public int Id { get; set; }
        public double Qtd { get; set; }// O QUE TAVA NO JSON COMO "NA" FOI TROCADO PARA 0. O QUE TAVA NO JSON COMO "Tr" FOI TROCADO PARA 9999 e o que tava no Json COMO "*" foi trocado para 88888
        public EnumUnidade Unidade { get; set; }
    }

    public enum EnumUnidade
    {
        G,
        MG,
        MGC,
        Percents
    }
}