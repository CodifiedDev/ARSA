using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARSA
{
    internal class webScraper
    {
        public async static Task<string> getWebPage(string url)
        {
            HttpClient http = new();
            //The user agent must be set to a valid browser or the request will be rejected
            http.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36 Edg/121.0.0.0");
            HttpResponseMessage response = await http.GetAsync(new Uri(url));
            string jsonResponse = await response.Content.ReadAsStringAsync();
            //This is unparsed data, It will not be readable
            return jsonResponse;
        }
    }
}
