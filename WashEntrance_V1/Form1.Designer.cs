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
            this.tmrUpdateForm = new System.Windows.Forms.Timer(this.components);
            this.radSeaDACLite0 = new System.Windows.Forms.RadioButton();
            this.radSeaConnect = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logBtn = new System.Windows.Forms.Button();
            this.runBtn = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.radTireEye = new System.Windows.Forms.RadioButton();
            this.radStop = new System.Windows.Forms.RadioButton();
            this.inputsLabel = new System.Windows.Forms.Label();
            this.radSonar = new System.Windows.Forms.RadioButton();
            this.radAudio = new System.Windows.Forms.RadioButton();
            this.radPgmCar = new System.Windows.Forms.RadioButton();
            this.radRollerEye = new System.Windows.Forms.RadioButton();
            this.radFork = new System.Windows.Forms.RadioButton();
            this.radResetSigns = new System.Windows.Forms.RadioButton();
            this.radGoSign = new System.Windows.Forms.RadioButton();
            this.radBtnExtraRoller = new System.Windows.Forms.RadioButton();
            this.outputsLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.forkTestBtn = new System.Windows.Forms.Button();
            this.AudioTestBtn = new System.Windows.Forms.Button();
            this.changeSignsTestBtn = new System.Windows.Forms.Button();
            this.extraRollerTestBtn = new System.Windows.Forms.Button();
            this.logTxtBox = new System.Windows.Forms.TextBox();
            this.enableTestBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrUpdateForm
            // 
            this.tmrUpdateForm.Enabled = true;
            this.tmrUpdateForm.Interval = 50;
            this.tmrUpdateForm.Tick += new System.EventHandler(this.tmrUpdateForm_Tick);
            // 
            // radSeaDACLite0
            // 
            this.radSeaDACLite0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSeaDACLite0.AutoCheck = false;
            this.radSeaDACLite0.AutoSize = true;
            this.radSeaDACLite0.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSeaDACLite0.ForeColor = System.Drawing.Color.White;
            this.radSeaDACLite0.Location = new System.Drawing.Point(327, 89);
            this.radSeaDACLite0.Margin = new System.Windows.Forms.Padding(4);
            this.radSeaDACLite0.Name = "radSeaDACLite0";
            this.radSeaDACLite0.Size = new System.Drawing.Size(203, 33);
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
            this.radSeaConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSeaConnect.ForeColor = System.Drawing.Color.White;
            this.radSeaConnect.Location = new System.Drawing.Point(327, 131);
            this.radSeaConnect.Margin = new System.Windows.Forms.Padding(4);
            this.radSeaConnect.Name = "radSeaConnect";
            this.radSeaConnect.Size = new System.Drawing.Size(203, 33);
            this.radSeaConnect.TabIndex = 7;
            this.radSeaConnect.Text = "SeaDAC Lite 1";
            this.radSeaConnect.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.logBtn);
            this.panel1.Controls.Add(this.runBtn);
            this.panel1.Controls.Add(this.testBtn);
            this.panel1.Controls.Add(this.resetBtn);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 938);
            this.panel1.TabIndex = 18;
            // 
            // logBtn
            // 
            this.logBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.logBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.logBtn.FlatAppearance.BorderSize = 0;
            this.logBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logBtn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.logBtn.Image = global::WashEntrance_V1.Properties.Resources.icons8_log_64;
            this.logBtn.Location = new System.Drawing.Point(4, 357);
            this.logBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(287, 121);
            this.logBtn.TabIndex = 13;
            this.logBtn.Text = "Log";
            this.logBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.logBtn.UseVisualStyleBackColor = false;
            this.logBtn.Click += new System.EventHandler(this.logBtn_Click);
            this.logBtn.Leave += new System.EventHandler(this.logBtn_Leave);
            // 
            // runBtn
            // 
            this.runBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.runBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.runBtn.FlatAppearance.BorderSize = 0;
            this.runBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runBtn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.runBtn.Image = global::WashEntrance_V1.Properties.Resources.icons8_run_command_48;
            this.runBtn.Location = new System.Drawing.Point(4, 470);
            this.runBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(287, 121);
            this.runBtn.TabIndex = 12;
            this.runBtn.Text = "Run";
            this.runBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.runBtn.UseVisualStyleBackColor = false;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            this.runBtn.Leave += new System.EventHandler(this.runBtn_Leave);
            // 
            // testBtn
            // 
            this.testBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.testBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.testBtn.FlatAppearance.BorderSize = 0;
            this.testBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testBtn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.testBtn.Image = global::WashEntrance_V1.Properties.Resources.icons8_test_48;
            this.testBtn.Location = new System.Drawing.Point(4, 577);
            this.testBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(287, 121);
            this.testBtn.TabIndex = 11;
            this.testBtn.Text = "Test";
            this.testBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.testBtn.UseVisualStyleBackColor = false;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            this.testBtn.Leave += new System.EventHandler(this.testBtn_Leave);
            // 
            // resetBtn
            // 
            this.resetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.resetBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.resetBtn.FlatAppearance.BorderSize = 0;
            this.resetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetBtn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.resetBtn.Image = global::WashEntrance_V1.Properties.Resources.icons8_reset_48;
            this.resetBtn.Location = new System.Drawing.Point(4, 692);
            this.resetBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(287, 121);
            this.resetBtn.TabIndex = 10;
            this.resetBtn.Text = "Reset ";
            this.resetBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.resetBtn.UseVisualStyleBackColor = false;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            this.resetBtn.MouseLeave += new System.EventHandler(this.resetBtn_MouseLeave);
            this.resetBtn.MouseHover += new System.EventHandler(this.resetBtn_MouseHover);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(287, 261);
            this.panel2.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnExit.Image = global::WashEntrance_V1.Properties.Resources.icons8_exit_48;
            this.btnExit.Location = new System.Drawing.Point(4, 806);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(287, 121);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            this.btnExit.MouseHover += new System.EventHandler(this.btnExit_MouseHover);
            // 
            // radTireEye
            // 
            this.radTireEye.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTireEye.AutoCheck = false;
            this.radTireEye.AutoSize = true;
            this.radTireEye.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTireEye.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.radTireEye.Location = new System.Drawing.Point(532, 419);
            this.radTireEye.Margin = new System.Windows.Forms.Padding(4);
            this.radTireEye.Name = "radTireEye";
            this.radTireEye.Size = new System.Drawing.Size(106, 29);
            this.radTireEye.TabIndex = 0;
            this.radTireEye.TabStop = true;
            this.radTireEye.Text = "Tire Eye";
            this.radTireEye.UseVisualStyleBackColor = true;
            // 
            // radStop
            // 
            this.radStop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radStop.AutoCheck = false;
            this.radStop.AutoSize = true;
            this.radStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.radStop.Location = new System.Drawing.Point(850, 460);
            this.radStop.Margin = new System.Windows.Forms.Padding(4);
            this.radStop.Name = "radStop";
            this.radStop.Size = new System.Drawing.Size(198, 29);
            this.radStop.TabIndex = 14;
            this.radStop.TabStop = true;
            this.radStop.Text = "Stop Car in Neutral";
            this.radStop.UseVisualStyleBackColor = true;
            // 
            // inputsLabel
            // 
            this.inputsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputsLabel.AutoSize = true;
            this.inputsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.inputsLabel.Location = new System.Drawing.Point(524, 318);
            this.inputsLabel.Name = "inputsLabel";
            this.inputsLabel.Size = new System.Drawing.Size(116, 39);
            this.inputsLabel.TabIndex = 22;
            this.inputsLabel.Text = "Inputs";
            // 
            // radSonar
            // 
            this.radSonar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSonar.AutoCheck = false;
            this.radSonar.AutoSize = true;
            this.radSonar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSonar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.radSonar.Location = new System.Drawing.Point(532, 454);
            this.radSonar.Margin = new System.Windows.Forms.Padding(4);
            this.radSonar.Name = "radSonar";
            this.radSonar.Size = new System.Drawing.Size(86, 29);
            this.radSonar.TabIndex = 11;
            this.radSonar.TabStop = true;
            this.radSonar.Text = "Sonar";
            this.radSonar.UseVisualStyleBackColor = true;
            // 
            // radAudio
            // 
            this.radAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radAudio.AutoCheck = false;
            this.radAudio.AutoSize = true;
            this.radAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAudio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.radAudio.Location = new System.Drawing.Point(850, 498);
            this.radAudio.Margin = new System.Windows.Forms.Padding(4);
            this.radAudio.Name = "radAudio";
            this.radAudio.Size = new System.Drawing.Size(84, 29);
            this.radAudio.TabIndex = 13;
            this.radAudio.TabStop = true;
            this.radAudio.Text = "Audio";
            this.radAudio.UseVisualStyleBackColor = true;
            // 
            // radPgmCar
            // 
            this.radPgmCar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radPgmCar.AutoCheck = false;
            this.radPgmCar.AutoSize = true;
            this.radPgmCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPgmCar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.radPgmCar.Location = new System.Drawing.Point(532, 488);
            this.radPgmCar.Margin = new System.Windows.Forms.Padding(4);
            this.radPgmCar.Name = "radPgmCar";
            this.radPgmCar.Size = new System.Drawing.Size(144, 29);
            this.radPgmCar.TabIndex = 10;
            this.radPgmCar.TabStop = true;
            this.radPgmCar.Text = "Program Car";
            this.radPgmCar.UseVisualStyleBackColor = true;
            // 
            // radRollerEye
            // 
            this.radRollerEye.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radRollerEye.AutoCheck = false;
            this.radRollerEye.AutoSize = true;
            this.radRollerEye.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRollerEye.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.radRollerEye.Location = new System.Drawing.Point(532, 385);
            this.radRollerEye.Margin = new System.Windows.Forms.Padding(4);
            this.radRollerEye.Name = "radRollerEye";
            this.radRollerEye.Size = new System.Drawing.Size(121, 29);
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
            this.radFork.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radFork.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.radFork.Location = new System.Drawing.Point(850, 392);
            this.radFork.Margin = new System.Windows.Forms.Padding(4);
            this.radFork.Name = "radFork";
            this.radFork.Size = new System.Drawing.Size(102, 29);
            this.radFork.TabIndex = 2;
            this.radFork.TabStop = true;
            this.radFork.Text = "Fork Up";
            this.radFork.UseVisualStyleBackColor = true;
            // 
            // radResetSigns
            // 
            this.radResetSigns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radResetSigns.AutoCheck = false;
            this.radResetSigns.AutoSize = true;
            this.radResetSigns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radResetSigns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.radResetSigns.Location = new System.Drawing.Point(532, 523);
            this.radResetSigns.Margin = new System.Windows.Forms.Padding(4);
            this.radResetSigns.Name = "radResetSigns";
            this.radResetSigns.Size = new System.Drawing.Size(128, 29);
            this.radResetSigns.TabIndex = 12;
            this.radResetSigns.TabStop = true;
            this.radResetSigns.Text = "Sign Reset";
            this.radResetSigns.UseVisualStyleBackColor = true;
            // 
            // radGoSign
            // 
            this.radGoSign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGoSign.AutoCheck = false;
            this.radGoSign.AutoSize = true;
            this.radGoSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGoSign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.radGoSign.Location = new System.Drawing.Point(850, 424);
            this.radGoSign.Margin = new System.Windows.Forms.Padding(4);
            this.radGoSign.Name = "radGoSign";
            this.radGoSign.Size = new System.Drawing.Size(206, 29);
            this.radGoSign.TabIndex = 15;
            this.radGoSign.TabStop = true;
            this.radGoSign.Text = "Please Pull Forward";
            this.radGoSign.UseVisualStyleBackColor = true;
            // 
            // radBtnExtraRoller
            // 
            this.radBtnExtraRoller.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radBtnExtraRoller.AutoCheck = false;
            this.radBtnExtraRoller.AutoSize = true;
            this.radBtnExtraRoller.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBtnExtraRoller.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.radBtnExtraRoller.Location = new System.Drawing.Point(532, 561);
            this.radBtnExtraRoller.Margin = new System.Windows.Forms.Padding(4);
            this.radBtnExtraRoller.Name = "radBtnExtraRoller";
            this.radBtnExtraRoller.Size = new System.Drawing.Size(166, 29);
            this.radBtnExtraRoller.TabIndex = 24;
            this.radBtnExtraRoller.TabStop = true;
            this.radBtnExtraRoller.Text = "Extra Roller Btn";
            this.radBtnExtraRoller.UseVisualStyleBackColor = true;
            // 
            // outputsLabel
            // 
            this.outputsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputsLabel.AutoSize = true;
            this.outputsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.outputsLabel.Location = new System.Drawing.Point(842, 318);
            this.outputsLabel.Name = "outputsLabel";
            this.outputsLabel.Size = new System.Drawing.Size(142, 39);
            this.outputsLabel.TabIndex = 25;
            this.outputsLabel.Text = "Outputs";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label2.Location = new System.Drawing.Point(319, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 39);
            this.label2.TabIndex = 26;
            this.label2.Text = "Devices";
            // 
            // forkTestBtn
            // 
            this.forkTestBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.forkTestBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.forkTestBtn.FlatAppearance.BorderSize = 0;
            this.forkTestBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forkTestBtn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forkTestBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.forkTestBtn.Location = new System.Drawing.Point(524, 707);
            this.forkTestBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.forkTestBtn.Name = "forkTestBtn";
            this.forkTestBtn.Size = new System.Drawing.Size(239, 90);
            this.forkTestBtn.TabIndex = 27;
            this.forkTestBtn.Text = "Fork";
            this.forkTestBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.forkTestBtn.UseVisualStyleBackColor = false;
            this.forkTestBtn.Click += new System.EventHandler(this.forkTestBtn_Click);
            // 
            // AudioTestBtn
            // 
            this.AudioTestBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.AudioTestBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AudioTestBtn.FlatAppearance.BorderSize = 0;
            this.AudioTestBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AudioTestBtn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AudioTestBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.AudioTestBtn.Location = new System.Drawing.Point(524, 826);
            this.AudioTestBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AudioTestBtn.Name = "AudioTestBtn";
            this.AudioTestBtn.Size = new System.Drawing.Size(239, 90);
            this.AudioTestBtn.TabIndex = 28;
            this.AudioTestBtn.Text = "Audio";
            this.AudioTestBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.AudioTestBtn.UseVisualStyleBackColor = false;
            this.AudioTestBtn.Click += new System.EventHandler(this.AudioTestBtn_Click);
            // 
            // changeSignsTestBtn
            // 
            this.changeSignsTestBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.changeSignsTestBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.changeSignsTestBtn.FlatAppearance.BorderSize = 0;
            this.changeSignsTestBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeSignsTestBtn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeSignsTestBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.changeSignsTestBtn.Location = new System.Drawing.Point(802, 707);
            this.changeSignsTestBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.changeSignsTestBtn.Name = "changeSignsTestBtn";
            this.changeSignsTestBtn.Size = new System.Drawing.Size(239, 90);
            this.changeSignsTestBtn.TabIndex = 29;
            this.changeSignsTestBtn.Text = "Change Signs";
            this.changeSignsTestBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.changeSignsTestBtn.UseVisualStyleBackColor = false;
            this.changeSignsTestBtn.Click += new System.EventHandler(this.changeSignsTestBtn_Click);
            // 
            // extraRollerTestBtn
            // 
            this.extraRollerTestBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.extraRollerTestBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.extraRollerTestBtn.FlatAppearance.BorderSize = 0;
            this.extraRollerTestBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.extraRollerTestBtn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extraRollerTestBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.extraRollerTestBtn.Location = new System.Drawing.Point(802, 826);
            this.extraRollerTestBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.extraRollerTestBtn.Name = "extraRollerTestBtn";
            this.extraRollerTestBtn.Size = new System.Drawing.Size(239, 90);
            this.extraRollerTestBtn.TabIndex = 30;
            this.extraRollerTestBtn.Text = "Extra Roller Button";
            this.extraRollerTestBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.extraRollerTestBtn.UseVisualStyleBackColor = false;
            this.extraRollerTestBtn.Click += new System.EventHandler(this.extraRollerTestBtn_Click);
            // 
            // logTxtBox
            // 
            this.logTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.logTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTxtBox.ForeColor = System.Drawing.Color.White;
            this.logTxtBox.Location = new System.Drawing.Point(325, 187);
            this.logTxtBox.Multiline = true;
            this.logTxtBox.Name = "logTxtBox";
            this.logTxtBox.ReadOnly = true;
            this.logTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTxtBox.Size = new System.Drawing.Size(1035, 58);
            this.logTxtBox.TabIndex = 31;
            // 
            // enableTestBtn
            // 
            this.enableTestBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.enableTestBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.enableTestBtn.FlatAppearance.BorderSize = 0;
            this.enableTestBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableTestBtn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableTestBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.enableTestBtn.Location = new System.Drawing.Point(1112, 21);
            this.enableTestBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.enableTestBtn.Name = "enableTestBtn";
            this.enableTestBtn.Size = new System.Drawing.Size(239, 90);
            this.enableTestBtn.TabIndex = 32;
            this.enableTestBtn.Text = "Enable Test Button";
            this.enableTestBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.enableTestBtn.UseVisualStyleBackColor = false;
            this.enableTestBtn.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1326, 938);
            this.ControlBox = false;
            this.Controls.Add(this.enableTestBtn);
            this.Controls.Add(this.logTxtBox);
            this.Controls.Add(this.extraRollerTestBtn);
            this.Controls.Add(this.changeSignsTestBtn);
            this.Controls.Add(this.AudioTestBtn);
            this.Controls.Add(this.forkTestBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radSeaDACLite0);
            this.Controls.Add(this.radSeaConnect);
            this.Controls.Add(this.outputsLabel);
            this.Controls.Add(this.radBtnExtraRoller);
            this.Controls.Add(this.radGoSign);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radResetSigns);
            this.Controls.Add(this.radTireEye);
            this.Controls.Add(this.radFork);
            this.Controls.Add(this.radStop);
            this.Controls.Add(this.radRollerEye);
            this.Controls.Add(this.inputsLabel);
            this.Controls.Add(this.radPgmCar);
            this.Controls.Add(this.radSonar);
            this.Controls.Add(this.radAudio);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wash Entrance Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmrUpdateForm;
        private System.Windows.Forms.RadioButton radSeaDACLite0;
        private System.Windows.Forms.RadioButton radSeaConnect;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.RadioButton radTireEye;
        private System.Windows.Forms.RadioButton radStop;
        private System.Windows.Forms.Label inputsLabel;
        private System.Windows.Forms.RadioButton radSonar;
        private System.Windows.Forms.RadioButton radAudio;
        private System.Windows.Forms.RadioButton radPgmCar;
        private System.Windows.Forms.RadioButton radRollerEye;
        private System.Windows.Forms.RadioButton radFork;
        private System.Windows.Forms.RadioButton radResetSigns;
        private System.Windows.Forms.RadioButton radGoSign;
        private System.Windows.Forms.RadioButton radBtnExtraRoller;
        private System.Windows.Forms.Label outputsLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Button forkTestBtn;
        private System.Windows.Forms.Button AudioTestBtn;
        private System.Windows.Forms.Button changeSignsTestBtn;
        private System.Windows.Forms.Button extraRollerTestBtn;
        private System.Windows.Forms.Button logBtn;
        private System.Windows.Forms.TextBox logTxtBox;
        private System.Windows.Forms.Button enableTestBtn;
    }
}

