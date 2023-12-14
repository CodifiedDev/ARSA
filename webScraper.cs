using HtmlAgilityPack;
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
        public async static Task<List<string>> getTopPostLinks(string htmlDATA)
        {
            //htmlDATA will be unparsed data, preferably taken from getWebPage, It is assumed that the data is coming from a https://old.reddit.com/r/subreddit
            var doc = new HtmlDocument();
            doc.LoadHtml(htmlDATA);
            //HtmlAgilityPack then needs to find all p tags with the class title
            IEnumerable<HtmlNode> nodes = doc.DocumentNode.Descendants("a").Where(node => node.HasClass("title"));
            //Before all items are looped through a list is created to store all the links
           List<string> links = new List<string>();
            foreach (HtmlNode node in nodes)
            {
                //HtmlAgilityPack is used again to get the href elements of of the anchors
                string link = node.GetAttributeValue("href", "");
                //All advertising links must be removed, this is done by ignoring all links that contain 'https://', this is because all advertising links are external
                if (!link.Contains("https://"))
                {
                    //ALL Links are added to the list, this will be trucanted to the desired amount when deciding to parse the data, not at this stage.
                    links.Add(link);
                }
            }
            return links;
        }
    }
}
