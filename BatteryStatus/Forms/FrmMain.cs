using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BatteryStatus.Utilities;
using Microsoft.Win32;
using static BatteryStatus.Forms.ModifyProgressBarColor;

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

        public Colors PbColor;
        private bool _auxVoiceNotify;

        public FrmMain(bool show)
        {
            InitializeComponent();
            _show = show;
        }

        #region FormEvents
        private void Form1_Load(object sender, EventArgs e)
        {
            AutoRunLoad();
            Battery = new Battery();
            PcInnactivity = new PcInnactivity();
            SystemEvents.PowerModeChanged += PowerModeChanged;
            ShowPowerStatus();
            BtnChecked.EnabledChanged += BtnChecked_EnabledChanged;
            //BtnSpeak.EnabledChanged += BtnChecked_EnabledChanged;
            try
            {
                Voice = new Voice(VoiceCompleted);
                BtnSpeak.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TmCheckPower.Start();
        }

        private void BtnChecked_EnabledChanged(object sender, EventArgs e) => BtnChecked.BackColor = ((Button)sender).Enabled ? Color.FromArgb(0, 192, 0) : SystemColors.Control;

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
            if (Battery.IsCharging && Battery.Alert == Battery.Alerts.LowBattery)
                AlertChecked();

            if (!Battery.IsCharging && Battery.Alert == Battery.Alerts.HighBattery)
                AlertChecked();
        }

        private void ShowPowerStatus()
        {
            TbChargeStatus.Text = Battery.ChargeStatus;
            TbFullLifetime.Text = Battery.BatteryFullLifetime;
            ChangeCharge();
            TbLifeRemaining.Text = Battery.BatteryLifeRemaining;
            TbLineStatus.Text = Battery.PowerLineStatus;
        }

        private void ChangeCharge()
        {
            var percent = Battery.BatteryLifePercent;
            LbCharge.Text = percent.ToString("P0");
            percent *= 100;
            PbCharge.Value = (int)percent;
            if (percent < Battery.LowBattLevel || percent > Battery.HighBattLevel)
            {
                PbColor = Colors.Red;
                PbCharge.SetState((int)PbColor);
            }
            else if (PbColor == Colors.Red)
            {
                PbColor = Colors.Green;
                PbCharge.SetState((int)PbColor);
            }
        }

        private void TmCheckPower_Tick(object sender, EventArgs e)
        {
            ShowPowerStatus();
            var idleTimeMin = PcInnactivity.GetIdleTimeMin();
            _voiceNotify = idleTimeMin >= PcInnactivity.MaxIdleTime;
            TbIdleTime.Text = idleTimeMin.ToString("D");
            if (!Battery.CheckPowerLevel()) return;
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

        private void BtnChecked_Click(object sender, EventArgs e) => AlertChecked();

        private void AlertChecked()
        {
            var _checked = Battery.Checked();
            TmWaitForResp.Enabled = false;
            if (!_checked)
                NewNotification(Battery.Msg);
            BtnChecked.Enabled = false;
        }

        #region Speak Actions
        private void BtnSpeak_Click(object sender, EventArgs e)
        {
            _auxVoiceNotify = _voiceNotify;
            if (!_auxVoiceNotify) _auxVoiceNotify = true;
            SpeakInfo();
        }

        private void SpeakInfo()
        {
            try
            {
                //NewNotification($@"Batería al {txtCharge.Text}");
                Voice.AddMessage($@"Batería al {LbCharge.Text}");
                if (!_voiceNotify || !_auxVoiceNotify) return;
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
            if (!_voiceNotify || !_auxVoiceNotify) return;
            Voice.Pause();
            BtnResume.Enabled = true;
            BtnPause.Enabled = false;
        }

        private void BtnResume_Click(object sender, EventArgs e)
        {
            if (!_voiceNotify || !_auxVoiceNotify) return;
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
            try
            {
                //Recall for check if ther is an installed voice.
                Voice.GetVoices();
                var voiceSettings = new FormVoiceSettings(Voice);
                voiceSettings.ShowDialog();
                if (!voiceSettings.Changes) return;
                Voice.ChangeCurrentVoice(voiceSettings.CurrenVoice);
                Voice.ChangeNotVolume(voiceSettings.NotVolume);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NotificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmNotSetTime = new FrmNotSetTime(_timeBattChk, _auxTimeBattChk, PcInnactivity.MaxIdleTime, Battery.LowBattLevel, Battery.HighBattLevel);
            frmNotSetTime.ShowDialog();
            if (!frmNotSetTime.Changes) return;
            //Stop timers.
            TmCheckPower.Stop();
            TmWaitForResp.Stop();
            //Get frmNotSetTime values.
            _timeBattChk = frmNotSetTime.TimeBattChk;
            _auxTimeBattChk = frmNotSetTime.AuxTimeBattChk;
            Battery.ChangeLowBattLevel(frmNotSetTime.LowBattery);
            Battery.ChangeHighBattLevel(frmNotSetTime.HighBattery);
            PcInnactivity.ChangeMaxIdleTime(frmNotSetTime.IdleTime);
            TmCheckPower.Interval = (int)_timeBattChk * 1000;
            TmWaitForResp.Interval = (int)_auxTimeBattChk * 60000;
            //Restart timers.
            TmCheckPower.Start();
            TmWaitForResp.Start();
        }

        #endregion

        #region ContextMenuStrip
        private void ShowToolStripMenuItem_Click(object sender, EventArgs e) => ShowForm();

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void InformeToolStripMenuItem_Click(object sender, EventArgs e) => SpeakInfo();

        #endregion

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) => ShowForm();

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
    public static class ModifyProgressBarColor
    {
        public enum Colors
        {
            Green = 1, Red, Yellow
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state) => SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
    }

}
