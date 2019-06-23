using System;
using System.Windows.Forms;
using Microsoft.Win32;
namespace BatteryStatus
{
    public partial class FrmMain : Form
    {
        public Voice Voice;
        public Battery Battery;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Battery = new Battery();
            SystemEvents.PowerModeChanged += PowerModeChanged;
            ShowPowerStatus();
            //Voice = new Voice();
            Voice = new Voice(VoiceCompleted);
        }

        private void VoiceCompleted() => Invoke(new Action(() =>
        {
            BtnPause.Enabled = false;
            BtnSpeak.Enabled = true;
        }));

        private void PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            ShowPowerStatus();
            Battery.PowerModeChanged();
        }

        private void ShowPowerStatus()
        {

            txtChargeStatus.Text = Battery.ChargeStatus;
            txtFullLifetime.Text = Battery.BatteryFullLifetime;
            txtCharge.Text = Battery.BatteryLifePercent;
            txtLifeRemaining.Text = Battery.BatteryLifeRemaining;
            txtLineStatus.Text = Battery.PowerLineStatus;
        }

        private void TmCheckPower_Tick(object sender, EventArgs e)
        {
            ShowPowerStatus();
            if (!Battery.CheckPower()) return;
            BtnChecked.Enabled = true;
            Voice.AddMessage(Battery.Msg);
            TmWaitForResp.Enabled = true;
        }

        private void TmWaitForResp_Tick(object sender, EventArgs e)
        {
            Battery.WaitForResp();
            TmWaitForResp.Enabled = false;
        }

        private void BtnChecked_Click(object sender, EventArgs e)
        {
            Battery.Checked();
            TmWaitForResp.Enabled = false;
            BtnChecked.Enabled = false;
            if (!Battery.Charging)
                Voice.AddMessage("No se ha detectado la conexión, puede perder información no salvada");
        }

        #region Speak buttons
        private void BtnSpeak_Click(object sender, EventArgs e)
        {
            try
            {
                Voice.AddMessage($@"Batería al {txtCharge.Text}");
                BtnPause.Enabled = true;
                //BtnSpeak.Enabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            Voice.Pause();
            BtnResume.Enabled = true;
            BtnPause.Enabled = false;
        }

        private void BtnResume_Click(object sender, EventArgs e)
        {
            Voice.Resume();
            BtnPause.Enabled = true;
            BtnResume.Enabled = false;
        }

        #endregion

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Voice.Close();
        }
    }
}
