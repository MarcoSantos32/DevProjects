using System;

namespace Stech.Cobrancas.WebApi.DTO
{
    public class CobrancaDTO
    {
        public string CPF { get; private set; }

        public DateTime DataDeVencimento { get; private set; }

        public double Valor { get; private set; }


        public CobrancaDTO(string cpf, DateTime dataDeVencimento, double valor)
        {
            CPF = cpf;
            DataDeVencimento = dataDeVencimento;
            Valor = valor;
        }
    }
}
