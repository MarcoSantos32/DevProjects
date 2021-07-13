using Newtonsoft.Json;

namespace Stech.AppCalculoConsumo.Dominio.Models
{
    public class Cliente
    {
        public Cliente(string cpf, string nome, string estado)
        {
            this.CPF = cpf;
            this.Nome = nome;
            this.Estado = estado;
        }

        [JsonProperty(PropertyName = "cpf")]
        public string CPF { get; private set; }
        
        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; private set; }
        
        [JsonProperty(PropertyName = "estado")]
        public string Estado { get; private set; }
    }
}
