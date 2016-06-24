/***
 * Assignment:  Final Project: Durak
 * Names:       Group 4: Gregory Hammond, Jesse McDonald, Joel Roth
 * Course:      DNET 4200
 * Date:        17 April, 2015
 * 
 * File:        DurakGame\GameHumanMoves.cs
 * Description: Contains human player functions and events for Durak.
 ***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G4CardLib;
using System.Collections.ObjectModel;

namespace DurakGame
{
    public partial class Game
    {
        void playerCardClicked(object sender, CardEventArgs e)
        {
            // Warning: This event handler may totally not be thread safe.

            if (isHumanTurn)
            {
                // Debug message
                Log.Write("You selected " + e.CardSelected.ToString() + ".", false);

                // Store selected card from eventargs
                selectedCard = e.CardSelected;
                
                // Resume loop
                OnResumeLoop(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Continues game loop.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnResumeLoop(EventArgs e)
        {
            if (ResumeLoop != null)
            {
                isHumanTurn = false;
                btnContextual.Enabled = false;
                btnContextual.Text = "...";
                btnContextual.Click -= btnContextual_PassOrTake;

                ResumeLoop(this, e);
            }
        }

        private void btnContextual_PassOrTake(object sender, EventArgs e)
        {
            if (isHumanTurn)
            {
                if (attackingPlayer.IsHuman)
                {
                    // Pass on continued attack
                    humanWantsToTakeOrPass = true;
                    Log.Write("Human wants to pass", false);
                }
                else if (defendingPlayer.IsHuman)
                {
                    // Take on defend
                    humanWantsToTakeOrPass = true;
                    Log.Write("Human wants to take", false);
                }
                else
                {
                    // We shouldn't be able to get here
                    throw new NotImplementedException();
                }

                // Resume game loop
                OnResumeLoop(EventArgs.Empty);
            }
        }

    }
}
