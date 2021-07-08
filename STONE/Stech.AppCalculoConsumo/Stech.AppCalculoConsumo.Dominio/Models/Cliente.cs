using Newtonsoft.Json;

namespace Stech.AppCalculoConsumo.Dominio.Models
{
    public class Cliente
    {
        [JsonProperty(PropertyName = "cpf")]
        public string CPF { get; private set; }
        
        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; private set; }
        
        [JsonProperty(PropertyName = "estado")]
        public string Estado { get; private set; }
    }
}
