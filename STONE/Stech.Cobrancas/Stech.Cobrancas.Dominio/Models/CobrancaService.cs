using Stech.Cobrancas.Dominio.Interfaces;
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
            if (Validate.CPFValidate.IsValid(cpf))
            {
                var cobranca = new Cobranca(Convert.ToInt64(cpf), data, valor);
                var resultado =_cobrancaRepository.Incluir(cobranca);
                resultado.Wait();
            }
            else
                throw new ArgumentException("CPF Inválido");
        }

        public IList<Cobranca> Retornar(string cpf, string mesDeReferencia)
        {

            if (Validate.CPFValidate.IsValid(cpf) || !string.IsNullOrWhiteSpace(mesDeReferencia))
            {
                Int64.TryParse(cpf, out long cpfNumerico);

                DateTime? dataDeReferencia = null;

                if(int.TryParse(mesDeReferencia, out int mes))
                    dataDeReferencia = new DateTime(DateTime.Now.Year, mes, 1);

                var resultado = _cobrancaRepository.Retornar(cpfNumerico, dataDeReferencia);
                resultado.Wait();

                return resultado.Result;
            }
            else
                throw new ArgumentException("Dados para busca Inválidos");
        }
    }
}
