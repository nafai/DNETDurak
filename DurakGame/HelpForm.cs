/***
 * Assignment:  Final Project: Durak
 * Names:       Group 4: Gregory Hammond, Jesse McDonald, Joel Roth
 * Course:      DNET 4200
 * Date:        17 April, 2015
 * 
 * File:        DurakGame\HelpForm.cs
 * Description: The Help form is a modal window with tabs that draw content
 *              from HTML pages (contained in the resource manager).
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
using System.IO;

namespace DurakGame
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
        }

        #region Events

        /// <summary>
        /// Event Load Form
        /// Initializes the web browser object when the form loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHelp_Load(object sender, EventArgs e)
        {
            // Fill in About and Tutorial tabs with HTML content
            wbbAbout.DocumentText = Properties.Resources.header + Properties.Resources.AboutHTML + Properties.Resources.footer;
            wbbTutorial.DocumentText = Properties.Resources.header + Properties.Resources.TutorialHTML + Properties.Resources.footer;
            webSetup.DocumentText = Properties.Resources.header + Properties.Resources.SetupHTML + Properties.Resources.footer;
            webObjectives.DocumentText = Properties.Resources.header + Properties.Resources.ObjectivesHTML + Properties.Resources.footer;
            webGameplay.DocumentText = Properties.Resources.header + Properties.Resources.GameplayHTML + Properties.Resources.footer;
        }

        #endregion


    }
}
