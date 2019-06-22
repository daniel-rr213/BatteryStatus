namespace BatteryStatus
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Charge Status";
            // 
            // txtChargeStatus
            // 
            this.txtChargeStatus.Location = new System.Drawing.Point(170, 18);
            this.txtChargeStatus.Name = "txtChargeStatus";
            this.txtChargeStatus.ReadOnly = true;
            this.txtChargeStatus.Size = new System.Drawing.Size(217, 22);
            this.txtChargeStatus.TabIndex = 1;
            // 
            // txtFullLifetime
            // 
            this.txtFullLifetime.Location = new System.Drawing.Point(170, 57);
            this.txtFullLifetime.Name = "txtFullLifetime";
            this.txtFullLifetime.ReadOnly = true;
            this.txtFullLifetime.Size = new System.Drawing.Size(217, 22);
            this.txtFullLifetime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Full Life (sec)";
            // 
            // txtCharge
            // 
            this.txtCharge.Location = new System.Drawing.Point(170, 96);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.ReadOnly = true;
            this.txtCharge.Size = new System.Drawing.Size(217, 22);
            this.txtCharge.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Charge";
            // 
            // txtLifeRemaining
            // 
            this.txtLifeRemaining.Location = new System.Drawing.Point(170, 135);
            this.txtLifeRemaining.Name = "txtLifeRemaining";
            this.txtLifeRemaining.ReadOnly = true;
            this.txtLifeRemaining.Size = new System.Drawing.Size(217, 22);
            this.txtLifeRemaining.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Life Remaining (sec)";
            // 
            // txtLineStatus
            // 
            this.txtLineStatus.Location = new System.Drawing.Point(170, 174);
            this.txtLineStatus.Name = "txtLineStatus";
            this.txtLineStatus.ReadOnly = true;
            this.txtLineStatus.Size = new System.Drawing.Size(217, 22);
            this.txtLineStatus.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Line Status";
            // 
            // TmCheckPower
            // 
            this.TmCheckPower.Enabled = true;
            this.TmCheckPower.Interval = 1000;
            this.TmCheckPower.Tick += new System.EventHandler(this.TmCheckPower_Tick);
            // 
            // BtnSpeak
            // 
            this.BtnSpeak.Location = new System.Drawing.Point(13, 225);
            this.BtnSpeak.Name = "BtnSpeak";
            this.BtnSpeak.Size = new System.Drawing.Size(75, 29);
            this.BtnSpeak.TabIndex = 10;
            this.BtnSpeak.Text = "Informe";
            this.BtnSpeak.UseVisualStyleBackColor = true;
            this.BtnSpeak.Click += new System.EventHandler(this.BtnSpeak_Click);
            // 
            // BtnPause
            // 
            this.BtnPause.Location = new System.Drawing.Point(119, 225);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(75, 29);
            this.BtnPause.TabIndex = 11;
            this.BtnPause.Text = "Pausar";
            this.BtnPause.UseVisualStyleBackColor = true;
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // BtnResume
            // 
            this.BtnResume.Location = new System.Drawing.Point(221, 225);
            this.BtnResume.Name = "BtnResume";
            this.BtnResume.Size = new System.Drawing.Size(75, 29);
            this.BtnResume.TabIndex = 12;
            this.BtnResume.Text = "Continuar";
            this.BtnResume.UseVisualStyleBackColor = true;
            this.BtnResume.Click += new System.EventHandler(this.BtnResume_Click);
            // 
            // BtnChecked
            // 
            this.BtnChecked.Location = new System.Drawing.Point(331, 224);
            this.BtnChecked.Name = "BtnChecked";
            this.BtnChecked.Size = new System.Drawing.Size(86, 29);
            this.BtnChecked.TabIndex = 13;
            this.BtnChecked.Text = "Entendido";
            this.BtnChecked.UseVisualStyleBackColor = true;
            this.BtnChecked.Click += new System.EventHandler(this.BtnChecked_Click);
            // 
            // TmWaitForResp
            // 
            this.TmWaitForResp.Interval = 60000;
            this.TmWaitForResp.Tick += new System.EventHandler(this.TmWaitForResp_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 320);
            this.Controls.Add(this.BtnChecked);
            this.Controls.Add(this.BtnResume);
            this.Controls.Add(this.BtnPause);
            this.Controls.Add(this.BtnSpeak);
            this.Controls.Add(this.txtLineStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLifeRemaining);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCharge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFullLifetime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtChargeStatus);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

