/***
 * Assignment:  Final Project: Durak
 * Names:       Group 4: Gregory Hammond, Jesse McDonald, Joel Roth
 * Course:      DNET 4200
 * Date:        17 April, 2015
 * 
 * File:        DurakGame\Game.cs
 * Description: Common components of Game class.
 ***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using G4CardLib;
using System.Diagnostics;
using System.Windows.Forms;

namespace DurakGame
{
    public partial class Game
    {

        private int nextPlayer(int player)
        {
            return (player + 1) % (playersInGame.Count());
        }

        #region Functions

        /// <summary>
        /// Starting at the first player after the dealer, give PLAYER_HAND_SIZE to each player, one player at a time.
        /// If the last card has been dealt, show the card to everyone, prompt for confirmation, then hide it.
        /// </summary>
        private void dealPlayerHands()
        {
            // Hide trump image behind deck
            pbTrumpImage.Visible = false;

            int playerToDealTo;
            PictureCard dealtCard = new PictureCard();
            for (int i = 0; i < playersInGame.Count() * playerHandSize; i++)
            {
                try
                {
                    // Determine player index to deal the card to
                    playerToDealTo = (attacker + i) % playersInGame.Count();

                    // Deal the top card of the deck to the playerToDealTo. Hold the resulting card in dealtCard.
                    dealtCard = dealTopCardToPlayer(playersInGame[playerToDealTo]);

                    Log.Write("Dealing card " + dealtCard.ToString() + " to player " + playersInGame[playerToDealTo].Name, false);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    // Attempted to deal card from an empty deck
                    Debug.WriteLine(ex.ParamName.ToString());
                    // Exit the for loop
                    break;
                }
            }

            if (gameDeckPlayer.Deck.Count() == 0)
            {
                // We dealt the last of the deck
                // Display the final card, as it's the trump card.
                Log.Write("Last card dealt was " + dealtCard.ToString() + " (owned by " + dealtCard.myPlayer.Name + ")", false);
                if (!dealtCard.myPlayer.IsHuman && Program.noHumanPlayer == false)
                {
                    // Show the player the card
                    dealtCard.Flip();
                    MessageBox.Show(dealtCard.myPlayer.Name + " has the trump card: " + dealtCard.ToString(), "Last card drawn");
                    // Put the card back face down
                    dealtCard.Flip();
                }
                else
                {
                    // Human player doesn't need to confirm they have seen the last card.
                    MessageBox.Show((Program.noHumanPlayer?dealtCard.myPlayer.Name+" has":"You have")+ " the trump card: " + dealtCard.ToString(), "Last card drawn");
                }
            }

        }

        /// <summary>
        /// Fill a player's hand to playerHandSize cards as long as cards remain in the deck
        /// </summary>
        /// <param name="player">Player object to fill hand of</param>
        void topUpPlayerHand(Player player)
        {
            int cardCount = 0;
            while (player.Deck.Count() < playerHandSize && gameDeckPlayer.Deck.Count() > 0)
            {
                dealTopCardToPlayer(player);
                cardCount++;
            }
            if (cardCount > 0)
                Log.Write("Gave " + player.Name + " " + cardCount.ToString() + " card" + (cardCount==1?"":"s")+" from the deck.", true);
        }

        // 
        /// <summary>
        /// Call topUpPlayerHand for all players in the game in a specific order.
        /// Order: Attacker; any other players that played cards; defender last.
        /// </summary>
        void topUpPlayerHands()
        {
            // Top up the attacker
            topUpPlayerHand(attackingPlayer);

            // Top up everyone but the attacker and defender
            foreach (Player eachPlayer in playersInGame)
            {
                if (eachPlayer != attackingPlayer && eachPlayer != defendingPlayer)
                    topUpPlayerHand(eachPlayer);
            }

            // Top up the defender (always last)
            topUpPlayerHand(defendingPlayer);
        }

        /// <summary>
        /// Moves a card from a player to the playfield player
        /// </summary>
        /// <param name="card">Card to move to table/playfield</param>
        void moveCardToTable(PictureCard card)
        {
            Log.Write("Moved " + card.ToString() + " to the table.", false);

            Player cardPlayer = card.myPlayer;

            // Pass card from current player to table player
            cardPlayer.GiveToPlayer(card, gameTablePlayer);
            
            // Remove click events so you can't select it again
            card.CardSelected -= playerCardClicked;

            // Flip card to face-up
            card.Face = Face.Up;
        }

        /// <summary>
        /// Iterate through all cards on playfield and give it to the unfortunatePlayer (could be discard pile player)
        /// </summary>
        /// <param name="unfortunatePlayer"></param>
        void giveAllCardsOnTableToPlayer(Player unfortunatePlayer)
        {
            while (gameTablePlayer.Deck.Count() > 0)
            {
                // Select last card from table (faster visual updates)
                PictureCard thisCard = gameTablePlayer.Deck[gameTablePlayer.Deck.Count()-1];
                
                // Unrotate card
                thisCard.Rotated = false;
                
                // Humans get a click event on their new card
                if (unfortunatePlayer.IsHuman)
                    thisCard.CardSelected += playerCardClicked;

                // Pass the card to the appropriate player
                gameTablePlayer.GiveToPlayer(thisCard, unfortunatePlayer);

            }
        }

        /// <summary>
        /// Returns the first card in a player's hand.
        /// </summary>
        /// <param name="thisPlayer">Player object to retrieve card from</param>
        /// <returns>First card held by a player</returns>
        private PictureCard dealTopCardToPlayer(Player thisPlayer)
        {
            // Can't deal a card from an empty deck
            if (gameDeckPlayer.Deck.Count() == 0)
                throw new ArgumentOutOfRangeException("Error: Tried to deal card from empty deck!");

            // Select top card from the deck
            PictureCard selectedCard = gameDeckPlayer.Deck.Last();
            
            // Unrotate card
            if (selectedCard.Rotated)
            {
                // Fix the sideways trump card
                selectedCard.Rotate();
                selectedCard.Face = Face.Down;
            }

            // Humans get a face up card with a click event
            if (thisPlayer.IsHuman)
            {
                selectedCard.Face = Face.Up;
                selectedCard.CardSelected += playerCardClicked;
            }

            // Pass card to player
            gameDeckPlayer.GiveToPlayer(selectedCard, thisPlayer);

            // Return card that was passed
            return selectedCard;
        }

        /// <summary>
        /// Tests to see if a card can be used in a defense against an attacking card
        /// </summary>
        /// <param name="attackingCard">Card that's attacking</param>
        /// <param name="defendingCard">Card we're testing to see that can beat the attacking card</param>
        /// <returns></returns>
        private Boolean isValidDefendingMove(PictureCard attackingCard, PictureCard defendingCard)
        {
            // attackingCard is the card to beat (which is why we're not using defendingCard > attackingCard)
            return (Card)attackingCard.ToCard() < (Card)defendingCard.ToCard();
        }

        /// <summary>
        /// Checks to see if a card can be played in a continued attack
        /// </summary>
        /// <param name="thisCard">Card to be checked</param>
        /// <returns>If the card is valid or not</returns>
        private bool isValidCardForContinuedAttack(PictureCard thisCard)
        {
            foreach(PictureCard tableCard in gameTablePlayer.Deck)
            {
                if (thisCard.Rank == tableCard.Rank)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Readonly property for the defending player index
        /// </summary>
        private int defender
        {
            get
            {
                return nextPlayer(attacker);
            }
        }

        /// <summary>
        /// Readonly boolean for if the deck has 0 cards left
        /// </summary>
        private bool gameDeckEmpty
        {
            get
            {
                return gameDeckPlayer.Deck.Count() == 0;
            }
        }

        /// <summary>
        /// Readonly Player of the player that's currently attacking
        /// </summary>
        internal Player attackingPlayer
        {
            get
            {
                return playersInGame[attacker];
            }
        }

        /// <summary>
        /// Readonly Player of the player that's currently defending
        /// </summary>
        internal Player defendingPlayer
        {
            get
            {
                return playersInGame[defender];
            }
        }

        /// <summary>
        /// Set contextual button in main form to Pass
        /// </summary>
        private void setContextButtonToPass()
        {
            // To be used on a human player's continued attack
            btnContextual.Text = "Pass";
            btnContextual.Enabled = true;
            btnContextual.Click += btnContextual_PassOrTake;
            humanWantsToTakeOrPass = false;
        }

        /// <summary>
        /// Set contextual button in main form to Take
        /// </summary>
        private void setContextButtonToTake()
        {
            // To be used on a human player's continued attack
            btnContextual.Text = "Take";
            btnContextual.Enabled = true;
            btnContextual.Click += btnContextual_PassOrTake;
            humanWantsToTakeOrPass = false;
        }

        /// <summary>
        /// When the last card is removed from the deck, the trump suit is displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastCardRemovedFromDeckHandler(object sender, EventArgs e)
        {
            pbTrumpImage.Visible = true;
        }

        #endregion

        #region Functions: Accessors

        /// <summary>
        /// Gets the size of the delt hands of cards.
        /// </summary>
        /// <returns></returns>
        public int GetPlayerHandSize()
        { 
            return playerHandSize; 
        }

        /// <summary>
        /// Gets the number of players in the current instance of the game.
        /// </summary>
        /// <returns></returns>
        public int playerCount()
        { 
            return playersInGame.Count; 
        }

        /// <summary>
        /// Get the collection of players in the game.
        /// </summary>
        public Collection<Player> players
        { 
            get 
            { 
                return playersInGame; 
            } 
        }

        #endregion
    }
}
