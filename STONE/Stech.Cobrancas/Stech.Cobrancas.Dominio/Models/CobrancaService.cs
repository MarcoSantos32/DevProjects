using System;
using System.Collections.Generic;
using System.Text;
using Stech.Cobrancas.Dominio.Interfaces;


namespace Stech.Cobrancas.Dominio.Models
{
    public class CobrancaService : ICobrancaService
    {
        private readonly IRepository<Cobranca> _cobrancaRepository;

        public CobrancaService(IRepository<Cobranca> cobrancaRepository)
        {
            _cobrancaRepository = cobrancaRepository;
        }

        public void Incluir(string cpf, DateTime data, double valor)
        {
            if (Validate.CPFValidate.IsValid(cpf))
            {
                var cobranca = new Cobranca(Convert.ToInt64(cpf), data, valor);
                _cobrancaRepository.Incluir(cobranca);
            }
            else
                throw new ArgumentException("CPF Inválido");
        }

        public IList<Cobranca> Retornar(string cpf, DateTime? data)
        {
            if (Validate.CPFValidate.IsValid(cpf))
            {
                var resultado = _cobrancaRepository.Retornar(Int64.Parse(cpf), data);
                resultado.Wait();

                return resultado.Result;
            }
            else
                throw new ArgumentException("CPF Inválido");
        }
    }
}
