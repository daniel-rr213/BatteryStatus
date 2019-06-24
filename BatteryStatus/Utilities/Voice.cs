using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;

using AudioSwitcher.AudioApi.CoreAudio;

namespace BatteryStatus
{
    public class Voice
    {
        private readonly SpeechSynthesizer _voice;
        private readonly Queue<string> _msgs;
        private Thread _thSpeakMsgs;
        private readonly Action _spkCompleted;

        private readonly CoreAudioDevice _defaultPlaybackDevice;
        private double _vol;

        public Voice(Action speakCompleted)
        {
            _voice = new SpeechSynthesizer();
            _voice.SelectVoice("Microsoft Sabina Desktop");
            _msgs = new Queue<string>();
            _spkCompleted = speakCompleted;
            _voice.StateChanged += _voice_StateChanged;
            _defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
        }

        private void _voice_StateChanged(object sender, StateChangedEventArgs e)
        {
            if (e.State != SynthesizerState.Ready) return;
            if (_msgs.Count > 0) return;
            _spkCompleted();
        }

        public void Close() => _thSpeakMsgs?.Abort();

        public void GetVoices()
        {
            // Initialize a new instance of the SpeechSynthesizer.  
            using (var synth = new SpeechSynthesizer())
            {

                // Output information about all of the installed voices.   
                Console.WriteLine(@"Installed voices -");
                foreach (var voice in synth.GetInstalledVoices())
                {
                    var info = voice.VoiceInfo;
                    var audioFormats = "";
                    foreach (var fmt in info.SupportedAudioFormats)
                    {
                        audioFormats += $"{fmt.EncodingFormat.ToString()}\n";
                    }

                    Console.WriteLine(@" Name:          " + info.Name);
                    Console.WriteLine(@" Culture:       " + info.Culture);
                    Console.WriteLine(@" Age:           " + info.Age);
                    Console.WriteLine(@" Gender:        " + info.Gender);
                    Console.WriteLine(@" Description:   " + info.Description);
                    Console.WriteLine(@" ID:            " + info.Id);
                    Console.WriteLine(@" Enabled:       " + voice.Enabled);
                    Console.WriteLine(info.SupportedAudioFormats.Count != 0
                        ? $@" Audio formats: {audioFormats}"
                        : @" No supported audio formats found");

                    var additionalInfo = info.AdditionalInfo.Keys.Aggregate("", (current, key) => current + $"  {key}: {info.AdditionalInfo[key]}\n");

                    Console.WriteLine($@" Additional Info - {additionalInfo}");
                    Console.WriteLine();
                }
            }
        }

        public void AddMessage(string msg)
        {
            _msgs.Enqueue(msg);
            _vol = _defaultPlaybackDevice.Volume;
            _defaultPlaybackDevice.Volume = 80;
            if (_thSpeakMsgs != null) return;
            _thSpeakMsgs = new Thread(SpeakMsgs);
            _thSpeakMsgs.Start();
        }

        private void SpeakMsgs()
        {
            if (_voice.State != SynthesizerState.Paused)
                while (_msgs.Count > 0)
                    _voice.Speak(_msgs.Dequeue());
            _defaultPlaybackDevice.Volume = _vol;
            _thSpeakMsgs = null;
        }

        public void Pause()
        {
            try
            {
                _voice.Pause();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Resume()
        {
            try
            {
                _voice.Resume();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
