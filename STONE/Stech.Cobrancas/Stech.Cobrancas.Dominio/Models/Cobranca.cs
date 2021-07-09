using Stech.Cobrancas.Dominio.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Stech.Cobrancas.Dominio.Models
{
    public class Cobranca: Entity
    {
        public Int64 CPF { get; private set; }

        //[DisplayFormat(DataFormatString = "yyyy-MM-ddTHH\\:mm\\:ss.fffZ")]
        public DateTime DataDeVencimento { get; private set; }

        public double Valor{ get; private set; }

        //Necessário ter este construtor vazio para funcionar corretamente o DynamoDB
        public Cobranca()
        {

        }

        public Cobranca(Int64 cpf, DateTime data, double valor )
        {
            Validar(cpf, data, valor);

            this.CPF = cpf;
            this.DataDeVencimento = data;
            this.Valor = valor;
        }

        private void Validar(Int64 cpf, DateTime data, double valor)
        {
            ValidarCPF(cpf);
            ValidarData(data);
            ValidarValor(valor);
        }

        private void ValidarCPF(Int64 cpf)
        {
            if (cpf <= 0)
                throw new InvalidOperationException("O cpf é inválido");
        }

        private void ValidarData(DateTime data)
        {
            if (data == DateTime.MinValue || data == DateTime.MaxValue)
                throw new ArgumentException("A data é inválida");
        }

        private void ValidarValor(double valor)
        {
            if (double.IsNegative(valor) || valor == 0)
                throw new ArgumentException("O valor é inválido");
        }
    }
}
