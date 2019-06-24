using System;
using System.Windows.Forms;

namespace BatteryStatus.Forms
{
    public partial class NotSetTime : Form
    {
        public uint TimeBattChk { get; private set; } = 1;
        public uint AuxTimeBattChk { get; private set; } = 1;
        public bool Changes { get; private set; }
        public NotSetTime(uint a, uint b)
        {
            InitializeComponent();
            NudTimeChk.Value = a;
            NudTimeNot.Value = b;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Changes = true;
            TimeBattChk = (uint)NudTimeChk.Value;
            AuxTimeBattChk = (uint)NudTimeNot.Value;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e) => Close();
    }
}
