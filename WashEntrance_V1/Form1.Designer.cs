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
            this.SuspendLayout();
            // 
            // radRollerCall
            // 
            this.radRollerCall.AutoCheck = false;
            this.radRollerCall.AutoSize = true;
            this.radRollerCall.Location = new System.Drawing.Point(63, 172);
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
            this.radRollerEye.Location = new System.Drawing.Point(63, 214);
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
            this.radFork.Location = new System.Drawing.Point(282, 171);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inputs";
            // 
            // Ouputs
            // 
            this.Ouputs.AutoSize = true;
            this.Ouputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ouputs.Location = new System.Drawing.Point(282, 115);
            this.Ouputs.Name = "Ouputs";
            this.Ouputs.Size = new System.Drawing.Size(110, 31);
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
            this.btnExit.Location = new System.Drawing.Point(316, 358);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(135, 69);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

