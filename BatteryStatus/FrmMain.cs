using System;
using System.Windows.Forms;
using Microsoft.Win32;
namespace BatteryStatus
{
    public partial class FrmMain : Form
    {
        public Voice Voice;
        public Battery Battery;
        public PcInnactivity PcInnactivity;

        private RegistryKey _reg;
        private string _applicationName = "BatteryStatus";
        private string _applicationPath;

        private bool _voiceNotify;
        public FrmMain() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
            Battery = new Battery();
            SystemEvents.PowerModeChanged += PowerModeChanged;
            ShowPowerStatus();
            Voice = new Voice(VoiceCompleted);
            PcInnactivity = new PcInnactivity();

            AutoRunCheck();
        }

        private void AutoRunCheck()
        {
            _reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            var autoRun = _reg?.GetValue(_applicationName) != null;
            ChBAutoRun.Checked = autoRun;
            ChBAutoRun.CheckStateChanged += ChBAutoRun_CheckStateChanged;
            _applicationPath = System.Reflection.Assembly.GetEntryAssembly()?.Location;
        }

        private void ChBAutoRun_CheckStateChanged(object sender, EventArgs e) => ChangeAutoRun(((CheckBox)sender).Checked);

        private void VoiceCompleted() => Invoke(new Action(() =>
        {
            BtnPause.Enabled = false;
            BtnSpeak.Enabled = true;
        }));

        private void PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            ShowPowerStatus();
            Battery.PowerModeChanged();
            if (Battery.Charging && Battery.Alert == Battery.Alerts.LowBattery)
                BtnChecked.Enabled = false;
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
            var idleTimeMin = PcInnactivity.GetIdleTimeMin();
            _voiceNotify = idleTimeMin > PcInnactivity.MaxIdleTime;
            TbIdleTime.Text = idleTimeMin.ToString("D");
            if (!Battery.CheckPower()) return;
            NewNotification(Battery.Msg);
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
                NewNotification("No se ha detectado la conexión, puede perder información no salvada");
        }

        #region Speak buttons
        private void BtnSpeak_Click(object sender, EventArgs e)
        {
            try
            {
                //NewNotification($@"Batería al {txtCharge.Text}");
                Voice.AddMessage($@"Batería al {txtCharge.Text}");
                if (!_voiceNotify) return;
                BtnPause.Enabled = true;
                BtnSpeak.Enabled = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (!_voiceNotify) return;
            Voice.Pause();
            BtnResume.Enabled = true;
            BtnPause.Enabled = false;
        }

        private void BtnResume_Click(object sender, EventArgs e)
        {
            if (!_voiceNotify) return;
            Voice.Resume();
            BtnPause.Enabled = true;
            BtnResume.Enabled = false;
        }

        #endregion

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e) => Voice.Close();

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e) => ShowForm();

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void FrmMain_Move(object sender, EventArgs e)
        {
            //Check when the app is minimized and hide it.
            if (WindowState != FormWindowState.Minimized) return;
            Hide();
        }

        private void NewNotification(string msg)
        {
            if (_voiceNotify)
            {
                BtnChecked.Enabled = true;
                Voice.AddMessage(msg);
            }
            notifyIcon1.ShowBalloonTip(1000, "Notificación del estado de batería", msg, ToolTipIcon.Info);
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) => ShowForm();

        private void ShowForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        public void ChangeAutoRun(bool autoRun)
        {
            try
            {
                if (autoRun)
                    _reg.SetValue(_applicationName, $"{_applicationPath} auto");
                else
                    _reg?.DeleteValue(_applicationName);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
