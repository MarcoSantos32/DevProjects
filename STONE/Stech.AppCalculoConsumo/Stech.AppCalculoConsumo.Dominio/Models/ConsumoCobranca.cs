using System;
using System.ComponentModel.DataAnnotations;

namespace Stech.AppCalculoConsumo.Dominio.Models
{
    public class ConsumoCobranca
    {

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Estado { get; private set; }
        public string DataDeVencimento { get; private set; }        
        public string Valor { get; private set; }

        public ConsumoCobranca(string nome, string cpf, string estado, string dataDeVencimento, string valor)
        {
            Nome = nome;
            CPF = cpf;
            Estado = estado;
            DataDeVencimento = dataDeVencimento;
            Valor = valor;
        }
    }
}
