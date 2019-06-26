using System;
using System.Windows.Forms;

namespace BatteryStatus.Forms
{
    public partial class FrmNotSetTime : Form
    {
        public uint TimeBattChk { get; private set; } = 1;
        public uint AuxTimeBattChk { get; private set; } = 1;
        public uint IdleTime { get; private set; } = 5;
        public uint LowBattery { get; private set; }
        public uint HighBattery { get; private set; }
        public bool Changes { get; private set; }

        public FrmNotSetTime(uint timeBattChk, uint auxTimeBattChk, uint idleTime, uint lowBattery, uint highBattery)
        {
            InitializeComponent();
            NudLowBattLevel.Value = lowBattery;
            NudHighBattLevel.Value = highBattery;
            NudTimeChk.Value = timeBattChk;
            NudTimeNot.Value = auxTimeBattChk;
            NudIdleTime.Value = idleTime;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Changes = true;
            TimeBattChk = (uint)NudTimeChk.Value;
            AuxTimeBattChk = (uint)NudTimeNot.Value;
            IdleTime = (uint)NudIdleTime.Value;
            LowBattery = (uint)NudLowBattLevel.Value;
            HighBattery = (uint)NudHighBattLevel.Value;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e) => Close();
    }
}