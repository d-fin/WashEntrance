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
            this.radGo = new System.Windows.Forms.RadioButton();
            this.radStop = new System.Windows.Forms.RadioButton();
            this.radAudio = new System.Windows.Forms.RadioButton();
            this.radSignTrigger = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radRollerCall
            // 
            this.radRollerCall.AutoCheck = false;
            this.radRollerCall.AutoSize = true;
            this.radRollerCall.Location = new System.Drawing.Point(274, 411);
            this.radRollerCall.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radRollerCall.Name = "radRollerCall";
            this.radRollerCall.Size = new System.Drawing.Size(105, 24);
            this.radRollerCall.TabIndex = 0;
            this.radRollerCall.TabStop = true;
            this.radRollerCall.Text = "Roller Call";
            this.radRollerCall.UseVisualStyleBackColor = true;
            // 
            // radRollerEye
            // 
            this.radRollerEye.AutoCheck = false;
            this.radRollerEye.AutoSize = true;
            this.radRollerEye.Location = new System.Drawing.Point(273, 379);
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
            this.radFork.Location = new System.Drawing.Point(637, 379);
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
            this.btnExit.Location = new System.Drawing.Point(958, 590);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(152, 86);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
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
            this.radSeaConnect.Size = new System.Drawing.Size(154, 24);
            this.radSeaConnect.TabIndex = 7;
            this.radSeaConnect.Text = "SeaConnect 370";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(269, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "SeaDAC Lite inputs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(269, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "SeaConnect 370 inputs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(642, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "SeaDAC Lite outputs";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(632, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(251, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "SeaConnect 370 outputs";
            // 
            // radGo
            // 
            this.radGo.AutoCheck = false;
            this.radGo.AutoSize = true;
            this.radGo.Location = new System.Drawing.Point(647, 159);
            this.radGo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radGo.Name = "radGo";
            this.radGo.Size = new System.Drawing.Size(56, 24);
            this.radGo.TabIndex = 13;
            this.radGo.TabStop = true;
            this.radGo.Text = "Go";
            this.radGo.UseVisualStyleBackColor = true;
            // 
            // radStop
            // 
            this.radStop.AutoCheck = false;
            this.radStop.AutoSize = true;
            this.radStop.Location = new System.Drawing.Point(647, 191);
            this.radStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radStop.Name = "radStop";
            this.radStop.Size = new System.Drawing.Size(68, 24);
            this.radStop.TabIndex = 14;
            this.radStop.TabStop = true;
            this.radStop.Text = "Stop";
            this.radStop.UseVisualStyleBackColor = true;
            // 
            // radAudio
            // 
            this.radAudio.AutoCheck = false;
            this.radAudio.AutoSize = true;
            this.radAudio.Location = new System.Drawing.Point(647, 223);
            this.radAudio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radAudio.Name = "radAudio";
            this.radAudio.Size = new System.Drawing.Size(75, 24);
            this.radAudio.TabIndex = 15;
            this.radAudio.TabStop = true;
            this.radAudio.Text = "Audio";
            this.radAudio.UseVisualStyleBackColor = true;
            // 
            // radSignTrigger
            // 
            this.radSignTrigger.AutoCheck = false;
            this.radSignTrigger.AutoSize = true;
            this.radSignTrigger.Location = new System.Drawing.Point(274, 159);
            this.radSignTrigger.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radSignTrigger.Name = "radSignTrigger";
            this.radSignTrigger.Size = new System.Drawing.Size(119, 24);
            this.radSignTrigger.TabIndex = 16;
            this.radSignTrigger.TabStop = true;
            this.radSignTrigger.Text = "Sign Trigger";
            this.radSignTrigger.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1124, 691);
            this.Controls.Add(this.radSignTrigger);
            this.Controls.Add(this.radAudio);
            this.Controls.Add(this.radStop);
            this.Controls.Add(this.radGo);
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
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.RadioButton radGo;
        private System.Windows.Forms.RadioButton radStop;
        private System.Windows.Forms.RadioButton radAudio;
        private System.Windows.Forms.RadioButton radSignTrigger;
    }
}

