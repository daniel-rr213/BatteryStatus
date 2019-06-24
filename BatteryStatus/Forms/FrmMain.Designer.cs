namespace BatteryStatus.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.txtChargeStatus = new System.Windows.Forms.TextBox();
            this.txtFullLifetime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCharge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLifeRemaining = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLineStatus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TmCheckPower = new System.Windows.Forms.Timer(this.components);
            this.BtnSpeak = new System.Windows.Forms.Button();
            this.BtnPause = new System.Windows.Forms.Button();
            this.BtnResume = new System.Windows.Forms.Button();
            this.BtnChecked = new System.Windows.Forms.Button();
            this.TmWaitForResp = new System.Windows.Forms.Timer(this.components);
            this.TbIdleTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ChBAutoRun = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GbBatteryStatus = new System.Windows.Forms.GroupBox();
            this.GbVoiceBtns = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.GbBatteryStatus.SuspendLayout();
            this.GbVoiceBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Charge Status";
            // 
            // txtChargeStatus
            // 
            this.txtChargeStatus.Location = new System.Drawing.Point(150, 15);
            this.txtChargeStatus.Name = "txtChargeStatus";
            this.txtChargeStatus.ReadOnly = true;
            this.txtChargeStatus.Size = new System.Drawing.Size(217, 22);
            this.txtChargeStatus.TabIndex = 1;
            // 
            // txtFullLifetime
            // 
            this.txtFullLifetime.Location = new System.Drawing.Point(150, 54);
            this.txtFullLifetime.Name = "txtFullLifetime";
            this.txtFullLifetime.ReadOnly = true;
            this.txtFullLifetime.Size = new System.Drawing.Size(217, 22);
            this.txtFullLifetime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Full Life (sec)";
            // 
            // txtCharge
            // 
            this.txtCharge.Location = new System.Drawing.Point(150, 93);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.ReadOnly = true;
            this.txtCharge.Size = new System.Drawing.Size(217, 22);
            this.txtCharge.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Charge";
            // 
            // txtLifeRemaining
            // 
            this.txtLifeRemaining.Location = new System.Drawing.Point(150, 132);
            this.txtLifeRemaining.Name = "txtLifeRemaining";
            this.txtLifeRemaining.ReadOnly = true;
            this.txtLifeRemaining.Size = new System.Drawing.Size(217, 22);
            this.txtLifeRemaining.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Life Remaining (sec)";
            // 
            // txtLineStatus
            // 
            this.txtLineStatus.Location = new System.Drawing.Point(150, 171);
            this.txtLineStatus.Name = "txtLineStatus";
            this.txtLineStatus.ReadOnly = true;
            this.txtLineStatus.Size = new System.Drawing.Size(217, 22);
            this.txtLineStatus.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Line Status";
            // 
            // TmCheckPower
            // 
            this.TmCheckPower.Interval = 1000;
            this.TmCheckPower.Tick += new System.EventHandler(this.TmCheckPower_Tick);
            // 
            // BtnSpeak
            // 
            this.BtnSpeak.Location = new System.Drawing.Point(6, 21);
            this.BtnSpeak.Name = "BtnSpeak";
            this.BtnSpeak.Size = new System.Drawing.Size(75, 29);
            this.BtnSpeak.TabIndex = 10;
            this.BtnSpeak.Text = "&Informe";
            this.BtnSpeak.UseVisualStyleBackColor = true;
            this.BtnSpeak.Click += new System.EventHandler(this.BtnSpeak_Click);
            // 
            // BtnPause
            // 
            this.BtnPause.Enabled = false;
            this.BtnPause.Location = new System.Drawing.Point(110, 21);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(75, 29);
            this.BtnPause.TabIndex = 11;
            this.BtnPause.Text = "&Pausar";
            this.BtnPause.UseVisualStyleBackColor = true;
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // BtnResume
            // 
            this.BtnResume.Enabled = false;
            this.BtnResume.Location = new System.Drawing.Point(214, 21);
            this.BtnResume.Name = "BtnResume";
            this.BtnResume.Size = new System.Drawing.Size(80, 29);
            this.BtnResume.TabIndex = 12;
            this.BtnResume.Text = "&Continuar";
            this.BtnResume.UseVisualStyleBackColor = true;
            this.BtnResume.Click += new System.EventHandler(this.BtnResume_Click);
            // 
            // BtnChecked
            // 
            this.BtnChecked.Enabled = false;
            this.BtnChecked.Location = new System.Drawing.Point(323, 20);
            this.BtnChecked.Name = "BtnChecked";
            this.BtnChecked.Size = new System.Drawing.Size(86, 29);
            this.BtnChecked.TabIndex = 13;
            this.BtnChecked.Text = "&Entendido";
            this.BtnChecked.UseVisualStyleBackColor = true;
            this.BtnChecked.Click += new System.EventHandler(this.BtnChecked_Click);
            // 
            // TmWaitForResp
            // 
            this.TmWaitForResp.Interval = 60000;
            this.TmWaitForResp.Tick += new System.EventHandler(this.TmWaitForResp_Tick);
            // 
            // TbIdleTime
            // 
            this.TbIdleTime.Location = new System.Drawing.Point(162, 346);
            this.TbIdleTime.Name = "TbIdleTime";
            this.TbIdleTime.ReadOnly = true;
            this.TbIdleTime.Size = new System.Drawing.Size(56, 22);
            this.TbIdleTime.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Idle Time in Minuts";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowToolStripMenuItem,
            this.CloseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 52);
            // 
            // ShowToolStripMenuItem
            // 
            this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
            this.ShowToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.ShowToolStripMenuItem.Text = "Mostart";
            this.ShowToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.CloseToolStripMenuItem.Text = "Cerrar";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Settings";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // ChBAutoRun
            // 
            this.ChBAutoRun.AutoSize = true;
            this.ChBAutoRun.Location = new System.Drawing.Point(12, 380);
            this.ChBAutoRun.Name = "ChBAutoRun";
            this.ChBAutoRun.Size = new System.Drawing.Size(179, 21);
            this.ChBAutoRun.TabIndex = 4;
            this.ChBAutoRun.Text = "Iniciar &automáticamente";
            this.ChBAutoRun.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(475, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.voiceToolStripMenuItem,
            this.notificationsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // voiceToolStripMenuItem
            // 
            this.voiceToolStripMenuItem.Name = "voiceToolStripMenuItem";
            this.voiceToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.voiceToolStripMenuItem.Text = "&Voice";
            this.voiceToolStripMenuItem.Click += new System.EventHandler(this.VoiceToolStripMenuItem_Click);
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.notificationsToolStripMenuItem.Text = "&Notifications";
            this.notificationsToolStripMenuItem.Click += new System.EventHandler(this.NotificationsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // GbBatteryStatus
            // 
            this.GbBatteryStatus.Controls.Add(this.label1);
            this.GbBatteryStatus.Controls.Add(this.txtChargeStatus);
            this.GbBatteryStatus.Controls.Add(this.label2);
            this.GbBatteryStatus.Controls.Add(this.txtFullLifetime);
            this.GbBatteryStatus.Controls.Add(this.label3);
            this.GbBatteryStatus.Controls.Add(this.txtCharge);
            this.GbBatteryStatus.Controls.Add(this.label4);
            this.GbBatteryStatus.Controls.Add(this.txtLifeRemaining);
            this.GbBatteryStatus.Controls.Add(this.label5);
            this.GbBatteryStatus.Controls.Add(this.txtLineStatus);
            this.GbBatteryStatus.Location = new System.Drawing.Point(12, 31);
            this.GbBatteryStatus.Name = "GbBatteryStatus";
            this.GbBatteryStatus.Size = new System.Drawing.Size(372, 208);
            this.GbBatteryStatus.TabIndex = 0;
            this.GbBatteryStatus.TabStop = false;
            this.GbBatteryStatus.Text = "Battery Status";
            // 
            // GbVoiceBtns
            // 
            this.GbVoiceBtns.Controls.Add(this.BtnSpeak);
            this.GbVoiceBtns.Controls.Add(this.BtnPause);
            this.GbVoiceBtns.Controls.Add(this.BtnResume);
            this.GbVoiceBtns.Controls.Add(this.BtnChecked);
            this.GbVoiceBtns.Location = new System.Drawing.Point(12, 259);
            this.GbVoiceBtns.Name = "GbVoiceBtns";
            this.GbVoiceBtns.Size = new System.Drawing.Size(420, 66);
            this.GbVoiceBtns.TabIndex = 1;
            this.GbVoiceBtns.TabStop = false;
            this.GbVoiceBtns.Text = "Voice control";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 413);
            this.Controls.Add(this.GbVoiceBtns);
            this.Controls.Add(this.GbBatteryStatus);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ChBAutoRun);
            this.Controls.Add(this.TbIdleTime);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.Move += new System.EventHandler(this.FrmMain_Move);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GbBatteryStatus.ResumeLayout(false);
            this.GbBatteryStatus.PerformLayout();
            this.GbVoiceBtns.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChargeStatus;
        private System.Windows.Forms.TextBox txtFullLifetime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCharge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLifeRemaining;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLineStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer TmCheckPower;
        private System.Windows.Forms.Button BtnSpeak;
        private System.Windows.Forms.Button BtnPause;
        private System.Windows.Forms.Button BtnResume;
        private System.Windows.Forms.Button BtnChecked;
        private System.Windows.Forms.Timer TmWaitForResp;
        private System.Windows.Forms.TextBox TbIdleTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox ChBAutoRun;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox GbBatteryStatus;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificationsToolStripMenuItem;
        private System.Windows.Forms.GroupBox GbVoiceBtns;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

