/***
 * Assignment:  Final Project: Durak
 * Names:       Group 4: Gregory Hammond, Jesse McDonald, Joel Roth
 * Course:      DNET 4200
 * Date:        17 April, 2015
 * 
 * File:        DurakGame\Program.cs
 * Description: Entry point for the Durak game. Stores and saves global 
 *              settings and shared instance variables for the current game.
 *              
 *              Turn SAVE_AND_LOAD_SETTINGS bool to false to disable saving
 *              and loading of game options on startup.
 ***/
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using G4CardLib;

namespace DurakGame
{
    static class Program
    {
        public static bool startAgain = false;
        private const bool SHOW_OPTIONS_ON_FIRST_START = true;
        private const bool SAVE_AND_LOAD_USER_SETTINGS = true;

        // Options to be set by options form. Defaults here.
        public static int optionGamePlayers = 2;
        public static DeckSize optionGameDeckSize = DeckSize.Durak36Deck;
        public static int optionSelectedBack = 1;
        public static string optionLogPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static bool noHumanPlayer = false;
        public static int lastFool = -1;
        internal static frmMainForm mainFormInstance;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (SAVE_AND_LOAD_USER_SETTINGS)
            {
                // Load settings
                if (System.IO.Directory.Exists(DurakGame.Properties.Settings.Default.LogPath))
                    optionLogPath = DurakGame.Properties.Settings.Default.LogPath;
                optionGamePlayers = DurakGame.Properties.Settings.Default.GamePlayers;
                optionGameDeckSize = DurakGame.Properties.Settings.Default.GameDeckSize;
                optionSelectedBack = DurakGame.Properties.Settings.Default.SelectedCardBack;
            }
            else
            {
                // Use defaults above
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainFormInstance = new frmMainForm(SHOW_OPTIONS_ON_FIRST_START);
            Application.Run(mainFormInstance);
            while (startAgain)
            {
                mainFormInstance = new frmMainForm();
                startAgain = false;
                Application.Run(mainFormInstance);
            }

            // Save settings
            DurakGame.Properties.Settings.Default.LogPath = optionLogPath;
            DurakGame.Properties.Settings.Default.GamePlayers = optionGamePlayers;
            DurakGame.Properties.Settings.Default.GameDeckSize = optionGameDeckSize;
            DurakGame.Properties.Settings.Default.SelectedCardBack = optionSelectedBack;
            if (SAVE_AND_LOAD_USER_SETTINGS) 
                DurakGame.Properties.Settings.Default.Save();
        }
    }
}
