using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gestionSerie.classes
{
    class RestService
    {
        HttpClient client;
        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<List<Serie>> loadAllSerie()
        {
            string restUrl = "http://172.19.0.42/test.json";
            var uri = new Uri(string.Format(restUrl, string.Empty));
            List<Serie> items = new List<Serie>();
            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<Serie>>(content);
                    return items;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}
