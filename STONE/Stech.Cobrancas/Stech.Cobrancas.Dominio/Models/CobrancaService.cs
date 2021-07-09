using Stech.Cobrancas.Dominio.Convert;
using Stech.Cobrancas.Dominio.Interfaces;
using Stech.Cobrancas.Dominio.Validate;
using System;
using System.Collections.Generic;


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
            if (CPFValidate.IsValid(cpf))
            {
                var cobranca = new Cobranca(CPFConverter.ConvertToLong(cpf), data, valor);
                var resultado =_cobrancaRepository.Incluir(cobranca);
                resultado.Wait();
            }
            else
                throw new ArgumentException("CPF Inválido");
        }

        public IList<Cobranca> Retornar(string cpf, string mesDeReferencia)
        {
            DateTime? dataDeReferencia = DataConverter.MonthToDateTime(mesDeReferencia);

            if (CPFValidate.IsValid(cpf) || dataDeReferencia.HasValue)
            {
                var resultado = _cobrancaRepository.Retornar(CPFConverter.ConvertToLong(cpf), dataDeReferencia);
                resultado.Wait();

                return resultado.Result;
            }
            else
                throw new ArgumentException("Dados para busca Inválidos");
        }
    }
}
