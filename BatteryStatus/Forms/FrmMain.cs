using System;
using System.Windows.Forms;
using BatteryStatus.Utilities;
using Microsoft.Win32;

namespace BatteryStatus.Forms
{
    public partial class FrmMain : Form
    {
        public Voice Voice;
        public Battery Battery;
        public PcInnactivity PcInnactivity;

        private RegistryKey _reg;
        private const string ApplicationName = "BatteryStatus";
        private string _applicationPath;

        private bool _voiceNotify;

        private uint _timeBattChk = 1;
        private uint _auxTimeBattChk = 1;
        private readonly bool _show;

        public FrmMain(bool show)
        {
            InitializeComponent();
            _show = show;
        }

        #region FormEvents
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Battery = new Battery();
                SystemEvents.PowerModeChanged += PowerModeChanged;
                ShowPowerStatus();
                Voice = new Voice(VoiceCompleted);
                PcInnactivity = new PcInnactivity();

                AutoRunLoad();

                TmCheckPower.Start();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            if (_show) return;
            WindowState = FormWindowState.Minimized;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e) => Voice?.Close();

        private void FrmMain_Move(object sender, EventArgs e)
        {
            //Check when the app is minimized and hide it.
            if (WindowState != FormWindowState.Minimized) return;
            Hide();
        }

        private void ShowForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        #endregion

        #region AutoRun
        private void AutoRunLoad()
        {
            _reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            var autoRun = _reg?.GetValue(ApplicationName) != null;
            ChBAutoRun.Checked = autoRun;
            ChBAutoRun.CheckStateChanged += ChBAutoRun_CheckStateChanged;
            _applicationPath = System.Reflection.Assembly.GetEntryAssembly()?.Location;
        }

        private void ChBAutoRun_CheckStateChanged(object sender, EventArgs e) => ChangeAutoRun(((CheckBox)sender).Checked);

        public void ChangeAutoRun(bool autoRun)
        {
            try
            {
                if (autoRun)
                    _reg.SetValue(ApplicationName, $"{_applicationPath} auto");
                else
                    _reg?.DeleteValue(ApplicationName);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

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
        private void NewNotification(string msg)
        {
            BtnChecked.Enabled = true;
            if (_voiceNotify)
                Voice.AddMessage(msg);
            notifyIcon1.ShowBalloonTip(1000, "Notificación del estado de batería", msg, ToolTipIcon.Info);
        }

        private void BtnChecked_Click(object sender, EventArgs e)
        {
            Battery.Checked();
            TmWaitForResp.Enabled = false;
            BtnChecked.Enabled = false;
            if (!Battery.Charging)
                NewNotification("No se ha detectado la conexión, puede perder información no salvada");
        }

        #region Speak Actions
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
        private void VoiceCompleted() => Invoke(new Action(() =>
        {
            BtnPause.Enabled = false;
            BtnSpeak.Enabled = true;
        }));

        #endregion

        #region MenuStrip
        private void VoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Recall for check if ther is an installed voice.
            Voice.GetVoices();
            var voiceSettings = new VoiceSettings(Voice);
            voiceSettings.ShowDialog();
            if (!voiceSettings.Changes) return;
            Voice.ChangeCurrentVoice(voiceSettings.Voice.CurrenVoice);
            Voice.ChangeNotVolume(voiceSettings.Voice.NotVolume);
        }

        private void NotificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var notSetTime = new NotSetTime(_timeBattChk, _auxTimeBattChk);
            notSetTime.ShowDialog();
            if (!notSetTime.Changes) return;
            TmCheckPower.Stop();
            TmWaitForResp.Stop();
            _timeBattChk = notSetTime.TimeBattChk;
            _auxTimeBattChk = notSetTime.AuxTimeBattChk;
            TmCheckPower.Interval = (int)_timeBattChk * 1000;
            TmWaitForResp.Interval = (int)_auxTimeBattChk * 60000;
            TmCheckPower.Start();
            TmWaitForResp.Start();
        }

        #endregion

        #region ContextMenuStrip
        private void ShowToolStripMenuItem_Click(object sender, EventArgs e) => ShowForm();

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e) => Close();
        #endregion

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) => ShowForm();
    }
}
