using System;
using System.Windows.Forms;
using BatteryStatus.Utilities;

namespace BatteryStatus.Forms
{
    public partial class VoiceSettings : Form
    {
        public Voice Voice { get; }
        public bool Changes { get; private set; }

        public VoiceSettings(Voice voice)
        {
            InitializeComponent();
            Voice = voice;
        }

        private void VoiceSettings_Load(object sender, EventArgs e)
        {
            var voices = Voice.Voices;
            if (voices == null) return;
            // ReSharper disable once CoVariantArrayConversion
            CbVoices.Items.AddRange(voices.ToArray());
            var ind = voices.FindIndex(x => x.Contains(Voice.CurrenVoice));
            CbVoices.SelectedIndex = ind;
            NudTestVol.ValueChanged += TestVol_ValueChanged;
            TbTestVol.ValueChanged += TestVol_ValueChanged;
            NudNotVol.ValueChanged += NotVol_ValueChanged;
            TbNotVol.ValueChanged += NotVol_ValueChanged;
            NudNotVol.Value = Voice.NotVolume;
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
            Voice.ChangeCurrentVoice(CbVoices.SelectedItem.ToString());
            Voice.ChangeSyntVolume(TbTestVol.Value);
            Voice.AddMessage(TbTest.Text);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Voice.ChangeCurrentVoice(CbVoices.SelectedItem.ToString());
            Voice.ChangeSyntVolume(TbTestVol.Value);
            Changes = true;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e) => Close();

        private void TbTest_TextChanged(object sender, EventArgs e) => BtnRead.Enabled = TbTest.Text.Length > 0;
    }
}
