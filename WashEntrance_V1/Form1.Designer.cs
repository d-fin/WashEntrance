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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.radTireEye = new System.Windows.Forms.RadioButton();
            this.radRollerEye = new System.Windows.Forms.RadioButton();
            this.radFork = new System.Windows.Forms.RadioButton();
            this.tmrUpdateForm = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.radSeaDACLite0 = new System.Windows.Forms.RadioButton();
            this.radSeaConnect = new System.Windows.Forms.RadioButton();
            this.deleteLogs = new System.Windows.Forms.Button();
            this.radPgmCar = new System.Windows.Forms.RadioButton();
            this.radSonar = new System.Windows.Forms.RadioButton();
            this.radResetSigns = new System.Windows.Forms.RadioButton();
            this.radAudio = new System.Windows.Forms.RadioButton();
            this.radStop = new System.Windows.Forms.RadioButton();
            this.radGoSign = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBoxDevices = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radBtnExtraRoller = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBoxDevices.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // radTireEye
            // 
            this.radTireEye.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTireEye.AutoCheck = false;
            this.radTireEye.AutoSize = true;
            this.radTireEye.ForeColor = System.Drawing.Color.White;
            this.radTireEye.Location = new System.Drawing.Point(225, 140);
            this.radTireEye.Margin = new System.Windows.Forms.Padding(4);
            this.radTireEye.Name = "radTireEye";
            this.radTireEye.Size = new System.Drawing.Size(110, 29);
            this.radTireEye.TabIndex = 0;
            this.radTireEye.TabStop = true;
            this.radTireEye.Text = "Tire Eye";
            this.radTireEye.UseVisualStyleBackColor = true;
            // 
            // radRollerEye
            // 
            this.radRollerEye.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radRollerEye.AutoCheck = false;
            this.radRollerEye.AutoSize = true;
            this.radRollerEye.ForeColor = System.Drawing.Color.White;
            this.radRollerEye.Location = new System.Drawing.Point(225, 106);
            this.radRollerEye.Margin = new System.Windows.Forms.Padding(4);
            this.radRollerEye.Name = "radRollerEye";
            this.radRollerEye.Size = new System.Drawing.Size(125, 29);
            this.radRollerEye.TabIndex = 1;
            this.radRollerEye.TabStop = true;
            this.radRollerEye.Text = "Roller Eye";
            this.radRollerEye.UseVisualStyleBackColor = true;
            // 
            // radFork
            // 
            this.radFork.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radFork.AutoCheck = false;
            this.radFork.AutoSize = true;
            this.radFork.ForeColor = System.Drawing.Color.White;
            this.radFork.Location = new System.Drawing.Point(660, 105);
            this.radFork.Margin = new System.Windows.Forms.Padding(4);
            this.radFork.Name = "radFork";
            this.radFork.Size = new System.Drawing.Size(106, 29);
            this.radFork.TabIndex = 2;
            this.radFork.TabStop = true;
            this.radFork.Text = "Fork Up";
            this.radFork.UseVisualStyleBackColor = true;
            // 
            // tmrUpdateForm
            // 
            this.tmrUpdateForm.Enabled = true;
            this.tmrUpdateForm.Interval = 50;
            this.tmrUpdateForm.Tick += new System.EventHandler(this.tmrUpdateForm_Tick);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderSize = 3;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(4, 663);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(278, 121);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "EXIT";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // radSeaDACLite0
            // 
            this.radSeaDACLite0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeaDACLite0.AutoCheck = false;
            this.radSeaDACLite0.AutoSize = true;
            this.radSeaDACLite0.ForeColor = System.Drawing.Color.White;
            this.radSeaDACLite0.Location = new System.Drawing.Point(47, 38);
            this.radSeaDACLite0.Margin = new System.Windows.Forms.Padding(4);
            this.radSeaDACLite0.Name = "radSeaDACLite0";
            this.radSeaDACLite0.Size = new System.Drawing.Size(198, 36);
            this.radSeaDACLite0.TabIndex = 6;
            this.radSeaDACLite0.TabStop = true;
            this.radSeaDACLite0.Text = "SeaDAC Lite 0";
            this.radSeaDACLite0.UseVisualStyleBackColor = true;
            // 
            // radSeaConnect
            // 
            this.radSeaConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeaConnect.AutoCheck = false;
            this.radSeaConnect.AutoSize = true;
            this.radSeaConnect.ForeColor = System.Drawing.Color.White;
            this.radSeaConnect.Location = new System.Drawing.Point(47, 80);
            this.radSeaConnect.Margin = new System.Windows.Forms.Padding(4);
            this.radSeaConnect.Name = "radSeaConnect";
            this.radSeaConnect.Size = new System.Drawing.Size(198, 36);
            this.radSeaConnect.TabIndex = 7;
            this.radSeaConnect.Text = "SeaDAC Lite 1";
            this.radSeaConnect.UseVisualStyleBackColor = true;
            // 
            // deleteLogs
            // 
            this.deleteLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.deleteLogs.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.deleteLogs.FlatAppearance.BorderSize = 5;
            this.deleteLogs.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteLogs.ForeColor = System.Drawing.Color.White;
            this.deleteLogs.Location = new System.Drawing.Point(3, 537);
            this.deleteLogs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.deleteLogs.Name = "deleteLogs";
            this.deleteLogs.Size = new System.Drawing.Size(278, 121);
            this.deleteLogs.TabIndex = 9;
            this.deleteLogs.Text = "Clear Log File";
            this.deleteLogs.UseVisualStyleBackColor = false;
            this.deleteLogs.Click += new System.EventHandler(this.deleteLogs_Click);
            // 
            // radPgmCar
            // 
            this.radPgmCar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPgmCar.AutoCheck = false;
            this.radPgmCar.AutoSize = true;
            this.radPgmCar.ForeColor = System.Drawing.Color.White;
            this.radPgmCar.Location = new System.Drawing.Point(225, 209);
            this.radPgmCar.Margin = new System.Windows.Forms.Padding(4);
            this.radPgmCar.Name = "radPgmCar";
            this.radPgmCar.Size = new System.Drawing.Size(148, 29);
            this.radPgmCar.TabIndex = 10;
            this.radPgmCar.TabStop = true;
            this.radPgmCar.Text = "Program Car";
            this.radPgmCar.UseVisualStyleBackColor = true;
            // 
            // radSonar
            // 
            this.radSonar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSonar.AutoCheck = false;
            this.radSonar.AutoSize = true;
            this.radSonar.ForeColor = System.Drawing.Color.White;
            this.radSonar.Location = new System.Drawing.Point(225, 175);
            this.radSonar.Margin = new System.Windows.Forms.Padding(4);
            this.radSonar.Name = "radSonar";
            this.radSonar.Size = new System.Drawing.Size(90, 29);
            this.radSonar.TabIndex = 11;
            this.radSonar.TabStop = true;
            this.radSonar.Text = "Sonar";
            this.radSonar.UseVisualStyleBackColor = true;
            // 
            // radResetSigns
            // 
            this.radResetSigns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radResetSigns.AutoCheck = false;
            this.radResetSigns.AutoSize = true;
            this.radResetSigns.ForeColor = System.Drawing.Color.White;
            this.radResetSigns.Location = new System.Drawing.Point(225, 244);
            this.radResetSigns.Margin = new System.Windows.Forms.Padding(4);
            this.radResetSigns.Name = "radResetSigns";
            this.radResetSigns.Size = new System.Drawing.Size(132, 29);
            this.radResetSigns.TabIndex = 12;
            this.radResetSigns.TabStop = true;
            this.radResetSigns.Text = "Sign Reset";
            this.radResetSigns.UseVisualStyleBackColor = true;
            // 
            // radAudio
            // 
            this.radAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radAudio.AutoCheck = false;
            this.radAudio.AutoSize = true;
            this.radAudio.ForeColor = System.Drawing.Color.White;
            this.radAudio.Location = new System.Drawing.Point(660, 216);
            this.radAudio.Margin = new System.Windows.Forms.Padding(4);
            this.radAudio.Name = "radAudio";
            this.radAudio.Size = new System.Drawing.Size(88, 29);
            this.radAudio.TabIndex = 13;
            this.radAudio.TabStop = true;
            this.radAudio.Text = "Audio";
            this.radAudio.UseVisualStyleBackColor = true;
            // 
            // radStop
            // 
            this.radStop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radStop.AutoCheck = false;
            this.radStop.AutoSize = true;
            this.radStop.ForeColor = System.Drawing.Color.White;
            this.radStop.Location = new System.Drawing.Point(660, 178);
            this.radStop.Margin = new System.Windows.Forms.Padding(4);
            this.radStop.Name = "radStop";
            this.radStop.Size = new System.Drawing.Size(202, 29);
            this.radStop.TabIndex = 14;
            this.radStop.TabStop = true;
            this.radStop.Text = "Stop Car in Neutral";
            this.radStop.UseVisualStyleBackColor = true;
            // 
            // radGoSign
            // 
            this.radGoSign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGoSign.AutoCheck = false;
            this.radGoSign.AutoSize = true;
            this.radGoSign.ForeColor = System.Drawing.Color.White;
            this.radGoSign.Location = new System.Drawing.Point(660, 142);
            this.radGoSign.Margin = new System.Windows.Forms.Padding(4);
            this.radGoSign.Name = "radGoSign";
            this.radGoSign.Size = new System.Drawing.Size(210, 29);
            this.radGoSign.TabIndex = 15;
            this.radGoSign.TabStop = true;
            this.radGoSign.Text = "Please Pull Forward";
            this.radGoSign.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.deleteLogs);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 795);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(287, 261);
            this.panel2.TabIndex = 0;
            // 
            // groupBoxDevices
            // 
            this.groupBoxDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDevices.Controls.Add(this.radSeaDACLite0);
            this.groupBoxDevices.Controls.Add(this.radSeaConnect);
            this.groupBoxDevices.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDevices.ForeColor = System.Drawing.Color.White;
            this.groupBoxDevices.Location = new System.Drawing.Point(1179, 11);
            this.groupBoxDevices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxDevices.Name = "groupBoxDevices";
            this.groupBoxDevices.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxDevices.Size = new System.Drawing.Size(309, 130);
            this.groupBoxDevices.TabIndex = 10;
            this.groupBoxDevices.TabStop = false;
            this.groupBoxDevices.Text = "Devices";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.radBtnExtraRoller);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.radGoSign);
            this.panel3.Controls.Add(this.radResetSigns);
            this.panel3.Controls.Add(this.radFork);
            this.panel3.Controls.Add(this.radRollerEye);
            this.panel3.Controls.Add(this.radPgmCar);
            this.panel3.Controls.Add(this.radAudio);
            this.panel3.Controls.Add(this.radSonar);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.radStop);
            this.panel3.Controls.Add(this.radTireEye);
            this.panel3.Location = new System.Drawing.Point(286, 362);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1214, 433);
            this.panel3.TabIndex = 21;
            // 
            // radBtnExtraRoller
            // 
            this.radBtnExtraRoller.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radBtnExtraRoller.AutoCheck = false;
            this.radBtnExtraRoller.AutoSize = true;
            this.radBtnExtraRoller.ForeColor = System.Drawing.Color.White;
            this.radBtnExtraRoller.Location = new System.Drawing.Point(225, 282);
            this.radBtnExtraRoller.Margin = new System.Windows.Forms.Padding(4);
            this.radBtnExtraRoller.Name = "radBtnExtraRoller";
            this.radBtnExtraRoller.Size = new System.Drawing.Size(170, 29);
            this.radBtnExtraRoller.TabIndex = 24;
            this.radBtnExtraRoller.TabStop = true;
            this.radBtnExtraRoller.Text = "Extra Roller Btn";
            this.radBtnExtraRoller.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(655, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 37);
            this.label2.TabIndex = 23;
            this.label2.Text = "Outputs";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(220, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 40);
            this.label1.TabIndex = 22;
            this.label1.Text = "Inputs";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1500, 795);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxDevices);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.groupBoxDevices.ResumeLayout(false);
            this.groupBoxDevices.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radTireEye;
        private System.Windows.Forms.RadioButton radRollerEye;
        private System.Windows.Forms.RadioButton radFork;
        private System.Windows.Forms.Timer tmrUpdateForm;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton radSeaDACLite0;
        private System.Windows.Forms.RadioButton radSeaConnect;
        private System.Windows.Forms.Button deleteLogs;
        private System.Windows.Forms.RadioButton radPgmCar;
        private System.Windows.Forms.RadioButton radSonar;
        private System.Windows.Forms.RadioButton radResetSigns;
        private System.Windows.Forms.RadioButton radAudio;
        private System.Windows.Forms.RadioButton radStop;
        private System.Windows.Forms.RadioButton radGoSign;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxDevices;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radBtnExtraRoller;
    }
}

