using System.Windows.Forms;

namespace BatteryStatus.Utilities
{
    public class Battery
    {
        /// <summary>
        /// Pc charging status.
        /// </summary>
        public bool Charging { get; private set; }
        /// <summary>
        /// Alert checked.
        /// </summary>
        public bool ChkAlert { get; private set; }
        /// <summary>
        /// Alert emmited.
        /// </summary>
        private bool _auxAlert;
        /// <summary>
        /// Min battery level.
        /// </summary>
        public uint LowBattLevel {get; private set;} = 20;
        /// <summary>
        /// Max battery level.
        /// </summary>
        public uint HighBattLevel {get; private set;} = 80;
        /// <summary>
        /// Alert Message.
        /// </summary>
        public string Msg { get; private set; }
        /// <summary>
        /// Object to check the Battery Status.
        /// </summary>
        private PowerStatus Status { get; } = SystemInformation.PowerStatus;
        /// <summary>
        /// Available alerts
        /// </summary>
        public enum Alerts
        {
            Any, LowBattery, HighBattery
        }
        /// <summary>
        /// Current alert
        /// </summary>
        public Alerts Alert { get; private set; } = Alerts.Any;

        #region PowerStatusProperties
        public string ChargeStatus => Status.BatteryChargeStatus == 0 ? "Normal" : Status.BatteryChargeStatus.ToString();
        public string BatteryFullLifetime => Status.BatteryFullLifetime == -1 ? "Unknown" : Status.BatteryFullLifetime.ToString();
        public string BatteryLifePercent => Status.BatteryLifePercent.ToString("P0");
        public string BatteryLifeRemaining => Status.BatteryLifeRemaining == -1 ? "Unknown" : Status.BatteryLifeRemaining.ToString();
        public string PowerLineStatus => Status.PowerLineStatus.ToString();

        #endregion

        public Battery() => PowerModeChanged();

        public void ChangeLowBattLevel(uint lowBattLevel) => LowBattLevel = lowBattLevel;

        public void ChangeHighBattLevel(uint highBattLevel) => HighBattLevel = highBattLevel;

        /// <summary>
        /// Check if the pc is charging.
        /// </summary>
        public void PowerModeChanged() => Charging = Status.PowerLineStatus == System.Windows.Forms.PowerLineStatus.Online;

        public bool CheckPowerLevel()
        {
            if (_auxAlert) return false;
            if (!Charging && Status.BatteryLifePercent <= (double)LowBattLevel / 100)
            {
                Msg = $@"Batería por debajo del {LowBattLevel} %. Conecte la fuente de poder";
                Alert = Alerts.LowBattery;
            }
            else if (Charging && Status.BatteryLifePercent >= (double)HighBattLevel / 100)
            {
                Msg = $@"Batería por encima del {HighBattLevel} %. Desconecte la fuente de poder";
                Alert = Alerts.HighBattery;
            }
            else
                Alert = Alerts.Any;

            if (Alert == Alerts.Any) return false;
            _auxAlert = true;
            return true;
        }

        /// <summary>
        /// Check if the alert was checked.
        /// </summary>
        public void WaitForResp()
        {
            if (!ChkAlert)
                _auxAlert = false;
        }
        public void Checked() => ChkAlert = true;
    }
}
