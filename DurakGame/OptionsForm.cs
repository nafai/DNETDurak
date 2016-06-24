/***
 * Assignment:  Final Project: Durak
 * Names:       Group 4: Gregory Hammond, Jesse McDonald, Joel Roth
 * Course:      DNET 4200
 * Date:        17 April, 2015
 * 
 * File:        DurakGame\OptionsForm.cs
 * Description: Modal window that retrieves and stores user settings for deck
 *              size, players, card back design and log file location.
 ***/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using G4CardLib;
using System.Diagnostics;

namespace DurakGame
{
    public partial class frmOptions : Form
    {
        private FolderBrowserDialog frmFolderBrowser = new FolderBrowserDialog();
        private int selectedBack = Program.optionSelectedBack;

        public frmOptions()
        {
            InitializeComponent();
            
            // Set the player count combobox to the stored value
            switch (Program.optionGamePlayers)
            {
                case 2:
                    cmbAIPlayers.SelectedIndex = 0;
                    break;
                case 3:
                    cmbAIPlayers.SelectedIndex = 1;
                    break;
                case 4:
                    cmbAIPlayers.SelectedIndex = 2;
                    break;
                case 5:
                    cmbAIPlayers.SelectedIndex = 3;
                    break;
                case 6:
                    cmbAIPlayers.SelectedIndex = 4;
                    break;
            }
            
            // Set the deck size combobox
            switch (Program.optionGameDeckSize)
            {
                case DeckSize.Durak20Deck:
                    cmbDeckSize.SelectedIndex = 0;
                    break;
                case DeckSize.Durak36Deck:
                    cmbDeckSize.SelectedIndex = 1;
                    break;
                case DeckSize.RegularDeck:
                    cmbDeckSize.SelectedIndex = 2;
                    break;
            }

            // Set the card background style
            switch (Program.optionSelectedBack)
            {
                case 1:
                    BorderBox(pbCardBack1);
                    break;
                case 2:
                    BorderBox(pbCardBack2);
                    break;
                case 3:
                    BorderBox(pbCardBack3);
                    break;
                case 4:
                    BorderBox(pbCardBack4);
                    break;
                default:
                    BorderBox(pbCardBack1);
                    break;
            }

            // Set the log path
            if (System.IO.Directory.Exists(Properties.Settings.Default.LogPath))
                Program.optionLogPath = Properties.Settings.Default.LogPath;

            txtDirectory.Text = Program.optionLogPath;

        }

        Game myGame = new Game();
        frmMainForm myForm = new frmMainForm();

        public void setGameAndForm(Game gameInstance,frmMainForm formInstance) {
            myGame = gameInstance;
            myForm = formInstance;
        }

        #region Events

        public int numberOfPlayers; // boolean which sets the number of players that the user is going to play with

        /// <summary>
        /// Event:  Click Button
        /// When the user clicks the exit button, the form is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Log.Write("Options exited and NOT saved. Game options:\n\nPlayers: " + Program.optionGamePlayers.ToString() + "\nDeck size: " + Program.optionGameDeckSize.ToString() + "\nBackground selection: " + Program.optionSelectedBack.ToString() + "\nLog file location: " + Program.optionLogPath);

            // Close form and do NOT save changes
            this.Close();
        }

        /// <summary>
        /// Event: Click Button
        /// Saves option settings and starts a new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            // Close form and DO save changes

            // Set deck size according to listbox option
            switch (cmbDeckSize.SelectedIndex)
            {
                case 0:
                    Program.optionGameDeckSize = DeckSize.Durak20Deck;
                    break;
                case 1:
                    Program.optionGameDeckSize = DeckSize.Durak36Deck;
                    break;
                case 2:
                    Program.optionGameDeckSize = DeckSize.RegularDeck;
                    break;
            }

            // Setting the number of players, need at one human and on AI player, can have up to 6 players
            switch (cmbAIPlayers.SelectedIndex)
            {
                case 0:
                    Program.optionGamePlayers = 2;
                    break;
                case 1:
                    Program.optionGamePlayers = 3;
                    break;
                case 2:
                    Program.optionGamePlayers = 4;
                    break;
                case 3:
                    Program.optionGamePlayers = 5;
                    break;
                case 4:
                    Program.optionGamePlayers = 6;
                    break;
            }
            
            // Set background card
            Program.optionSelectedBack = selectedBack;
            // Also need to pass this to PictureCard's static variable
            PictureCard.backgroundSelection = Program.optionSelectedBack;

            Program.noHumanPlayer = chkNoHuman.Checked;

            // Validate log path
            if (System.IO.Directory.Exists(txtDirectory.Text))
                Program.optionLogPath = txtDirectory.Text;

            Log.Write("Options saved. Game options:\n\nPlayers: " + Program.optionGamePlayers.ToString() + "\nDeck size: " + Program.optionGameDeckSize.ToString() + "\nBackground selection: " + Program.optionSelectedBack.ToString() + "\nLog file location: " + Program.optionLogPath);
            Program.startAgain = true;
            Program.mainFormInstance.Close();

        }

        #endregion


        private void frmOptions_Load(object sender, EventArgs e)
        {
            txtDirectory.Text = Program.optionLogPath;
            switch (selectedBack)
            {
                case 1:
                    pbCardBack1_Click(sender, e);
                    break;
                case 2:
                    pbCardBack2_Click(sender, e);
                    break;
                case 3:
                    pbCardBack3_Click(sender, e);
                    break;
                case 4:
                    pbCardBack4_Click(sender, e);
                    break;
                default:
                    pbCardBack1_Click(sender,e);
                    break;
            }

        }

        private void BorderBox(PictureBox pbSelected)
        {
            pbCardBack1.BorderStyle = BorderStyle.None;
            pbCardBack2.BorderStyle = BorderStyle.None;
            pbCardBack3.BorderStyle = BorderStyle.None;
            pbCardBack4.BorderStyle = BorderStyle.None;
            pbSelected.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pbCardBack1_Click(object sender, EventArgs e)
        {
            BorderBox(pbCardBack1);
            selectedBack = 1;
        }

        private void pbCardBack2_Click(object sender, EventArgs e)
        {
            BorderBox(pbCardBack2);
            selectedBack = 2;
        }

        private void pbCardBack3_Click(object sender, EventArgs e)
        {
            BorderBox(pbCardBack3);
            selectedBack = 3;
        }

        private void pbCardBack4_Click(object sender, EventArgs e)
        {
            BorderBox(pbCardBack4);
            selectedBack = 4;
        }

        private void btnDirectoryPicker_Click(object sender, EventArgs e)
        {
            frmFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer;
            frmFolderBrowser.SelectedPath = txtDirectory.Text;
            DialogResult locationResult = frmFolderBrowser.ShowDialog();
            if (locationResult.Equals(DialogResult.OK))
            {
                txtDirectory.Text = frmFolderBrowser.SelectedPath;
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(txtDirectory.Text))
                Process.Start(@txtDirectory.Text);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Create a new instance of the help form
            frmHelp formHelp = new frmHelp();

            // Display the help form
            formHelp.ShowDialog();
        }

    }
}
