/***
 * Assignment:  Final Project: Durak
 * Names:       Group 4: Gregory Hammond, Jesse McDonald, Joel Roth
 * Course:      DNET 4200
 * Date:        17 April, 2015
 * 
 * File:        DurakGame\MainForm.cs
 * Description: The main form of the Durak game. Contains whole game board, 
 *              including the play field, spaces for six players (one human and
 *              5 AI) and deck space.
 ***/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using G4CardLib;

namespace DurakGame
{
    public partial class frmMainForm : Form
    {
        public Game game = new Game();
        private bool firstTimeLoad = false;

        public frmMainForm()
        {
            InitializeComponent();
        }

        public frmMainForm(bool isFirstTimeLoad)
        {
            // Executed from options screen on program launch only
            firstTimeLoad = isFirstTimeLoad;
            InitializeComponent();
        }

        #region Events

        /// <summary>
        /// Logs that the game has ended when the user closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        { 
            Log.Write("Main form closed.", false); 
        }

        /// <summary>
        /// Event: Click button
        /// Displays a form with instructions for the user to reference.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Create a new instance of the help form
            frmHelp formHelp = new frmHelp();

            // Display the help form
            formHelp.ShowDialog();
        }

        /// <summary>
        /// EVENT:  Load (frm)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayForm_Load(object sender, EventArgs e)
        {
            // Execute options form on first time load
            if (firstTimeLoad)
                btnOptions_Click(this, EventArgs.Empty);

            // Note: When user first hits "new game" on the options form displayed on first time load, it will always finish setting up a new game here and then re-open the main form.

            // Set up new game object
            game = new Game(Program.optionGamePlayers);

            // Set up trump image (invisible until deck is drawn)
            game.pbTrumpImage = picTrump;
            picTrump.Visible = false;

            game.startGame();
            initFormControls(Program.optionGamePlayers);

            // Bug? Sometimes this form doesn't show at the front.
            this.Activate();

            Log.Write("Main form loaded.", false);
            
            // Control structure continues in Shown event
        }

        #endregion

        #region Functions

        /// <summary>
        /// The main loop of the game. Moves the game forward.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainLoop(object sender, EventArgs e)
        {
            // Show game log if player is the first to act in a particular game
            txtGameMessages.Text = Game.userMessageLog;
            lblAttackOrDefend.Text = "";

            // Loop through until it's the human player's turn.
            while (game.isHumanTurn == false && game.gameStarted)
            {
                // Run through GameActionOrder selection
                game.Go();

                // Set the main form textbox to the most log message and scroll to the bottom.
                txtGameMessages.Text = Game.userMessageLog;
                txtGameMessages.SelectionStart = txtGameMessages.Text.Length;
                txtGameMessages.ScrollToCaret();
            }

            // Check to see if the game is still going on.
            if (game.gameStarted == false)
            {
                MessageBox.Show("Game over!\r\n\r\n"+game.endOfGameMessage, "Game Over");
                btnNewGame.Visible = true;
            }
            else
            {
                // Set player 1 label if it's attacking/defending.
                if (game.attackingPlayer.IsHuman)
                    lblAttackOrDefend.Text = "Attacking";
                else if (game.defendingPlayer.IsHuman)
                    lblAttackOrDefend.Text = "Defending";
                else
                    lblAttackOrDefend.Text = "";

                Log.Write("Broke out of game loop. Waiting for user action.", false);
            }
        }

        /// <summary>
        /// Initializes the controls on form based on number of players set by 
        /// Options form.
        /// </summary>
        /// <param name="numberOfPlayers"></param>
        public void initFormControls(int numberOfPlayers)
        {
            // Check for minimum players (can't have a solo player)
            if (numberOfPlayers < 2)
                throw new Exception("Must have at least two players in the game");
            
            // Assign deck to deck groupbox
            grpDeck.Controls.Add(game.gameDeckPlayer.playerPanel);
            
            // Assign table to playfield groupbox
            grpPlayField.Controls.Add(game.gameTablePlayer.playerPanel);

            // Add player 1 and 2 controls to their groupbox
            grpPlayer1.Controls.Add(game.players[0].playerPanel); // Human
            grpPlayer2.Controls.Add(game.players[1].playerPanel); // AI

            // Add any other players that have been enabled
            if (numberOfPlayers >= 3)
                grpPlayer3.Controls.Add(game.players[2].playerPanel);
            if (numberOfPlayers >= 4)
                grpPlayer4.Controls.Add(game.players[3].playerPanel);
            if (numberOfPlayers >= 5)
                grpPlayer5.Controls.Add(game.players[4].playerPanel);
            if (numberOfPlayers == 6)
                grpPlayer6.Controls.Add(game.players[5].playerPanel);
            if (numberOfPlayers > 6)
                throw new Exception("This game cannot support more than six players.");

            // Set trump image to whatever was selected from the trump card
            if (Card.trump == Suit.Black || Card.trump == Suit.Clubs)
                picTrump.Image = (Image)Properties.Resources.club;
            else if (Card.trump == Suit.Spades)
                picTrump.Image = (Image)Properties.Resources.spade;
            else if (Card.trump == Suit.Red || Card.trump == Suit.Hearts)
                picTrump.Image = (Image)Properties.Resources.heart;
            else if (Card.trump == Suit.Diamonds)
                picTrump.Image = (Image)Properties.Resources.diamond;

            // Set the game's contextual (pass/take) button to the one on the form.
            game.btnContextual = btnContextual;

            // For when the game wants to resume the game loop
            game.ResumeLoop += mainLoop;
        }

        #endregion

        /// <summary>
        /// Occurs after form has loaded, after it has been displayed the first time.
        /// </summary>
        private void frmMainForm_Shown(object sender, EventArgs e)
        {
            // Call the main loop the first time
            mainLoop(sender, e);
        }

        /// <summary>
        /// Event:  Click Button
        /// Display the options form when the user click the options button.
        /// </summary>
        private void btnOptions_Click(object sender, EventArgs e)
        {
            // Create an instance of the options form
            frmOptions formOptions = new frmOptions();

            // Display that instance as a dialog window
            formOptions.ShowDialog();

            // Dispose of options form so it can load settings again next time it's opened
            formOptions.Dispose();
        }

        /// <summary>
        /// New game button is only enabled after a game has ended. Reopen this
        /// form without changing the global settings.
        /// </summary>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            // Start game over with same settings/players.
            Program.startAgain = true;
            this.Close();
        }

        // Enable double buffering at form level
        // Code from http://www.angryhacker.com/blog/archive/2010/07/21/how-to-get-rid-of-flicker-on-windows-forms-applications.aspx
        protected override CreateParams CreateParams
        {
            get
            {
                // Activate double buffering at the form level.  All child controls will be double buffered as well.
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return cp;
            }
        } 


    }
}
