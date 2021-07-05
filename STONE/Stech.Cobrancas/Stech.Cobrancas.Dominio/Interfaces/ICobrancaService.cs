using Stech.Cobrancas.Dominio.Models;
using System;
using System.Collections.Generic;

namespace Stech.Cobrancas.Dominio.Interfaces
{
    internal interface ICobrancaService
    {
        void Incluir(string cpf, DateTime data, double valor);

        IList<Cobranca> Retornar(string cpf, DateTime? data);
    }
}