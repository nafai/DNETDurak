namespace DurakGame
{
    partial class frmMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.grpPlayer2 = new System.Windows.Forms.GroupBox();
            this.grpPlayer3 = new System.Windows.Forms.GroupBox();
            this.grpPlayer4 = new System.Windows.Forms.GroupBox();
            this.grpPlayer5 = new System.Windows.Forms.GroupBox();
            this.grpPlayer6 = new System.Windows.Forms.GroupBox();
            this.grpPlayer1 = new System.Windows.Forms.GroupBox();
            this.lblAttackOrDefend = new System.Windows.Forms.Label();
            this.btnContextual = new System.Windows.Forms.Button();
            this.grpPlayField = new System.Windows.Forms.GroupBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.grpDeck = new System.Windows.Forms.GroupBox();
            this.picTrump = new System.Windows.Forms.PictureBox();
            this.ttpDescription = new System.Windows.Forms.ToolTip(this.components);
            this.grpMessages = new System.Windows.Forms.GroupBox();
            this.txtGameMessages = new System.Windows.Forms.TextBox();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.grpPlayer1.SuspendLayout();
            this.grpDeck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTrump)).BeginInit();
            this.grpMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPlayer2
            // 
            this.grpPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.grpPlayer2.ForeColor = System.Drawing.Color.White;
            this.grpPlayer2.Location = new System.Drawing.Point(13, 13);
            this.grpPlayer2.Name = "grpPlayer2";
            this.grpPlayer2.Size = new System.Drawing.Size(200, 206);
            this.grpPlayer2.TabIndex = 0;
            this.grpPlayer2.TabStop = false;
            this.grpPlayer2.Text = "Player 2";
            // 
            // grpPlayer3
            // 
            this.grpPlayer3.BackColor = System.Drawing.Color.Transparent;
            this.grpPlayer3.ForeColor = System.Drawing.Color.White;
            this.grpPlayer3.Location = new System.Drawing.Point(220, 13);
            this.grpPlayer3.Name = "grpPlayer3";
            this.grpPlayer3.Size = new System.Drawing.Size(200, 206);
            this.grpPlayer3.TabIndex = 1;
            this.grpPlayer3.TabStop = false;
            this.grpPlayer3.Text = "Player 3";
            // 
            // grpPlayer4
            // 
            this.grpPlayer4.BackColor = System.Drawing.Color.Transparent;
            this.grpPlayer4.ForeColor = System.Drawing.Color.White;
            this.grpPlayer4.Location = new System.Drawing.Point(427, 13);
            this.grpPlayer4.Name = "grpPlayer4";
            this.grpPlayer4.Size = new System.Drawing.Size(200, 206);
            this.grpPlayer4.TabIndex = 2;
            this.grpPlayer4.TabStop = false;
            this.grpPlayer4.Text = "Player 4";
            // 
            // grpPlayer5
            // 
            this.grpPlayer5.BackColor = System.Drawing.Color.Transparent;
            this.grpPlayer5.ForeColor = System.Drawing.Color.White;
            this.grpPlayer5.Location = new System.Drawing.Point(634, 13);
            this.grpPlayer5.Name = "grpPlayer5";
            this.grpPlayer5.Size = new System.Drawing.Size(200, 206);
            this.grpPlayer5.TabIndex = 3;
            this.grpPlayer5.TabStop = false;
            this.grpPlayer5.Text = "Player 5";
            // 
            // grpPlayer6
            // 
            this.grpPlayer6.BackColor = System.Drawing.Color.Transparent;
            this.grpPlayer6.ForeColor = System.Drawing.Color.White;
            this.grpPlayer6.Location = new System.Drawing.Point(841, 13);
            this.grpPlayer6.Name = "grpPlayer6";
            this.grpPlayer6.Size = new System.Drawing.Size(200, 206);
            this.grpPlayer6.TabIndex = 4;
            this.grpPlayer6.TabStop = false;
            this.grpPlayer6.Text = "Player 6";
            // 
            // grpPlayer1
            // 
            this.grpPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.grpPlayer1.Controls.Add(this.lblAttackOrDefend);
            this.grpPlayer1.Controls.Add(this.btnContextual);
            this.grpPlayer1.ForeColor = System.Drawing.Color.White;
            this.grpPlayer1.Location = new System.Drawing.Point(13, 225);
            this.grpPlayer1.Name = "grpPlayer1";
            this.grpPlayer1.Size = new System.Drawing.Size(399, 201);
            this.grpPlayer1.TabIndex = 7;
            this.grpPlayer1.TabStop = false;
            this.grpPlayer1.Text = "Player 1";
            // 
            // lblAttackOrDefend
            // 
            this.lblAttackOrDefend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAttackOrDefend.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttackOrDefend.Location = new System.Drawing.Point(245, 18);
            this.lblAttackOrDefend.Name = "lblAttackOrDefend";
            this.lblAttackOrDefend.Size = new System.Drawing.Size(148, 31);
            this.lblAttackOrDefend.TabIndex = 1;
            this.lblAttackOrDefend.Text = "Player 1 Move";
            this.lblAttackOrDefend.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnContextual
            // 
            this.btnContextual.Enabled = false;
            this.btnContextual.ForeColor = System.Drawing.Color.Black;
            this.btnContextual.Location = new System.Drawing.Point(283, 172);
            this.btnContextual.Name = "btnContextual";
            this.btnContextual.Size = new System.Drawing.Size(110, 23);
            this.btnContextual.TabIndex = 0;
            this.btnContextual.Text = "...";
            this.btnContextual.UseVisualStyleBackColor = true;
            // 
            // grpPlayField
            // 
            this.grpPlayField.BackColor = System.Drawing.Color.Transparent;
            this.grpPlayField.ForeColor = System.Drawing.Color.White;
            this.grpPlayField.Location = new System.Drawing.Point(418, 226);
            this.grpPlayField.Name = "grpPlayField";
            this.grpPlayField.Size = new System.Drawing.Size(417, 200);
            this.grpPlayField.TabIndex = 5;
            this.grpPlayField.TabStop = false;
            this.grpPlayField.Text = "Playing Field";
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(967, 429);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(876, 429);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(85, 23);
            this.btnOptions.TabIndex = 11;
            this.btnOptions.Text = "&Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // grpDeck
            // 
            this.grpDeck.BackColor = System.Drawing.Color.Transparent;
            this.grpDeck.Controls.Add(this.picTrump);
            this.grpDeck.ForeColor = System.Drawing.Color.White;
            this.grpDeck.Location = new System.Drawing.Point(842, 226);
            this.grpDeck.Name = "grpDeck";
            this.grpDeck.Size = new System.Drawing.Size(200, 200);
            this.grpDeck.TabIndex = 6;
            this.grpDeck.TabStop = false;
            this.grpDeck.Text = "Deck";
            // 
            // picTrump
            // 
            this.picTrump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picTrump.InitialImage = null;
            this.picTrump.Location = new System.Drawing.Point(50, 50);
            this.picTrump.Name = "picTrump";
            this.picTrump.Size = new System.Drawing.Size(100, 100);
            this.picTrump.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTrump.TabIndex = 0;
            this.picTrump.TabStop = false;
            this.ttpDescription.SetToolTip(this.picTrump, "Trump suit");
            // 
            // grpMessages
            // 
            this.grpMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMessages.BackColor = System.Drawing.Color.Transparent;
            this.grpMessages.Controls.Add(this.txtGameMessages);
            this.grpMessages.ForeColor = System.Drawing.Color.White;
            this.grpMessages.Location = new System.Drawing.Point(13, 458);
            this.grpMessages.Name = "grpMessages";
            this.grpMessages.Size = new System.Drawing.Size(1029, 158);
            this.grpMessages.TabIndex = 4;
            this.grpMessages.TabStop = false;
            this.grpMessages.Text = "Game Messages";
            // 
            // txtGameMessages
            // 
            this.txtGameMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGameMessages.BackColor = System.Drawing.SystemColors.Info;
            this.txtGameMessages.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGameMessages.Location = new System.Drawing.Point(7, 21);
            this.txtGameMessages.Multiline = true;
            this.txtGameMessages.Name = "txtGameMessages";
            this.txtGameMessages.ReadOnly = true;
            this.txtGameMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGameMessages.Size = new System.Drawing.Size(1016, 131);
            this.txtGameMessages.TabIndex = 0;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(785, 429);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(85, 23);
            this.btnNewGame.TabIndex = 11;
            this.btnNewGame.Text = "&New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Visible = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // frmMainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.BackgroundImage = global::DurakGame.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1052, 628);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.grpPlayField);
            this.Controls.Add(this.grpPlayer1);
            this.Controls.Add(this.grpDeck);
            this.Controls.Add(this.grpMessages);
            this.Controls.Add(this.grpPlayer6);
            this.Controls.Add(this.grpPlayer5);
            this.Controls.Add(this.grpPlayer4);
            this.Controls.Add(this.grpPlayer3);
            this.Controls.Add(this.grpPlayer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1068, 515);
            this.Name = "frmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "G4 Durak";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainForm_FormClosing);
            this.Load += new System.EventHandler(this.PlayForm_Load);
            this.Shown += new System.EventHandler(this.frmMainForm_Shown);
            this.grpPlayer1.ResumeLayout(false);
            this.grpDeck.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTrump)).EndInit();
            this.grpMessages.ResumeLayout(false);
            this.grpMessages.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPlayer1;
        private System.Windows.Forms.GroupBox grpPlayer2;
        private System.Windows.Forms.GroupBox grpPlayer3;
        private System.Windows.Forms.GroupBox grpPlayer4;
        private System.Windows.Forms.GroupBox grpPlayer5;
        private System.Windows.Forms.GroupBox grpPlayer6;
        private System.Windows.Forms.GroupBox grpPlayField;
        private System.Windows.Forms.GroupBox grpDeck;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.PictureBox picTrump;
        private System.Windows.Forms.ToolTip ttpDescription;
        private System.Windows.Forms.Button btnContextual;
        private System.Windows.Forms.GroupBox grpMessages;
        private System.Windows.Forms.TextBox txtGameMessages;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Label lblAttackOrDefend;
	}
}

