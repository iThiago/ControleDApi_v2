using ControleDApi.Models.Auth;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDApi.Models
{
    public class Usuario : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public Usuario()
        {
            this.Agendamentos = new List<Agendamento>();
            this.Refeicoes = new List<Refeicao>();
            this.Usuarios = new List<Usuario>();
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        private string _nomeCompleto;
        public string NomeCompleto
        {
            private set
            {
                _nomeCompleto = $"{Nome} {Sobrenome}".Trim();
            }
            get
            {
                return string.IsNullOrWhiteSpace(_nomeCompleto) ? $"{Nome} {Sobrenome}".Trim() : _nomeCompleto;
            }
        }
        public string Senha { get; set; }
        public decimal? QtdInsulinaPorGramaCarbo { get; set; }
        public long Cpf { get; set; }
        public int? Crm { get; set; }
        public virtual List<Agendamento> Agendamentos { get; set; }
        public virtual List<Refeicao> Refeicoes { get; set; }
        public bool? senhaTemporaria { get; set; }
        public virtual List<Usuario> Usuarios { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Peso { get; set; }
        public char Sexo { get; set; }
        public TipoDiabete TipoDiabetes { get; set; }
    }

    public enum TipoDiabete
    {
        Melitus = 10
    }
}