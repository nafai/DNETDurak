namespace DurakGame
{
    partial class frmHelp
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.wbbAbout = new System.Windows.Forms.WebBrowser();
            this.tabVideoTutorial = new System.Windows.Forms.TabPage();
            this.wbbTutorial = new System.Windows.Forms.WebBrowser();
            this.tabGameplay = new System.Windows.Forms.TabPage();
            this.tabGoal = new System.Windows.Forms.TabPage();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.webSetup = new System.Windows.Forms.WebBrowser();
            this.tbcInstruction = new System.Windows.Forms.TabControl();
            this.webObjectives = new System.Windows.Forms.WebBrowser();
            this.webGameplay = new System.Windows.Forms.WebBrowser();
            this.tabAbout.SuspendLayout();
            this.tabVideoTutorial.SuspendLayout();
            this.tabGameplay.SuspendLayout();
            this.tabGoal.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.tbcInstruction.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Courier New", 40F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(530, 69);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Playing Durak";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabAbout
            // 
            this.tabAbout.BackColor = System.Drawing.Color.Black;
            this.tabAbout.Controls.Add(this.wbbAbout);
            this.tabAbout.ForeColor = System.Drawing.Color.White;
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Margin = new System.Windows.Forms.Padding(2);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(2);
            this.tabAbout.Size = new System.Drawing.Size(522, 406);
            this.tabAbout.TabIndex = 4;
            this.tabAbout.Text = "About";
            // 
            // wbbAbout
            // 
            this.wbbAbout.Location = new System.Drawing.Point(4, 5);
            this.wbbAbout.Margin = new System.Windows.Forms.Padding(2);
            this.wbbAbout.MinimumSize = new System.Drawing.Size(15, 16);
            this.wbbAbout.Name = "wbbAbout";
            this.wbbAbout.Size = new System.Drawing.Size(515, 399);
            this.wbbAbout.TabIndex = 5;
            // 
            // tabVideoTutorial
            // 
            this.tabVideoTutorial.BackColor = System.Drawing.Color.Black;
            this.tabVideoTutorial.Controls.Add(this.wbbTutorial);
            this.tabVideoTutorial.Location = new System.Drawing.Point(4, 22);
            this.tabVideoTutorial.Name = "tabVideoTutorial";
            this.tabVideoTutorial.Padding = new System.Windows.Forms.Padding(3);
            this.tabVideoTutorial.Size = new System.Drawing.Size(522, 406);
            this.tabVideoTutorial.TabIndex = 3;
            this.tabVideoTutorial.Text = "Tutorial";
            // 
            // wbbTutorial
            // 
            this.wbbTutorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbbTutorial.Location = new System.Drawing.Point(3, 3);
            this.wbbTutorial.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbbTutorial.Name = "wbbTutorial";
            this.wbbTutorial.Size = new System.Drawing.Size(516, 400);
            this.wbbTutorial.TabIndex = 0;
            // 
            // tabGameplay
            // 
            this.tabGameplay.BackColor = System.Drawing.Color.Black;
            this.tabGameplay.Controls.Add(this.webGameplay);
            this.tabGameplay.Location = new System.Drawing.Point(4, 22);
            this.tabGameplay.Name = "tabGameplay";
            this.tabGameplay.Padding = new System.Windows.Forms.Padding(3);
            this.tabGameplay.Size = new System.Drawing.Size(522, 406);
            this.tabGameplay.TabIndex = 2;
            this.tabGameplay.Text = "Gameplay";
            // 
            // tabGoal
            // 
            this.tabGoal.BackColor = System.Drawing.Color.Black;
            this.tabGoal.Controls.Add(this.webObjectives);
            this.tabGoal.Location = new System.Drawing.Point(4, 22);
            this.tabGoal.Name = "tabGoal";
            this.tabGoal.Padding = new System.Windows.Forms.Padding(3);
            this.tabGoal.Size = new System.Drawing.Size(522, 406);
            this.tabGoal.TabIndex = 1;
            this.tabGoal.Text = "Goal";
            // 
            // tabSetup
            // 
            this.tabSetup.AutoScroll = true;
            this.tabSetup.BackColor = System.Drawing.Color.Black;
            this.tabSetup.Controls.Add(this.webSetup);
            this.tabSetup.Location = new System.Drawing.Point(4, 22);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetup.Size = new System.Drawing.Size(522, 406);
            this.tabSetup.TabIndex = 0;
            this.tabSetup.Text = "Setup";
            // 
            // webSetup
            // 
            this.webSetup.Location = new System.Drawing.Point(4, 4);
            this.webSetup.Margin = new System.Windows.Forms.Padding(2);
            this.webSetup.MinimumSize = new System.Drawing.Size(15, 16);
            this.webSetup.Name = "webSetup";
            this.webSetup.Size = new System.Drawing.Size(515, 399);
            this.webSetup.TabIndex = 6;
            // 
            // tbcInstruction
            // 
            this.tbcInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcInstruction.Controls.Add(this.tabSetup);
            this.tbcInstruction.Controls.Add(this.tabGoal);
            this.tbcInstruction.Controls.Add(this.tabGameplay);
            this.tbcInstruction.Controls.Add(this.tabVideoTutorial);
            this.tbcInstruction.Controls.Add(this.tabAbout);
            this.tbcInstruction.Location = new System.Drawing.Point(12, 81);
            this.tbcInstruction.Name = "tbcInstruction";
            this.tbcInstruction.SelectedIndex = 0;
            this.tbcInstruction.Size = new System.Drawing.Size(530, 432);
            this.tbcInstruction.TabIndex = 8;
            // 
            // webObjectives
            // 
            this.webObjectives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webObjectives.Location = new System.Drawing.Point(3, 3);
            this.webObjectives.MinimumSize = new System.Drawing.Size(20, 20);
            this.webObjectives.Name = "webObjectives";
            this.webObjectives.Size = new System.Drawing.Size(516, 400);
            this.webObjectives.TabIndex = 0;
            // 
            // webGameplay
            // 
            this.webGameplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webGameplay.Location = new System.Drawing.Point(3, 3);
            this.webGameplay.MinimumSize = new System.Drawing.Size(20, 20);
            this.webGameplay.Name = "webGameplay";
            this.webGameplay.Size = new System.Drawing.Size(516, 400);
            this.webGameplay.TabIndex = 0;
            // 
            // frmHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(554, 525);
            this.Controls.Add(this.tbcInstruction);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmHelp";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Playing Durak";
            this.Load += new System.EventHandler(this.frmHelp_Load);
            this.tabAbout.ResumeLayout(false);
            this.tabVideoTutorial.ResumeLayout(false);
            this.tabGameplay.ResumeLayout(false);
            this.tabGoal.ResumeLayout(false);
            this.tabSetup.ResumeLayout(false);
            this.tbcInstruction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.WebBrowser wbbAbout;
        private System.Windows.Forms.TabPage tabVideoTutorial;
        private System.Windows.Forms.TabPage tabGameplay;
        private System.Windows.Forms.TabPage tabGoal;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.TabControl tbcInstruction;
        private System.Windows.Forms.WebBrowser wbbTutorial;
        private System.Windows.Forms.WebBrowser webSetup;
        private System.Windows.Forms.WebBrowser webObjectives;
        private System.Windows.Forms.WebBrowser webGameplay;
    }
}