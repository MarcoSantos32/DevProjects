using System;

namespace Stech.AppCalculoConsumo.Dominio.Models
{
    public class Cobranca
    {
        public string CPF { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public double Valor { get; set; }
    }
}