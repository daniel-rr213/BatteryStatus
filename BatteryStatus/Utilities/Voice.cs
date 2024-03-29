﻿using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;

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
        public uint NotVolume = 60;
        private Thread ThVolumeSett { get; }
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
                ThVolumeSett = new Thread(ThLoadVolumeSett);
                ThVolumeSett.Start();
            }
            catch (Exception exc)
            {
                throw new Exception($"Error en la configuración de la voz de la aplicación:\n{exc.Message}");
            }
        }

        #region LoadMeethods
        public void GetVoices()
        {
            var installedVoices = _synth.GetInstalledVoices();
            // Variable for debug.
            var installedVoicesCount = installedVoices.Count;
            //installedVoicesCount = 0;
            if (installedVoicesCount == 0) throw new Exception(@"No se encontraron voces instaladas");
            if (Voices == null)
                Voices = new List<string>();
            // Output information about all of the installed voices.
            Debug.WriteLine(@"Installed voices -");
            foreach (var voice in installedVoices)
            {
                var info = voice.VoiceInfo;
                var infoDescription = info.Description;
                string auxvoice;
                if (infoDescription.StartsWith("Microsoft"))
                    auxvoice = infoDescription;
                else
                {
                    //auxvoice = info.Name;
                    continue;
                }
                if (!Voices.Contains(auxvoice))
                    Voices.Add(auxvoice);
                var audioFormats = "";
                foreach (var fmt in info.SupportedAudioFormats)
                    audioFormats += $"{fmt.EncodingFormat.ToString()}\n";

                Debug.WriteLine(@" Name:          " + info.Name);
                Debug.WriteLine(@" Culture:       " + info.Culture);
                Debug.WriteLine(@" Age:           " + info.Age);
                Debug.WriteLine(@" Gender:        " + info.Gender);
                Debug.WriteLine(@" Description:   " + infoDescription);
                Debug.WriteLine(@" ID:            " + info.Id);
                Debug.WriteLine(@" Enabled:       " + voice.Enabled);
                Debug.WriteLine(info.SupportedAudioFormats.Count != 0
                    ? $@" Audio formats: {audioFormats}"
                    : @" No supported audio formats found");

                Debug.WriteLine($@" Additional Info - {info.AdditionalInfo.Keys.Aggregate("", (current, key) => current + $"  {key}: {info.AdditionalInfo[key]}\n")}");
            }
        }

        public string GetMicrosoftVoiceName(string voice)
        {
            var voiceName = voice.Split('-');
            return voiceName[0].Trim();
        }

        public void ChangeCurrentVoice(string voice)
        {
            CurrenVoice = voice;
            var voiceName = "";
            if (voice.StartsWith("Microsoft"))
                voiceName = GetMicrosoftVoiceName(CurrenVoice);
            else if (voice.StartsWith("eSpeak"))
                voiceName = voice;
            SelectVoice(voiceName);
        }
        private void ThLoadVolumeSett()
        {
            _defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            Debug.WriteLine("Volume control Loaded");
        }
        #endregion

        public void Close()
        {
            _synth.StateChanged -= SynthStateChanged;
            _msgs.Clear();
        }

        private void SelectVoice(string voiceName) => _synth.SelectVoice(voiceName);

        public void ChangeSyntVolume(int vol) => _synth.Volume = vol;

        public void ChangeNotVolume(uint vol) => NotVolume = vol;

        private void SynthStateChanged(object sender, StateChangedEventArgs e)
        {
            if (e.State != SynthesizerState.Ready) return;
            if (_msgs.Count > 0) return;
            _spkCompleted();
        }

        public void AddMessage(string msg)
        {
            try
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
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        private void SpeakMsgs()
        {
            try
            {
                if (_synth.State != SynthesizerState.Paused)
                    while (_msgs.Count > 0)
                        _synth.Speak(_msgs.Dequeue());
                if (_defaultPlaybackDevice != null) _defaultPlaybackDevice.Volume = _prevVol;
                _thSpeakMsgs = null;
            }
            catch (Exception exc)
            {
                //Debug.WriteLine(exc.Message);
                throw new Exception(exc.Message);
            }
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