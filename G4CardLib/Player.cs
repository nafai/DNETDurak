/***
 * Assignment:  Final Project: Durak
 * Names:       Group 4: Gregory Hammond, Jesse McDonald, Joel Roth
 * Course:      DNET 4200
 * Date:        17 April, 2015
 * 
 * File:        G4CardLib\Player.cs
 * Description: Contains generic player functions. Players contain a deck, a
 *              panel, a player type, name, etc.
 ***/
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace G4CardLib
{
    public class Player
    {
        #region Variable Declarations

        // Class variables
        // Players store a deck of PictureCards and a panel
        private Deck playerDeck = new Deck();
        public CardPanel playerPanel = new CardPanel();

        private string playerName = "";
        private PlayerType thisPlayerType;
        // Used to determine fool
        public int originalIndex = -1;
        // Used for an all-AI game
        public static bool ALL_CARDS_FACE_UP = false;
        // For a Deck, used when the last card has been removed
        public event EventHandler<EventArgs> LastCardRemoved;


        /// <summary>
        /// The name of the player.
        /// </summary>
        public String Name
        {
            get { return playerName; }
            set { playerName = value; }
        }

        /// <summary>
        /// Readonly boolean for if a player type is AI
        /// </summary>
        public bool IsAI
        {
            get
            {
                if (thisPlayerType == PlayerType.AI)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Readonly boolean for if a player type is Human
        /// </summary>
        public bool IsHuman
        {
            get
            {
                if (thisPlayerType == PlayerType.Human)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Read-write PlayerType enum property
        /// </summary>
        public PlayerType PlayerType
        {
            get
            {
                return thisPlayerType;
            }
            set
            {
                thisPlayerType = value;
            }
        }

        #endregion

        #region Functions

        // Refresh the card's number (position in playerDeck) and owning player
        public void UpdateCard(PictureCard thisCard)
        {
            thisCard.cardNumber = playerDeck.IndexOf(thisCard);
            thisCard.myPlayer = this;
        }

        /// <summary>
        /// Takes a card and adds it to the deck.
        /// </summary>
        /// <param name="thisCard">A card</param>
        public void Add(PictureCard thisCard)
        {
            // Subscribe this card to this class's event handler
            thisCard.CardSelected += ThisPlayerCardSelected;
            // Add this card to the deck
            playerDeck.Add(thisCard);
            UpdateCard(thisCard);
            // Add the card's image to the playerPanel controls
            playerPanel.Controls.Add(playerDeck.Last());
        }

        /// <summary>
        /// Deals a card to a player's hand.
        /// </summary>
        /// <param name="thisCard"></param>
        /// <param name="otherPlayer"></param>
        public void GiveToPlayer(PictureCard thisCard, Player otherPlayer)
        {
            // Determine if card will be face up or face down after passing
            if (otherPlayer.thisPlayerType == PlayerType.Human)
            {
                thisCard.Hoverable = true;
                thisCard.Face = Face.Up;
            }
            else
            {
                thisCard.Hoverable = false;
                thisCard.Face = Face.Down;
            }

            if (ALL_CARDS_FACE_UP)
                thisCard.Face = Face.Up;

            // This player...
            Remove(thisCard);
            if (this.PlayerType != PlayerType.None)
            {
                playerDeck.Sort();
                UpdatePlayerPanelOrder();
                playerPanel.UpdateControlOrder();
                // Removal of a card doesn't need to update z order
            }

            // Other player...
            otherPlayer.Add(thisCard);
            if (otherPlayer.thisPlayerType != PlayerType.None)
            {
                otherPlayer.Deck.Sort();
                otherPlayer.UpdatePlayerPanelOrder();
                otherPlayer.playerPanel.UpdateControlOrder();
                otherPlayer.playerPanel.UpdateControlZOrder();
            }
        }
        
        /// <summary>
        /// Remove a card from the player's hand.
        /// </summary>
        /// <param name="thisCard"></param>
        public void Remove(PictureCard thisCard)
        {
            // Find card in deck
            if (playerDeck.Contains(thisCard))                                                                      
            {
                //If the card to be removed exists in the player's hand:

                // Unsubscribe the event handler
                thisCard.CardSelected -= ThisPlayerCardSelected;
                // Remove card (by card type)
                playerDeck.Remove(thisCard);
                // Remove card from control group
                playerPanel.Controls.Remove(thisCard);
                // Update the rest of the cards
                UpdatePlayerPanelOrder();
                // Check if this was the last card in the player's hand and 
                if (playerDeck.Count() == 0)
                    if (LastCardRemoved != null)
                        LastCardRemoved(this, new EventArgs());
            }
            else
            {
                throw new Exception("Card not found");
            }
        }

        /// <summary>
        /// Readonly, returns a player's Deck
        /// </summary>
        public Deck Deck
        {
            get
            {
                return playerDeck;
            }
        }

        /// <summary>
        /// Updates card numbers in a player's deck
        /// </summary>
        public void UpdatePlayerPanelOrder()
        {
            foreach (PictureCard thisCard in playerDeck)
            {
                thisCard.cardNumber = playerDeck.IndexOf(thisCard);
            }
        }

        /// <summary>
        /// Sort a player's deck by suit, then rank (trump to right)
        /// </summary>
        public void sortHand()
        {
            playerDeck.Sort();
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default player constructor.
        /// </summary>
        public Player() 
        {
        }

        /// <summary>
        /// Parameterized player constructor for players with a name.
        /// </summary>
        /// <param name="newName"></param>
        public Player(String newName)
        {
            playerName = newName;
        }

        /// <summary>
        /// Parameterized player constructor for players with a name and type.
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="newPlayerType"></param>
        public Player(String newName, PlayerType newPlayerType)
        {
            playerName = newName;
            thisPlayerType = newPlayerType;
        }

        #endregion

        #region Events

        /// <summary>
        /// Output a message when the player's card is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThisPlayerCardSelected(object sender, CardEventArgs e)
        { 
            //Debug.WriteLine("Card selected event handled by Player Class for card: " + e.CardSelected.ToString()); 
        }

        #endregion
    }
}
