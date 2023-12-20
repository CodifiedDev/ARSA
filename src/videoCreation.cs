using FFMpegCore.Arguments;
using FFMpegCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARSA
{
    internal class videoCreation
    {
        public async static void createVideo(string inputPath, string outputPath, int id)
        { 
            //This current implemtation is CPU bound TODO: Fix
            Console.WriteLine("Creating Video File");
            Console.WriteLine("Removing Original Audio");
            FFMpegCore.FFMpeg.Mute(Directory.GetCurrentDirectory() + "/tmp/vids/test.mp4", Directory.GetCurrentDirectory() + "/tmp/silent.mp4");
            Console.WriteLine("Replacing Audio");
            FFMpegCore.FFMpeg.ReplaceAudio(Directory.GetCurrentDirectory() + "/tmp/silent.mp4", Directory.GetCurrentDirectory() + "/tmp/ttsaudio-" + id +".wav", Directory.GetCurrentDirectory() + "/tmp/audioreplaced.mp4");
            Console.WriteLine("Fixing Aspect Ratio and runtime");
            //This will make the video streched looking, as it is not changing the aspect ratio, but rather the resolution, Thus it is better for the input file to be this size
            //This method combines the Aspect ratio and subtitles, however the subtitles end up smooshed
            //FFMpegCore.FFMpegArguments.FromFileInput(Directory.GetCurrentDirectory() + "/tmp/audioreplaced.mp4").OutputToFile(Directory.GetCurrentDirectory() + "/tmp/final.mp4", true, options => options.Resize(1080, 1920).WithVideoFilters(filterOptions => filterOptions.HardBurnSubtitle(SubtitleHardBurnOptions.Create(Directory.GetCurrentDirectory() + "/tmp/script.srt")))).ProcessSynchronously();
            FFMpegCore.FFMpegArguments.FromFileInput(Directory.GetCurrentDirectory() + "/tmp/audioreplaced.mp4").OutputToFile(Directory.GetCurrentDirectory() + "/tmp/final.mp4", true, options => options.Resize(1080, 1920)).ProcessSynchronously();
            Console.WriteLine("Adding Subtitles");
            //Add subtitles from /tmp/subtitles.srt to the video via burning
            FFMpegCore.FFMpegArguments.FromFileInput(Directory.GetCurrentDirectory() + "/tmp/final.mp4").OutputToFile(Directory.GetCurrentDirectory() + "/tmp/finalsub.mp4", true, options => options.WithVideoFilters(filterOptions => filterOptions.HardBurnSubtitle(SubtitleHardBurnOptions.Create(Directory.GetCurrentDirectory() + "/tmp/script.srt")))).ProcessSynchronously();
            Console.WriteLine("Runtime Fixing");
            FFMpegCore.FFMpeg.SubVideo(Directory.GetCurrentDirectory() + "/tmp/finalsub.mp4", outputPath + "/finalshort-" + id + ".mp4", TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(60));
        }
    }
}
