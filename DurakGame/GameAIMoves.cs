/***
 * Assignment:  Final Project: Durak
 * Names:       Group 4: Gregory Hammond, Jesse McDonald, Joel Roth
 * Course:      DNET 4200
 * Date:        17 April, 2015
 * 
 * File:        DurakGame\GameAIMoves.cs
 * Description: Contains AI logic functions for Durak.
 ***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G4CardLib;

namespace DurakGame
{
    public partial class Game
    {
        /// <summary>
        /// This function finds a suitable card to defend against an attacking card with. It'll look for a card of
        /// the same suit, the lowest one in that player's hand that will beat that card. If the deck is empty, it
        /// will look through its trump cards after its non-trump cards.
        /// </summary>
        /// <param name="attackingCard">Card that we're choosing a defense card versus</param>
        /// <param name="aiDeck">Deck of cards we can look through</param>
        /// <returns>PictureCard if card found, null PictureCard otherwise.</returns>
        PictureCard getAIDefenseCardFromHand(PictureCard attackingCard, Deck aiDeck)
        {
            PictureCard bestCardSoFar = null;

            foreach (PictureCard thisCard in aiDeck)
            {
                if ((thisCard.Suit == attackingCard.Suit || (gameDeckEmpty && thisCard.Suit == Card.trump)) && thisCard.ToCard() > attackingCard.ToCard())
                {
                    if (bestCardSoFar == null || (thisCard.ToCard() < bestCardSoFar.ToCard()))
                        bestCardSoFar = thisCard;
                    else if (thisCard.ToCard() < bestCardSoFar.ToCard())
                        bestCardSoFar = thisCard;
                }
            }
            
            return bestCardSoFar;
        }

        PictureCard getAIAttackCardFromHand(Deck aiDeck)
        {
            PictureCard bestCardSoFar = null;
            
            foreach (PictureCard thisCard in aiDeck)
            {
                // Find lowest numeric value non-trump card (pretend aces are jokers so they're higher than kings)
                if (bestCardSoFar == null || thisCard.Suit != Card.trump && (thisCard.Rank == Rank.Ace ? Rank.Joker : thisCard.Rank) < (bestCardSoFar.Rank == Rank.Ace ? Rank.Joker : bestCardSoFar.Rank))
                    bestCardSoFar = thisCard;
            }

            if (bestCardSoFar == null)
            {
                // Find the lowest numeric value trump card
                foreach (PictureCard thisCard in aiDeck)
                {
                    if (bestCardSoFar == null || thisCard.ToCard() < bestCardSoFar.ToCard())
                        bestCardSoFar = thisCard;
                }
            }
            return bestCardSoFar;
        }
        
        PictureCard getAIContinuedAttackCardFromHand(Deck aiDeck)
        {
            PictureCard bestCardSoFar = null;

            foreach (PictureCard thisCard in aiDeck)
            {
                // Find lowest numeric value non-trump card
                if (bestCardSoFar == null || thisCard.Suit != Card.trump && (thisCard.Rank == Rank.Ace ? Rank.Joker : thisCard.Rank) < (bestCardSoFar.Rank == Rank.Ace ? Rank.Joker : bestCardSoFar.Rank))
                    if (isValidCardForContinuedAttack(thisCard))
                        bestCardSoFar = thisCard;
            }

            if (bestCardSoFar == null && gameDeckEmpty)
            {
                // Find the lowest numeric value trump card
                foreach (PictureCard thisCard in aiDeck)
                {
                    if (bestCardSoFar == null || thisCard.ToCard() < bestCardSoFar.ToCard())
                        if (isValidCardForContinuedAttack(thisCard))
                            bestCardSoFar = thisCard;
                }
            }
            return bestCardSoFar;
        }
    }
}
