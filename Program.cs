// See https://aka.ms/new-console-template for more information
using ARSA;


string webdata = webScraper.getWebPage("https://old.reddit.com/r/AITAH").Result;
List<string> test = webScraper.getTopPostLinks(webdata).Result;
