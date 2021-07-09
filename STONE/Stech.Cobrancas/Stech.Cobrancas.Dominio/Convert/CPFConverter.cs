using System;

namespace Stech.Cobrancas.Dominio.Convert
{
    public class CPFConverter
    {
        public static long ConvertToLong(string cpf)
        {
            string cpfNumerico = string.Empty;
            if (!string.IsNullOrWhiteSpace(cpf))
            {
                foreach (var caractereCPF in cpf.ToCharArray())
                {
                    if (Char.IsDigit(caractereCPF))
                        cpfNumerico += caractereCPF;
                }
            }

            return !string.IsNullOrWhiteSpace(cpfNumerico) ? long.Parse(cpfNumerico) : 0;
        }
    }
}