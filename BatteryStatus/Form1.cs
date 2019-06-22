using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Speech.AudioFormat;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Speech.Synthesis;
namespace BatteryStatus
{
    public partial class Form1 : Form
    {
        private SpeechSynthesizer _voice;
        private bool _charging;
        private bool _chkAd;
        private bool _auxchk;
        readonly PowerStatus _status = SystemInformation.PowerStatus;


        public Form1()
        {
            InitializeComponent();
            SystemEvents.PowerModeChanged += PowerModeChanged;

        }

        private void PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            //PowerStatus ps = new PowerStatus();
            ShowPowerStatus();
            _charging = _status.PowerLineStatus == PowerLineStatus.Online;
            //switch (e.Mode)
            //{
            //    case PowerModes.Resume:

            //        break;
            //    case PowerModes.StatusChange:
            //        break;
            //    case PowerModes.Suspend:
            //        break;
            //    default:
            //        throw new ArgumentOutOfRangeException();
            //}

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowPowerStatus();
            _voice = new SpeechSynthesizer();
            _voice.SelectVoice("Microsoft Sabina Desktop");
            _charging = _status.PowerLineStatus == PowerLineStatus.Online;
            GetVoices();
        }

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

        private void ShowPowerStatus()
        {
            txtChargeStatus.Text = _status.BatteryChargeStatus == 0 ? "Normal" : _status.BatteryChargeStatus.ToString();
            txtFullLifetime.Text = _status.BatteryFullLifetime == -1 ? "Unknown" : _status.BatteryFullLifetime.ToString();
            txtCharge.Text = _status.BatteryLifePercent.ToString("P0");
            txtLifeRemaining.Text = _status.BatteryLifeRemaining == -1 ? "Unknown" : _status.BatteryLifeRemaining.ToString();
            txtLineStatus.Text = _status.PowerLineStatus.ToString();
        }

        private void TmCheckPower_Tick(object sender, EventArgs e)
        {
            ShowPowerStatus();
            if (_charging || !(_status.BatteryLifePercent < .1) || _auxchk) return;
            _voice.SpeakAsync(@"Batería por debajo del 10 %. Conecte la fuente de poder");
            _auxchk = true;
            TmWaitForResp.Enabled = true;
        }

        #region Speak buttons
        private void BtnSpeak_Click(object sender, EventArgs e)
        {
            try
            {
                _voice.SpeakAsync($@"Batería al {txtCharge.Text}");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPause_Click(object sender, EventArgs e)
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

        private void BtnResume_Click(object sender, EventArgs e)
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
        #endregion

        private void TmWaitForResp_Tick(object sender, EventArgs e)
        {
            if (!_chkAd)
                _auxchk = false;
            TmWaitForResp.Enabled = false;
        }

        private void BtnChecked_Click(object sender, EventArgs e)
        {
            _chkAd = true;
            TmWaitForResp.Enabled = false;
            if (!_charging)
                _voice.SpeakAsync("No se ha detectado la conexión, puede perder información no salvada");
        }
    }
}
