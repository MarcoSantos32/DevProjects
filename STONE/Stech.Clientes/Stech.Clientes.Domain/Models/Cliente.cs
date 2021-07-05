using Stech.Clientes.Domain.Base;
using System;

namespace Stech.Clientes.Domain.Models
{
    public class Cliente : Entity
    {
        public Int64 CPF { get; private set; }
        public string Nome { get; private set; }
        public string Estado { get; private set; }

        //Necessário ter este construtor vazio para funcionar corretamente o DynamoDB
        public Cliente()
        {

        }

        public Cliente(Int64 cpf, string nome, string estado)
        {
            Validar(cpf, nome, estado);

            CPF = cpf;
            Nome = nome;
            Estado = estado;
        }

        public void Cadastrar(Int64 cpf, string nome, string estado)
        {
            Validar(cpf, nome, estado);
        }

        private void Validar(Int64 cpf, string nome, string estado)
        {
            ValidarCPF(cpf);
            ValidarNome(nome);
            ValidarEstado(estado);
        }

        private void ValidarCPF (Int64 cpf)
        {
            if (cpf <= 0)
                throw new InvalidOperationException("O cpf é inválido");
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new InvalidOperationException("O nome é inválido");
        }

        private void ValidarEstado(string estado)
        {
            if (string.IsNullOrEmpty(estado))
                throw new InvalidOperationException("O estado é inválido");
        }
    }
}
