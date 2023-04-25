namespace WashEntrance_V1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.radRollerCall = new System.Windows.Forms.RadioButton();
            this.radRollerEye = new System.Windows.Forms.RadioButton();
            this.radFork = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.Ouputs = new System.Windows.Forms.Label();
            this.tmrUpdateForm = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.radSeaDACLite0 = new System.Windows.Forms.RadioButton();
            this.radSeaConnect = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // radRollerCall
            // 
            this.radRollerCall.AutoCheck = false;
            this.radRollerCall.AutoSize = true;
            this.radRollerCall.Location = new System.Drawing.Point(243, 127);
            this.radRollerCall.Name = "radRollerCall";
            this.radRollerCall.Size = new System.Drawing.Size(174, 20);
            this.radRollerCall.TabIndex = 0;
            this.radRollerCall.TabStop = true;
            this.radRollerCall.Text = "Sonar/TireSwitch Ready";
            this.radRollerCall.UseVisualStyleBackColor = true;
            // 
            // radRollerEye
            // 
            this.radRollerEye.AutoCheck = false;
            this.radRollerEye.AutoSize = true;
            this.radRollerEye.Location = new System.Drawing.Point(243, 207);
            this.radRollerEye.Name = "radRollerEye";
            this.radRollerEye.Size = new System.Drawing.Size(91, 20);
            this.radRollerEye.TabIndex = 1;
            this.radRollerEye.TabStop = true;
            this.radRollerEye.Text = "Roller Eye";
            this.radRollerEye.UseVisualStyleBackColor = true;
            // 
            // radFork
            // 
            this.radFork.AutoCheck = false;
            this.radFork.AutoSize = true;
            this.radFork.Location = new System.Drawing.Point(575, 207);
            this.radFork.Name = "radFork";
            this.radFork.Size = new System.Drawing.Size(76, 20);
            this.radFork.TabIndex = 2;
            this.radFork.TabStop = true;
            this.radFork.Text = "Fork Up";
            this.radFork.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(238, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inputs";
            // 
            // Ouputs
            // 
            this.Ouputs.AutoSize = true;
            this.Ouputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ouputs.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Ouputs.Location = new System.Drawing.Point(570, 41);
            this.Ouputs.Name = "Ouputs";
            this.Ouputs.Size = new System.Drawing.Size(103, 29);
            this.Ouputs.TabIndex = 4;
            this.Ouputs.Text = "Outputs";
            // 
            // tmrUpdateForm
            // 
            this.tmrUpdateForm.Enabled = true;
            this.tmrUpdateForm.Interval = 50;
            this.tmrUpdateForm.Tick += new System.EventHandler(this.tmrUpdateForm_Tick);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(852, 472);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(135, 69);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // radSeaDACLite0
            // 
            this.radSeaDACLite0.AutoCheck = false;
            this.radSeaDACLite0.AutoSize = true;
            this.radSeaDACLite0.Location = new System.Drawing.Point(12, 76);
            this.radSeaDACLite0.Name = "radSeaDACLite0";
            this.radSeaDACLite0.Size = new System.Drawing.Size(115, 20);
            this.radSeaDACLite0.TabIndex = 6;
            this.radSeaDACLite0.TabStop = true;
            this.radSeaDACLite0.Text = "SeaDAC Lite 0";
            this.radSeaDACLite0.UseVisualStyleBackColor = true;
            // 
            // radSeaConnect
            // 
            this.radSeaConnect.AutoCheck = false;
            this.radSeaConnect.AutoSize = true;
            this.radSeaConnect.Location = new System.Drawing.Point(12, 103);
            this.radSeaConnect.Name = "radSeaConnect";
            this.radSeaConnect.Size = new System.Drawing.Size(126, 20);
            this.radSeaConnect.TabIndex = 7;
            this.radSeaConnect.Text = "SeaConnect 370";
            this.radSeaConnect.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 31);
            this.label2.TabIndex = 8;
            this.label2.Text = "Devices";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(239, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "SeaDAC Lite inputs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(239, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "SeaConnect 370 inputs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(571, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "SeaDAC Lite outputs";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(571, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(214, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "SeaConnect 370 outputs";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(999, 553);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radSeaConnect);
            this.Controls.Add(this.radSeaDACLite0);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.Ouputs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radFork);
            this.Controls.Add(this.radRollerEye);
            this.Controls.Add(this.radRollerCall);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radRollerCall;
        private System.Windows.Forms.RadioButton radRollerEye;
        private System.Windows.Forms.RadioButton radFork;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Ouputs;
        private System.Windows.Forms.Timer tmrUpdateForm;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton radSeaDACLite0;
        private System.Windows.Forms.RadioButton radSeaConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

