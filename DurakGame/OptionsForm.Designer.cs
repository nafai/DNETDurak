namespace DurakGame
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.lblOptions = new System.Windows.Forms.Label();
            this.lblDeckSize = new System.Windows.Forms.Label();
            this.lblAIPlayers = new System.Windows.Forms.Label();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.btnNewGame = new System.Windows.Forms.Button();
            this.chkNoHuman = new System.Windows.Forms.CheckBox();
            this.cmbAIPlayers = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpChooseBack = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pbCardBack1 = new System.Windows.Forms.PictureBox();
            this.pbCardBack2 = new System.Windows.Forms.PictureBox();
            this.pbCardBack3 = new System.Windows.Forms.PictureBox();
            this.pbCardBack4 = new System.Windows.Forms.PictureBox();
            this.cmbDeckSize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnDirectoryPicker = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.pictureCard2 = new G4CardLib.PictureCard();
            this.label2 = new System.Windows.Forms.Label();
            this.grpChooseBack.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardBack1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardBack2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardBack3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardBack4)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOptions
            // 
            this.lblOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptions.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblOptions.Location = new System.Drawing.Point(0, 0);
            this.lblOptions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(473, 76);
            this.lblOptions.TabIndex = 0;
            this.lblOptions.Text = "Options";
            this.lblOptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDeckSize
            // 
            this.lblDeckSize.AutoSize = true;
            this.lblDeckSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeckSize.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDeckSize.Location = new System.Drawing.Point(11, 76);
            this.lblDeckSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeckSize.Name = "lblDeckSize";
            this.lblDeckSize.Size = new System.Drawing.Size(190, 39);
            this.lblDeckSize.TabIndex = 1;
            this.lblDeckSize.Text = "&Deck Size:";
            // 
            // lblAIPlayers
            // 
            this.lblAIPlayers.AutoSize = true;
            this.lblAIPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAIPlayers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAIPlayers.Location = new System.Drawing.Point(11, 134);
            this.lblAIPlayers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAIPlayers.Name = "lblAIPlayers";
            this.lblAIPlayers.Size = new System.Drawing.Size(193, 39);
            this.lblAIPlayers.TabIndex = 3;
            this.lblAIPlayers.Text = "&AI Players:";
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(18, 523);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(120, 50);
            this.btnNewGame.TabIndex = 12;
            this.btnNewGame.Text = "&New Game";
            this.toolTips.SetToolTip(this.btnNewGame, "Start a new game");
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // chkNoHuman
            // 
            this.chkNoHuman.AutoSize = true;
            this.chkNoHuman.Location = new System.Drawing.Point(223, 206);
            this.chkNoHuman.Name = "chkNoHuman";
            this.chkNoHuman.Size = new System.Drawing.Size(18, 17);
            this.chkNoHuman.TabIndex = 6;
            this.toolTips.SetToolTip(this.chkNoHuman, "Select this for an automatic game between computers.");
            this.chkNoHuman.UseVisualStyleBackColor = true;
            // 
            // cmbAIPlayers
            // 
            this.cmbAIPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAIPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAIPlayers.FormattingEnabled = true;
            this.cmbAIPlayers.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbAIPlayers.Location = new System.Drawing.Point(223, 140);
            this.cmbAIPlayers.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAIPlayers.Name = "cmbAIPlayers";
            this.cmbAIPlayers.Size = new System.Drawing.Size(235, 37);
            this.cmbAIPlayers.TabIndex = 4;
            this.toolTips.SetToolTip(this.cmbAIPlayers, "Number of players in addition to Player 1");
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(342, 523);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 50);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "&Cancel";
            this.toolTips.SetToolTip(this.btnExit, "Do not save settings");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // grpChooseBack
            // 
            this.grpChooseBack.BackColor = System.Drawing.Color.Black;
            this.grpChooseBack.Controls.Add(this.flowLayoutPanel1);
            this.grpChooseBack.ForeColor = System.Drawing.Color.White;
            this.grpChooseBack.Location = new System.Drawing.Point(18, 241);
            this.grpChooseBack.Margin = new System.Windows.Forms.Padding(4);
            this.grpChooseBack.Name = "grpChooseBack";
            this.grpChooseBack.Padding = new System.Windows.Forms.Padding(4);
            this.grpChooseBack.Size = new System.Drawing.Size(440, 189);
            this.grpChooseBack.TabIndex = 7;
            this.grpChooseBack.TabStop = false;
            this.grpChooseBack.Text = "Change &Back";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pbCardBack1);
            this.flowLayoutPanel1.Controls.Add(this.pbCardBack2);
            this.flowLayoutPanel1.Controls.Add(this.pbCardBack3);
            this.flowLayoutPanel1.Controls.Add(this.pbCardBack4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(432, 158);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pbCardBack1
            // 
            this.pbCardBack1.Image = global::DurakGame.Properties.Resources.card_back_1;
            this.pbCardBack1.Location = new System.Drawing.Point(3, 3);
            this.pbCardBack1.Name = "pbCardBack1";
            this.pbCardBack1.Size = new System.Drawing.Size(100, 145);
            this.pbCardBack1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCardBack1.TabIndex = 11;
            this.pbCardBack1.TabStop = false;
            this.pbCardBack1.Click += new System.EventHandler(this.pbCardBack1_Click);
            // 
            // pbCardBack2
            // 
            this.pbCardBack2.Image = global::DurakGame.Properties.Resources.card_back_2;
            this.pbCardBack2.Location = new System.Drawing.Point(109, 3);
            this.pbCardBack2.Name = "pbCardBack2";
            this.pbCardBack2.Size = new System.Drawing.Size(100, 145);
            this.pbCardBack2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCardBack2.TabIndex = 11;
            this.pbCardBack2.TabStop = false;
            this.pbCardBack2.Click += new System.EventHandler(this.pbCardBack2_Click);
            // 
            // pbCardBack3
            // 
            this.pbCardBack3.Image = global::DurakGame.Properties.Resources.card_back_3;
            this.pbCardBack3.Location = new System.Drawing.Point(215, 3);
            this.pbCardBack3.Name = "pbCardBack3";
            this.pbCardBack3.Size = new System.Drawing.Size(100, 145);
            this.pbCardBack3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCardBack3.TabIndex = 11;
            this.pbCardBack3.TabStop = false;
            this.pbCardBack3.Click += new System.EventHandler(this.pbCardBack3_Click);
            // 
            // pbCardBack4
            // 
            this.pbCardBack4.Image = global::DurakGame.Properties.Resources.card_back_4;
            this.pbCardBack4.Location = new System.Drawing.Point(321, 3);
            this.pbCardBack4.Name = "pbCardBack4";
            this.pbCardBack4.Size = new System.Drawing.Size(100, 145);
            this.pbCardBack4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCardBack4.TabIndex = 11;
            this.pbCardBack4.TabStop = false;
            this.pbCardBack4.Click += new System.EventHandler(this.pbCardBack4_Click);
            // 
            // cmbDeckSize
            // 
            this.cmbDeckSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeckSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDeckSize.FormattingEnabled = true;
            this.cmbDeckSize.Items.AddRange(new object[] {
            "20",
            "36 (Default)",
            "52"});
            this.cmbDeckSize.Location = new System.Drawing.Point(223, 82);
            this.cmbDeckSize.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDeckSize.Name = "cmbDeckSize";
            this.cmbDeckSize.Size = new System.Drawing.Size(235, 37);
            this.cmbDeckSize.TabIndex = 2;
            this.toolTips.SetToolTip(this.cmbDeckSize, "Number of cards in the deck");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "&Log file location:";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(17, 460);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(320, 30);
            this.txtDirectory.TabIndex = 10;
            // 
            // btnDirectoryPicker
            // 
            this.btnDirectoryPicker.Location = new System.Drawing.Point(343, 460);
            this.btnDirectoryPicker.Name = "btnDirectoryPicker";
            this.btnDirectoryPicker.Size = new System.Drawing.Size(116, 30);
            this.btnDirectoryPicker.TabIndex = 11;
            this.btnDirectoryPicker.Text = "&Browse";
            this.btnDirectoryPicker.UseVisualStyleBackColor = true;
            this.btnDirectoryPicker.Click += new System.EventHandler(this.btnDirectoryPicker_Click);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFolder.Image")));
            this.btnOpenFolder.Location = new System.Drawing.Point(237, 433);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(25, 23);
            this.btnOpenFolder.TabIndex = 9;
            this.toolTips.SetToolTip(this.btnOpenFolder, "Open folder location in Explorer");
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHelp.Location = new System.Drawing.Point(180, 523);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(120, 50);
            this.btnHelp.TabIndex = 13;
            this.btnHelp.Text = "&Help";
            this.toolTips.SetToolTip(this.btnHelp, "Open help window");
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // pictureCard2
            // 
            this.pictureCard2.Face = G4CardLib.Face.Down;
            this.pictureCard2.Hoverable = true;
            this.pictureCard2.Location = new System.Drawing.Point(3, 35);
            this.pictureCard2.Name = "pictureCard2";
            this.pictureCard2.Rank = G4CardLib.Rank.Ace;
            this.pictureCard2.Rotated = false;
            this.pictureCard2.Size = new System.Drawing.Size(100, 145);
            this.pictureCard2.Suit = G4CardLib.Suit.Spades;
            this.pictureCard2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(11, 192);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 39);
            this.label2.TabIndex = 5;
            this.label2.Text = "&Player 1 AI:";
            // 
            // frmOptions
            // 
            this.AcceptButton = this.btnNewGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(473, 589);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.chkNoHuman);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.btnDirectoryPicker);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpChooseBack);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.cmbDeckSize);
            this.Controls.Add(this.cmbAIPlayers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAIPlayers);
            this.Controls.Add(this.lblDeckSize);
            this.Controls.Add(this.lblOptions);
            this.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.grpChooseBack.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCardBack1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardBack2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardBack3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardBack4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.Label lblDeckSize;
        private System.Windows.Forms.Label lblAIPlayers;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.ComboBox cmbAIPlayers;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox grpChooseBack;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbDeckSize;
        private System.Windows.Forms.PictureBox pbCardBack2;
        private G4CardLib.PictureCard pictureCard2;
        private System.Windows.Forms.PictureBox pbCardBack1;
        private System.Windows.Forms.PictureBox pbCardBack3;
        private System.Windows.Forms.PictureBox pbCardBack4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnDirectoryPicker;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.CheckBox chkNoHuman;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label label2;
    }
}