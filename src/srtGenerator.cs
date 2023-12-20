using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using SubtitlesParser;
using SubtitlesParser.Classes;

namespace ARSA
{
    internal class srtGenerator
    {
        public static void generateSRT(string script)
        {
            List<string> scriptList = script.Split(@" ").ToList();
            int currentTime = 0;
            // List<SubtitleItem> words = new List<SubtitleItem>();
            // foreach (string word in scriptList)
            // {
            //     SubtitleItem subtitle = new SubtitleItem();
            //     subtitle.StartTime = currentTime;
            //     currentTime += 275;
            //     subtitle.EndTime = currentTime;
            //     subtitle.Lines.Add(word);
            //     words.Add(subtitle);
            // }

            var words = scriptList.Select(word => new SubtitleItem
            {
                StartTime = currentTime,
                EndTime = currentTime += 275,
                Lines = new List<string> { word }
            });
            
            var writer = new SubtitlesParser.Classes.Writers.SrtWriter();
            using (var fileStream = File.OpenWrite(Directory.GetCurrentDirectory() + @"\tmp\script.srt"))
            {
                writer.WriteStream(fileStream, words);
            }
        }

    }
}
