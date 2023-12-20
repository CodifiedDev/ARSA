using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ARSA
{
    internal class fullStackRun
    {
        public static async void Main(string subreddit, string inputPath, string outputPath, int numberofVideos)
        {
            if (numberofVideos > 25)
            {
                throw new Exception("Number of videos must be less than 25");
            }
            if (!inputPath.Contains(".mp4"))
            {
                throw new Exception("Invalid input file");
            }
            if (!Directory.Exists(outputPath))
            {
                throw new Exception("Output directory does not exist");
            }
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/tmp");
            List<string> test = webScraper.getTopPostLinks("https://old.reddit.com/r/" + subreddit).Result;
            for (int i = 1; i < numberofVideos + 1; i++)
            {
                string url = "https://old.reddit.com" + test[i];
                var content = webScraper.getPostContent(url).Result;
                string fullscript = content.Title + @" \ " + content.Body;
                srtGenerator.generateSRT(fullscript);
                await textToSpeech.generateTTSFile(fullscript, i);
                videoCreation.createVideo(inputPath, outputPath, i);
            }
            Console.WriteLine("Done");
        }
    }
}
