/***
 * Assignment:  Final Project: Durak
 * Names:       Group 4: Gregory Hammond, Jesse McDonald, Joel Roth
 * Course:      DNET 4200
 * Date:        17 April, 2015
 * 
 * File:     	G4CardLib\Deck.cs
 * Description: A class for creating decks of card type objects. Uses 
 *              Collection<T> builtins as well as deck functions, such as
 *              Shuffle(), AddNewDeck() and other functions used on all cards
 *              contained within.
 ***/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace G4CardLib
{
    public class Deck : Collection<PictureCard>
    {
        /// <summary>
        /// Shuffles the deck of cards.
        /// </summary>
        public void Shuffle()
        {
            Deck newDeck = new Deck();
            Random rnd = new Random();

            while (this.Count() > 0)
            {
                newDeck.Add(this[rnd.Next(this.Count())]);
                this.Remove(newDeck.Last());
            }

            newDeck.ToList().ForEach(Add);
        }

        public void Sort() 
        {
            ((List<PictureCard>)Items).Sort();
            foreach(PictureCard thisCard in this)
            {
                thisCard.cardNumber = this.IndexOf(thisCard);
            }
            
        }


        /// <summary>
        /// Add a new deck.
        /// </summary>
        /// <param name="deckSizeSelection">DeckSize enum value for which cards we're adding to the deck</param>
        public void AddNewDeck(DeckSize deckSizeSelection)
        {
            //Declarations: 
            int count = 0;                                                                                                      //The number of cards that have been proccessed.

            //Add the cards:
            for (int suitVal = 0; suitVal < 4; suitVal++)                                                                       //For each suit:
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)                                                                  //For each rank:
                {
                    //Declarations:
                    Card tempCard = new Card();                                                                                 //Create a card

                    //Choose a deck size:
                    if (deckSizeSelection == DeckSize.Durak20Deck)                                                              //If a 20 card deck has been selected:
                    {
                        if (rankVal > 9 || rankVal < 2)                                                                         //If the card's rank is greater than nine:
                        {
                            Add(new PictureCard((Suit)suitVal, (Rank)rankVal, Face.Down));                                      // add the card
                            count++;                                                                                            //Increment the counter
                        }
                    }
                    else if (deckSizeSelection == DeckSize.Durak36Deck)                                                         //Otherwise, if a 36 card durak deck type was chosen:
                    {
                        if (rankVal < 2 || rankVal > 5)                                                                         //If the rank is valid:
                        {
                            Add(new PictureCard((Suit)suitVal, (Rank)rankVal, Face.Down));                                      // add the card
                            count++;                                                                                            //Increment the counter
                        }
                    }
                    else if (deckSizeSelection == DeckSize.RegularDeck || deckSizeSelection == DeckSize.RegularDeckWithJokers)  //Otherwise, if a full deck was choosen:
                    {
                        Add(new PictureCard((Suit)suitVal, (Rank)rankVal, Face.Down));                                          // add the card
                        count++;                                                                                                //Increment the counter
                    }
                }
            }

            //Add jokers if they are to be inclded:
            if (deckSizeSelection == DeckSize.RegularDeckWithJokers)                                                            //If the deck is to have jokers:
            {
                //Add the jokers:
                Add(new PictureCard(Suit.Black, Rank.Joker, Face.Down));
                Add(new PictureCard(Suit.Red, Rank.Joker, Face.Down));
            }
        }
		
		/// <summary>
        /// Flips all the cards in the deck (face up to face down to face up).
        /// </summary>

      	public void FlipAllCards()
        {
            foreach (PictureCard thisCard in this)
            {
                thisCard.Flip();
            }

        }

        public void RedisplayCards()
        {
            // Used when cards are added/removed, resets location of all cards
            // Currently dead code
            foreach (PictureCard thisCard in this)
            {
                //TODO
                thisCard.UpdateImage();
            }
        }

        public PictureCard this[PictureCard targetCard]
        {
            // Access the deck by card type (ignores face, finds only the first instance of a card)
            get
            {
                
                int targetHashCode = targetCard.GetHashCode();
                foreach (PictureCard eachCard in this)
                {
                    if (eachCard.GetHashCode() == targetHashCode)
                    {
                        //System.Diagnostics.Debug.WriteLine("Matched card " + targetCard.ToString() + " to card " + eachCard.ToString());
                        return eachCard;
                    }
                }
                throw new KeyNotFoundException("Card not found: "+targetCard.ToString());
            }
            // Replace an existing card with one of the same type (but may have different internal properties) at the same index
            set
            {
                try
                {
                    int oldCardIndex = this.IndexOf(this[targetCard]);
                    this.RemoveAt(oldCardIndex);
                    this.Insert(oldCardIndex, value);
                }
                catch (KeyNotFoundException ex)
                {
                    Debug.WriteLine("Card not found in deck: " + ex.Message);
                }
            }
        }
    }
}
