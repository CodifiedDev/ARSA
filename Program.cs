// See https://aka.ms/new-console-template for more information
using ARSA;


List<string> test = webScraper.getTopPostLinks("https://old.reddit.com/r/AITAH").Result;
for (int i = 0; i < 1; i++)
{
    string url = "https://old.reddit.com" + test[1];
    var contnet = webScraper.getPostContent(url).Result;
    foreach (var contents in contnet)
    {
        Console.WriteLine(contents);
    }
}