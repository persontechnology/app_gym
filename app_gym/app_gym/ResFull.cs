using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace app_gym
{
    public class ResFull
    {
        public const string urlbase = "https://thespartansgym.com/";
        public async Task<T> Get<T>(string url)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                var contenido = await cliente.GetAsync(url);
                if (contenido.StatusCode == HttpStatusCode.OK || contenido.Content != null)
                {
                    var json = await contenido.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json);

                }
            }
            catch (Exception)
            {

                throw;
            }
            return default(T);
        }
    }
}
