using Newtonsoft.Json;
using Stech.AppCalculoConsumo.Dominio.Interface;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Stech.AppCalculoConsumo.Infra.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal string PutRoute { get; set; }
        internal string GetRoute { get; set; }
        private readonly string _endpoint;
        HttpClient client;

        public Repository(string endpoint)
        {
            client = new HttpClient();
            _endpoint = endpoint;
        }

        public async Task<IEnumerable<T>> Get(Dictionary<string, string> parametros)
        {
            var response = await client.GetStringAsync($"{_endpoint}{GetRoute}{GetQueryStringParametros(parametros)}");

            return JsonConvert.DeserializeObject<List<T>>(response);
        }

        private static string GetQueryStringParametros(Dictionary<string, string> parametros)
        {

            var query = HttpUtility.ParseQueryString(string.Empty);
            if (parametros != null)
            {
                foreach (var parametro in parametros)
                    query[parametro.Key] = parametro.Value;
            }

            return $"?{query.ToString()}";
        }

        public async Task Put(Dictionary<string, string> parametros)
        {
            try
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put,$"{_endpoint}{PutRoute}{GetQueryStringParametros(parametros)}");
                var response = await client.SendAsync(requestMessage);
            }
            catch (HttpRequestException requestException)
            {
                throw requestException;
            }
        }
    }
}
