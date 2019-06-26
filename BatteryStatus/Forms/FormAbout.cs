using System;
using System.Windows.Forms;

namespace BatteryStatus.Forms
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void LinkLabel_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(((Label)sender).Text);
            MessageBox.Show(@"URL copiada al portapeles");
        }
    }
}
