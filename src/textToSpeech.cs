using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace ARSA
{
    internal class textToSpeech
    {
        public static async Task generateTTSFile(string script, int id)
        {
            //Speech Synthesiser needs to be initalised, this may limit the avaliable systems to Windows?
            SpeechSynthesizer synthesizer = new();
            //Volume may need to be set to 100, this was established as part of earlier debugging, and it works so I will not change it
            synthesizer.Volume = 100;
            synthesizer.Rate = 2;
            //The output may need to send a method once writing is done, to allow for the tmp directory to be deleted
            synthesizer.SetOutputToWaveFile(Directory.GetCurrentDirectory() + "/tmp/ttsaudio-" + id + ".wav");
            //This could be done async, but it works this way
            synthesizer.Speak(script);
        }
    }
}
