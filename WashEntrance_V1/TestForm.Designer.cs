namespace WashEntrance_V1
{
    partial class TestForm
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
            this.TestFork = new System.Windows.Forms.Button();
            this.TestSigns = new System.Windows.Forms.Button();
            this.TestExtraRollerBtn = new System.Windows.Forms.Button();
            this.TestAudio = new System.Windows.Forms.Button();
            this.UpdateForm = new System.Windows.Forms.Timer(this.components);
            this.goRad = new System.Windows.Forms.RadioButton();
            this.stopRad = new System.Windows.Forms.RadioButton();
            this.forkRad = new System.Windows.Forms.RadioButton();
            this.extraRollerBtnRad = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.resetBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.audioRad = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // TestFork
            // 
            this.TestFork.Location = new System.Drawing.Point(138, 150);
            this.TestFork.Name = "TestFork";
            this.TestFork.Size = new System.Drawing.Size(127, 31);
            this.TestFork.TabIndex = 0;
            this.TestFork.Text = "Fork";
            this.TestFork.UseVisualStyleBackColor = true;
            this.TestFork.Click += new System.EventHandler(this.TestFork_Click);
            // 
            // TestSigns
            // 
            this.TestSigns.Location = new System.Drawing.Point(271, 150);
            this.TestSigns.Name = "TestSigns";
            this.TestSigns.Size = new System.Drawing.Size(127, 30);
            this.TestSigns.TabIndex = 1;
            this.TestSigns.Text = "Change Signs";
            this.TestSigns.UseVisualStyleBackColor = true;
            this.TestSigns.Click += new System.EventHandler(this.TestSigns_Click);
            // 
            // TestExtraRollerBtn
            // 
            this.TestExtraRollerBtn.Location = new System.Drawing.Point(404, 151);
            this.TestExtraRollerBtn.Name = "TestExtraRollerBtn";
            this.TestExtraRollerBtn.Size = new System.Drawing.Size(127, 30);
            this.TestExtraRollerBtn.TabIndex = 2;
            this.TestExtraRollerBtn.Text = "Extra Roller Btn";
            this.TestExtraRollerBtn.UseVisualStyleBackColor = true;
            this.TestExtraRollerBtn.Click += new System.EventHandler(this.TestExtraRollerBtn_Click);
            // 
            // TestAudio
            // 
            this.TestAudio.Location = new System.Drawing.Point(537, 151);
            this.TestAudio.Name = "TestAudio";
            this.TestAudio.Size = new System.Drawing.Size(127, 30);
            this.TestAudio.TabIndex = 3;
            this.TestAudio.Text = "Audio";
            this.TestAudio.UseVisualStyleBackColor = true;
            this.TestAudio.Click += new System.EventHandler(this.TestAudio_Click);
            // 
            // UpdateForm
            // 
            this.UpdateForm.Enabled = true;
            this.UpdateForm.Interval = 50;
            this.UpdateForm.Tick += new System.EventHandler(this.UpdateForm_Tick);
            // 
            // goRad
            // 
            this.goRad.AutoSize = true;
            this.goRad.Location = new System.Drawing.Point(334, 272);
            this.goRad.Name = "goRad";
            this.goRad.Size = new System.Drawing.Size(118, 17);
            this.goRad.TabIndex = 4;
            this.goRad.TabStop = true;
            this.goRad.Text = "Please Pull Forward";
            this.goRad.UseVisualStyleBackColor = true;
            // 
            // stopRad
            // 
            this.stopRad.AutoSize = true;
            this.stopRad.Location = new System.Drawing.Point(334, 296);
            this.stopRad.Name = "stopRad";
            this.stopRad.Size = new System.Drawing.Size(114, 17);
            this.stopRad.TabIndex = 5;
            this.stopRad.TabStop = true;
            this.stopRad.Text = "Stop Car in Neutral";
            this.stopRad.UseVisualStyleBackColor = true;
            // 
            // forkRad
            // 
            this.forkRad.AutoSize = true;
            this.forkRad.Location = new System.Drawing.Point(334, 319);
            this.forkRad.Name = "forkRad";
            this.forkRad.Size = new System.Drawing.Size(90, 17);
            this.forkRad.TabIndex = 6;
            this.forkRad.TabStop = true;
            this.forkRad.Text = "Fork Solenoid";
            this.forkRad.UseVisualStyleBackColor = true;
            // 
            // extraRollerBtnRad
            // 
            this.extraRollerBtnRad.AutoSize = true;
            this.extraRollerBtnRad.Location = new System.Drawing.Point(334, 343);
            this.extraRollerBtnRad.Name = "extraRollerBtnRad";
            this.extraRollerBtnRad.Size = new System.Drawing.Size(113, 17);
            this.extraRollerBtnRad.TabIndex = 7;
            this.extraRollerBtnRad.TabStop = true;
            this.extraRollerBtnRad.Text = "Extra Roller Button";
            this.extraRollerBtnRad.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(767, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "Click the button of the control you want to test. \r\nTo reset the control click th" +
    "e \"Reset\" button, all controls will reset to their original state!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(687, 319);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(101, 47);
            this.resetBtn.TabIndex = 9;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(687, 391);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(101, 47);
            this.exitBtn.TabIndex = 10;
            this.exitBtn.Text = "EXIT";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // audioRad
            // 
            this.audioRad.AutoSize = true;
            this.audioRad.Location = new System.Drawing.Point(334, 367);
            this.audioRad.Name = "audioRad";
            this.audioRad.Size = new System.Drawing.Size(52, 17);
            this.audioRad.TabIndex = 11;
            this.audioRad.TabStop = true;
            this.audioRad.Text = "Audio";
            this.audioRad.UseVisualStyleBackColor = true;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.audioRad);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.extraRollerBtnRad);
            this.Controls.Add(this.forkRad);
            this.Controls.Add(this.stopRad);
            this.Controls.Add(this.goRad);
            this.Controls.Add(this.TestAudio);
            this.Controls.Add(this.TestExtraRollerBtn);
            this.Controls.Add(this.TestSigns);
            this.Controls.Add(this.TestFork);
            this.Name = "TestForm";
            this.Text = "Test Form";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TestFork;
        private System.Windows.Forms.Button TestSigns;
        private System.Windows.Forms.Button TestExtraRollerBtn;
        private System.Windows.Forms.Button TestAudio;
        private System.Windows.Forms.Timer UpdateForm;
        private System.Windows.Forms.RadioButton goRad;
        private System.Windows.Forms.RadioButton stopRad;
        private System.Windows.Forms.RadioButton forkRad;
        private System.Windows.Forms.RadioButton extraRollerBtnRad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.RadioButton audioRad;
    }
}