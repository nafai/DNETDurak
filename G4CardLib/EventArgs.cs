/***
 * Assignment:  Final Project: Durak
 * Names:       Group 4: Gregory Hammond, Jesse McDonald, Joel Roth
 * Course:      DNET 4200
 * Date:        17 April, 2015
 * 
 * File:     	G4CardLib\EventArgs.cs
 * Description: An event handler argument that is able to contain a PictureCard object.
 ***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4CardLib
{
    public class CardEventArgs : EventArgs
    {
        // Internal variable
        private PictureCard myCard;
        // Readonly getter
        public PictureCard CardSelected
        {
            get
            {
                return myCard;
            }
        }
        // Constructor
        public CardEventArgs(PictureCard selectedCard)
        {
            myCard = selectedCard;
        }
    }
}
