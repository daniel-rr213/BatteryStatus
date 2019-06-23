﻿using System.Windows.Forms;

namespace BatteryStatus
{
    public class Battery
    {
        public bool Charging { get; private set; }
        public bool ChkAd { get; private set; }
        private bool _auxchk;
        public uint MinBatLevel = 15;
        public uint MaxBatLevel = 85;
        public string Msg { get; private set; }
        private PowerStatus Status { get; } = SystemInformation.PowerStatus;

        #region BatteryProperties
        public string ChargeStatus => Status.BatteryChargeStatus == 0 ? "Normal" : Status.BatteryChargeStatus.ToString();
        public string BatteryFullLifetime => Status.BatteryFullLifetime == -1 ? "Unknown" : Status.BatteryFullLifetime.ToString();
        public string BatteryLifePercent => Status.BatteryLifePercent.ToString("P0");
        public string BatteryLifeRemaining => Status.BatteryLifeRemaining == -1 ? "Unknown" : Status.BatteryLifeRemaining.ToString();
        public string PowerLineStatus => Status.PowerLineStatus.ToString();

        #endregion

        public Battery() => Charging = Status.PowerLineStatus == System.Windows.Forms.PowerLineStatus.Online;


        public void PowerModeChanged()
        {
            //PowerStatus ps = new PowerStatus();
            Charging = Status.PowerLineStatus == System.Windows.Forms.PowerLineStatus.Online;
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

        public bool CheckPower()
        {
            var adv = false;
            if (!Charging && (Status.BatteryLifePercent < (double)MinBatLevel / 100) && !_auxchk)
            {
                Msg = $@"Batería por debajo del {MinBatLevel} %. Conecte la fuente de poder";
                adv = true;
            }
            else if (Charging && (Status.BatteryLifePercent > (double)MaxBatLevel / 100) && !_auxchk)
            {
                Msg = $@"Batería por encima del {MaxBatLevel} %. Desconecte la fuente de poder";
                adv = true;
            }
            if (!adv) return false;
            _auxchk = true;
            return true;
        }

        public void WaitForResp()
        {
            if (!ChkAd)
                _auxchk = false;
        }
        public void Checked()
        {
            ChkAd = true;
        }
    }
}
