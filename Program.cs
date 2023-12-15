// See https://aka.ms/new-console-template for more information
using ARSA;

Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/tmp");
/*List<string> test = webScraper.getTopPostLinks("https://old.reddit.com/r/AITAH").Result;
for (int i = 0; i < 1; i++)
{
    string url = "https://old.reddit.com" + test[1];
    var contnet = webScraper.getPostContent(url).Result;
    foreach (var contents in contnet)
    {
        Console.WriteLine(contents);
    }
} */
List<string> test = webScraper.getTopPostLinks("https://old.reddit.com/r/AITAH").Result;
string url = "https://old.reddit.com" + test[1];
var contnet = webScraper.getPostContent(url).Result;
string fullscript = contnet[0] + @" \ " + contnet[1];
textToSpeech.generateTTSFile(fullscript);
videoCreation.createVideo();
//Directory.Delete(Directory.GetCurrentDirectory() + "/tmp", true);