namespace BatteryStatus.Forms
{
    partial class NotSetTime
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.NudTimeChk = new System.Windows.Forms.NumericUpDown();
            this.NudTimeNot = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudTimeChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTimeNot)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NudTimeNot);
            this.groupBox1.Controls.Add(this.NudTimeChk);
            this.groupBox1.Controls.Add(this.BtnCancel);
            this.groupBox1.Controls.Add(this.BtnSave);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notification Setting Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time to &check battery level (sec)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time to check &notification (min)";
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnSave.Location = new System.Drawing.Point(7, 96);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(99, 34);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.Location = new System.Drawing.Point(108, 96);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(99, 34);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // NudTimeChk
            // 
            this.NudTimeChk.Location = new System.Drawing.Point(226, 22);
            this.NudTimeChk.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NudTimeChk.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudTimeChk.Name = "NudTimeChk";
            this.NudTimeChk.Size = new System.Drawing.Size(73, 22);
            this.NudTimeChk.TabIndex = 5;
            this.NudTimeChk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudTimeChk.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NudTimeNot
            // 
            this.NudTimeNot.Location = new System.Drawing.Point(226, 60);
            this.NudTimeNot.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NudTimeNot.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudTimeNot.Name = "NudTimeNot";
            this.NudTimeNot.Size = new System.Drawing.Size(73, 22);
            this.NudTimeNot.TabIndex = 5;
            this.NudTimeNot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudTimeNot.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NotSetTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 164);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NotSetTime";
            this.Text = "NotSetTime";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudTimeChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTimeNot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NudTimeNot;
        private System.Windows.Forms.NumericUpDown NudTimeChk;
    }
}