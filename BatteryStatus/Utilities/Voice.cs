using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;
using AudioSwitcher.AudioApi.CoreAudio;

namespace BatteryStatus.Utilities
{
    public class Voice
    {
        private readonly SpeechSynthesizer _synth;
        public List<string> Voices { get; private set; }
        private readonly Queue<string> _msgs;
        private Thread _thSpeakMsgs;
        private readonly Action _spkCompleted;

        private CoreAudioDevice _defaultPlaybackDevice;
        private double _prevVol;
        public int NotVolume = 60;
        private readonly Thread _thVolumeSett;
        public string CurrenVoice { get; private set; }

        public Voice(Action speakCompleted)
        {
            //TODO:Check Voices.Count>0
            try
            {
                _synth = new SpeechSynthesizer();
                GetVoices();
                ChangeCurrentVoice(Voices.FirstOrDefault(x => x.Contains("Spanish")) ?? Voices[0]);
                _msgs = new Queue<string>();
                _spkCompleted = speakCompleted;
                _synth.StateChanged += SynthStateChanged;
                _thVolumeSett = new Thread(ThLoadVolumeSett);
                _thVolumeSett.Start();
            }
            catch (Exception exc)
            {
                throw new Exception($"Error in voice settings.\n{exc}");
            }
        }
        public void GetVoices()
        {
            var installedVoices = _synth.GetInstalledVoices();
            if (installedVoices.Count == 0) throw new Exception(@"No se encontraron voces instaladas");
            if (Voices == null)
                Voices = new List<string>();
            // Output information about all of the installed voices.
            Debug.WriteLine(@"Installed voices -");
            foreach (var voice in installedVoices)
            {
                var info = voice.VoiceInfo;
                if (!Voices.Contains(info.Description))
                    Voices.Add(info.Description);
                var audioFormats = "";
                foreach (var fmt in info.SupportedAudioFormats)
                    audioFormats += $"{fmt.EncodingFormat.ToString()}\n";

                Debug.WriteLine(@" Name:          " + info.Name);
                Debug.WriteLine(@" Culture:       " + info.Culture);
                Debug.WriteLine(@" Age:           " + info.Age);
                Debug.WriteLine(@" Gender:        " + info.Gender);
                Debug.WriteLine(@" Description:   " + info.Description);
                Debug.WriteLine(@" ID:            " + info.Id);
                Debug.WriteLine(@" Enabled:       " + voice.Enabled);
                Debug.WriteLine(info.SupportedAudioFormats.Count != 0
                    ? $@" Audio formats: {audioFormats}"
                    : @" No supported audio formats found");

                var additionalInfo = info.AdditionalInfo.Keys.Aggregate("", (current, key) => current + $"  {key}: {info.AdditionalInfo[key]}\n");

                Debug.WriteLine($@" Additional Info - {additionalInfo}");
            }
        }

        public string GetVoiceName(string voice)
        {
            var voiceName = voice.Split('-');
            return voiceName[0].Trim();
        }

        public void ChangeCurrentVoice(string voice)
        {
            CurrenVoice = voice;
            SelectVoice(GetVoiceName(CurrenVoice));
        }

        private void ThLoadVolumeSett()
        {
            _defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            Debug.WriteLine("Volume control Loaded");
        }

        public void Close()
        {
            _thSpeakMsgs?.Abort();
            _thVolumeSett?.Abort();
        }

        private void SelectVoice(string voiceName) => _synth.SelectVoice(voiceName);

        public void ChangeSyntVolume(int vol) => _synth.Volume = vol;

        public void ChangeNotVolume(int vol) => NotVolume = vol;

        private void SynthStateChanged(object sender, StateChangedEventArgs e)
        {
            if (e.State != SynthesizerState.Ready) return;
            if (_msgs.Count > 0) return;
            _spkCompleted();
        }


        public void AddMessage(string msg)
        {
            _msgs.Enqueue(msg);
            if (_defaultPlaybackDevice != null)
            {
                _prevVol = _defaultPlaybackDevice.Volume;
                _defaultPlaybackDevice.Volume = NotVolume;
            }
            if (_thSpeakMsgs != null) return;
            _thSpeakMsgs = new Thread(SpeakMsgs);
            _thSpeakMsgs.Start();
            Debug.WriteLine($"Launching new thread with the message: {msg}");
        }

        private void SpeakMsgs()
        {
            if (_synth.State != SynthesizerState.Paused)
                while (_msgs.Count > 0)
                    _synth.Speak(_msgs.Dequeue());
            if (_defaultPlaybackDevice != null) _defaultPlaybackDevice.Volume = _prevVol;
            _thSpeakMsgs = null;
        }

        public void Pause()
        {
            try
            {
                _synth.Pause();
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
                _synth.Resume();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
