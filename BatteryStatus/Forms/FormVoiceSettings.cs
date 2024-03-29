﻿using BatteryStatus.Utilities;
using System;
using System.Windows.Forms;

namespace BatteryStatus.Forms
{
    public partial class FormVoiceSettings : Form
    {
        private readonly Voice _voice;
        public bool Changes { get; private set; }
        public string CurrenVoice => _voice.CurrenVoice;
        public uint NotVolume => _voice.NotVolume;

        public FormVoiceSettings(Voice voice)
        {
            InitializeComponent();
            _voice = voice;
        }

        private void VoiceSettings_Load(object sender, EventArgs e)
        {
            var voices = _voice.Voices;
            if (voices == null) return;
            var tbTestText = TbTest.Text;
            TbTest.Text = "";
            TbTest.Text = tbTestText;
            //Fill the Combo Box with available voices.
            // ReSharper disable once CoVariantArrayConversion
            CbVoices.Items.AddRange(voices.ToArray());
            //Select the spanish voice or the first.
            CbVoices.SelectedIndex = voices.FindIndex(x => x.Contains(_voice.CurrenVoice));
            //Concatenate the Numeric Up Down and Track bar value change event.
            NudTestVol.ValueChanged += TestVol_ValueChanged;
            TbTestVol.ValueChanged += TestVol_ValueChanged;
            NudNotVol.ValueChanged += NotVol_ValueChanged;
            TbNotVol.ValueChanged += NotVol_ValueChanged;
            //Set the Notification volume.
            NudNotVol.Value = _voice.NotVolume;
        }

        private void TestVol_ValueChanged(object sender, EventArgs e)
        {
            if (NudTestVol.Value == TbTestVol.Value) return;
            switch (sender)
            {
                case NumericUpDown ham:
                    TbTestVol.Value = (int)ham.Value;
                    break;

                case TrackBar ham:
                    NudTestVol.Value = ham.Value;
                    break;

                default:
                    MessageBox.Show($@"Control '{sender.GetType().Name}' no admitido", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void NotVol_ValueChanged(object sender, EventArgs e)
        {
            if (NudNotVol.Value == TbNotVol.Value) return;
            switch (sender)
            {
                case NumericUpDown ham:
                    TbNotVol.Value = (int)ham.Value;
                    break;

                case TrackBar ham:
                    NudNotVol.Value = ham.Value;
                    break;

                default:
                    MessageBox.Show($@"Control '{sender.GetType().Name}' no admitido", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            try
            {
                _voice.ChangeCurrentVoice(CbVoices.SelectedItem.ToString());
                _voice.ChangeSyntVolume(TbTestVol.Value);
                _voice.AddMessage(TbTest.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _voice.ChangeCurrentVoice(CbVoices.SelectedItem.ToString());
            _voice.ChangeSyntVolume(TbTestVol.Value);
            _voice.ChangeNotVolume((uint)NudNotVol.Value);
            Changes = true;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e) => Close();

        private void TbTest_TextChanged(object sender, EventArgs e) => BtnRead.Enabled = TbTest.Text.Length > 0;
    }
}