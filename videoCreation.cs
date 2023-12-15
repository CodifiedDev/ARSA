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
        public async static void createVideo()
        { 
            //This current implemtation is CPU bound TODO: Fix
            Console.WriteLine("Creating Video File");
            Console.WriteLine("Removing Original Audio");
            FFMpegCore.FFMpeg.Mute(Directory.GetCurrentDirectory() + "/tmp/vids/test.mp4", Directory.GetCurrentDirectory() + "/tmp/silent.mp4");
            Console.WriteLine("Replacing Audio");
            FFMpegCore.FFMpeg.ReplaceAudio(Directory.GetCurrentDirectory() + "/tmp/silent.mp4", Directory.GetCurrentDirectory() + "/tmp/ttsaudio.wav", Directory.GetCurrentDirectory() + "/tmp/audioreplaced.mp4");
            Console.WriteLine("Fixing Aspect Ratio and runtime");
            FFMpegCore.FFMpegArguments.FromFileInput(Directory.GetCurrentDirectory() + "/tmp/audioreplaced.mp4").OutputToFile(Directory.GetCurrentDirectory() + "/tmp/final.mp4", true, options => options.Resize(1080, 1920)).ProcessSynchronously();
            Console.WriteLine("Runtime Fixing");
            FFMpegCore.FFMpeg.SubVideo(Directory.GetCurrentDirectory() + "/tmp/final.mp4", Directory.GetCurrentDirectory() + "/tmp/finalshort.mp4", TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(60));
        }
    }
}
