using DesafioMOBRJ2.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesafioMOBRJ2.Services
{
    public class ApiReadingService
    {
        private HttpClient _client = new HttpClient();
        
        public async Task<States> GetApi()
        {
            try
            {
                string url = string.Format("https://api.airtable.com/v0/app0RCW0xYP8RT3U9/Estados?api_key=keyhS9s7U3bGKSuml");
                var response = await _client.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {   
                }
                    var content = await response.Content.ReadAsStringAsync();
                    var leitura = JsonConvert.DeserializeObject<States>(content);
                return leitura;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}