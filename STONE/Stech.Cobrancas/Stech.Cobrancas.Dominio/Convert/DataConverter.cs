using System;

namespace Stech.Cobrancas.Dominio.Convert
{
    public class DataConverter
    {
        public static DateTime? MonthToDateTime(string mesDeReferencia)
        {
            DateTime? dataDeReferencia = null;

            if (int.TryParse(mesDeReferencia, out int mes))
            {
                if (DateTime.TryParse($"{DateTime.Now.Year}/{mes}/{1}", out DateTime dataConvertida))
                    dataDeReferencia = dataConvertida;
            }

            return dataDeReferencia;
        }
    }
}
