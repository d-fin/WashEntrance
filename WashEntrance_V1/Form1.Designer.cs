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
            this.radTireEye = new System.Windows.Forms.RadioButton();
            this.radRollerEye = new System.Windows.Forms.RadioButton();
            this.radFork = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.Ouputs = new System.Windows.Forms.Label();
            this.tmrUpdateForm = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.radSeaDACLite0 = new System.Windows.Forms.RadioButton();
            this.radSeaConnect = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.deleteLogs = new System.Windows.Forms.Button();
            this.radPgmCar = new System.Windows.Forms.RadioButton();
            this.radSonar = new System.Windows.Forms.RadioButton();
            this.radResetSigns = new System.Windows.Forms.RadioButton();
            this.radAudio = new System.Windows.Forms.RadioButton();
            this.radStop = new System.Windows.Forms.RadioButton();
            this.radGoSign = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.radInPosition = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radTireEye
            // 
            this.radTireEye.AutoCheck = false;
            this.radTireEye.AutoSize = true;
            this.radTireEye.Location = new System.Drawing.Point(275, 136);
            this.radTireEye.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radTireEye.Name = "radTireEye";
            this.radTireEye.Size = new System.Drawing.Size(91, 24);
            this.radTireEye.TabIndex = 0;
            this.radTireEye.TabStop = true;
            this.radTireEye.Text = "Tire Eye";
            this.radTireEye.UseVisualStyleBackColor = true;
            // 
            // radRollerEye
            // 
            this.radRollerEye.AutoCheck = false;
            this.radRollerEye.AutoSize = true;
            this.radRollerEye.Location = new System.Drawing.Point(275, 104);
            this.radRollerEye.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radRollerEye.Name = "radRollerEye";
            this.radRollerEye.Size = new System.Drawing.Size(106, 24);
            this.radRollerEye.TabIndex = 1;
            this.radRollerEye.TabStop = true;
            this.radRollerEye.Text = "Roller Eye";
            this.radRollerEye.UseVisualStyleBackColor = true;
            // 
            // radFork
            // 
            this.radFork.AutoCheck = false;
            this.radFork.AutoSize = true;
            this.radFork.Location = new System.Drawing.Point(647, 95);
            this.radFork.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radFork.Name = "radFork";
            this.radFork.Size = new System.Drawing.Size(91, 24);
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
            this.label1.Location = new System.Drawing.Point(268, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inputs";
            // 
            // Ouputs
            // 
            this.Ouputs.AutoSize = true;
            this.Ouputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ouputs.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Ouputs.Location = new System.Drawing.Point(641, 51);
            this.Ouputs.Name = "Ouputs";
            this.Ouputs.Size = new System.Drawing.Size(122, 32);
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
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(958, 590);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(152, 86);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // radSeaDACLite0
            // 
            this.radSeaDACLite0.AutoCheck = false;
            this.radSeaDACLite0.AutoSize = true;
            this.radSeaDACLite0.Location = new System.Drawing.Point(14, 95);
            this.radSeaDACLite0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radSeaDACLite0.Name = "radSeaDACLite0";
            this.radSeaDACLite0.Size = new System.Drawing.Size(140, 24);
            this.radSeaDACLite0.TabIndex = 6;
            this.radSeaDACLite0.TabStop = true;
            this.radSeaDACLite0.Text = "SeaDAC Lite 0";
            this.radSeaDACLite0.UseVisualStyleBackColor = true;
            // 
            // radSeaConnect
            // 
            this.radSeaConnect.AutoCheck = false;
            this.radSeaConnect.AutoSize = true;
            this.radSeaConnect.Location = new System.Drawing.Point(14, 129);
            this.radSeaConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radSeaConnect.Name = "radSeaConnect";
            this.radSeaConnect.Size = new System.Drawing.Size(140, 24);
            this.radSeaConnect.TabIndex = 7;
            this.radSeaConnect.Text = "SeaDAC Lite 1";
            this.radSeaConnect.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 37);
            this.label2.TabIndex = 8;
            this.label2.Text = "Devices";
            // 
            // deleteLogs
            // 
            this.deleteLogs.Location = new System.Drawing.Point(27, 603);
            this.deleteLogs.Name = "deleteLogs";
            this.deleteLogs.Size = new System.Drawing.Size(209, 63);
            this.deleteLogs.TabIndex = 9;
            this.deleteLogs.Text = "Clear Log File";
            this.deleteLogs.UseVisualStyleBackColor = true;
            this.deleteLogs.Click += new System.EventHandler(this.deleteLogs_Click);
            // 
            // radPgmCar
            // 
            this.radPgmCar.AutoCheck = false;
            this.radPgmCar.AutoSize = true;
            this.radPgmCar.Location = new System.Drawing.Point(275, 200);
            this.radPgmCar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radPgmCar.Name = "radPgmCar";
            this.radPgmCar.Size = new System.Drawing.Size(123, 24);
            this.radPgmCar.TabIndex = 10;
            this.radPgmCar.TabStop = true;
            this.radPgmCar.Text = "Program Car";
            this.radPgmCar.UseVisualStyleBackColor = true;
            // 
            // radSonar
            // 
            this.radSonar.AutoCheck = false;
            this.radSonar.AutoSize = true;
            this.radSonar.Location = new System.Drawing.Point(274, 168);
            this.radSonar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radSonar.Name = "radSonar";
            this.radSonar.Size = new System.Drawing.Size(77, 24);
            this.radSonar.TabIndex = 11;
            this.radSonar.TabStop = true;
            this.radSonar.Text = "Sonar";
            this.radSonar.UseVisualStyleBackColor = true;
            // 
            // radResetSigns
            // 
            this.radResetSigns.AutoCheck = false;
            this.radResetSigns.AutoSize = true;
            this.radResetSigns.Location = new System.Drawing.Point(275, 232);
            this.radResetSigns.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radResetSigns.Name = "radResetSigns";
            this.radResetSigns.Size = new System.Drawing.Size(113, 24);
            this.radResetSigns.TabIndex = 12;
            this.radResetSigns.TabStop = true;
            this.radResetSigns.Text = "Sign Reset";
            this.radResetSigns.UseVisualStyleBackColor = true;
            // 
            // radAudio
            // 
            this.radAudio.AutoCheck = false;
            this.radAudio.AutoSize = true;
            this.radAudio.Location = new System.Drawing.Point(647, 191);
            this.radAudio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radAudio.Name = "radAudio";
            this.radAudio.Size = new System.Drawing.Size(75, 24);
            this.radAudio.TabIndex = 13;
            this.radAudio.TabStop = true;
            this.radAudio.Text = "Audio";
            this.radAudio.UseVisualStyleBackColor = true;
            // 
            // radStop
            // 
            this.radStop.AutoCheck = false;
            this.radStop.AutoSize = true;
            this.radStop.Location = new System.Drawing.Point(647, 159);
            this.radStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radStop.Name = "radStop";
            this.radStop.Size = new System.Drawing.Size(168, 24);
            this.radStop.TabIndex = 14;
            this.radStop.TabStop = true;
            this.radStop.Text = "Stop Car in Neutral";
            this.radStop.UseVisualStyleBackColor = true;
            // 
            // radGoSign
            // 
            this.radGoSign.AutoCheck = false;
            this.radGoSign.AutoSize = true;
            this.radGoSign.Location = new System.Drawing.Point(647, 127);
            this.radGoSign.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radGoSign.Name = "radGoSign";
            this.radGoSign.Size = new System.Drawing.Size(173, 24);
            this.radGoSign.TabIndex = 15;
            this.radGoSign.TabStop = true;
            this.radGoSign.Text = "Please Pull Forward";
            this.radGoSign.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(268, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 32);
            this.label3.TabIndex = 16;
            this.label3.Text = "Data";
            // 
            // radInPosition
            // 
            this.radInPosition.AutoCheck = false;
            this.radInPosition.AutoSize = true;
            this.radInPosition.Location = new System.Drawing.Point(275, 392);
            this.radInPosition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radInPosition.Name = "radInPosition";
            this.radInPosition.Size = new System.Drawing.Size(135, 24);
            this.radInPosition.TabIndex = 17;
            this.radInPosition.TabStop = true;
            this.radInPosition.Text = "Car in Position";
            this.radInPosition.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1124, 691);
            this.ControlBox = false;
            this.Controls.Add(this.radInPosition);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radGoSign);
            this.Controls.Add(this.radStop);
            this.Controls.Add(this.radAudio);
            this.Controls.Add(this.radResetSigns);
            this.Controls.Add(this.radSonar);
            this.Controls.Add(this.radPgmCar);
            this.Controls.Add(this.deleteLogs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radSeaConnect);
            this.Controls.Add(this.radSeaDACLite0);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.Ouputs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radFork);
            this.Controls.Add(this.radRollerEye);
            this.Controls.Add(this.radTireEye);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radTireEye;
        private System.Windows.Forms.RadioButton radRollerEye;
        private System.Windows.Forms.RadioButton radFork;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Ouputs;
        private System.Windows.Forms.Timer tmrUpdateForm;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton radSeaDACLite0;
        private System.Windows.Forms.RadioButton radSeaConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button deleteLogs;
        private System.Windows.Forms.RadioButton radPgmCar;
        private System.Windows.Forms.RadioButton radSonar;
        private System.Windows.Forms.RadioButton radResetSigns;
        private System.Windows.Forms.RadioButton radAudio;
        private System.Windows.Forms.RadioButton radStop;
        private System.Windows.Forms.RadioButton radGoSign;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radInPosition;
    }
}

