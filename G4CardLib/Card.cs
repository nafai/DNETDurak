/***
 * Assignment:  Final Project: Durak
 * Names:       Group 4: Gregory Hammond, Jesse McDonald, Joel Roth
 * Course:      DNET 4200
 * Date:        17 April, 2015
 * 
 * File:        G4CardLib\Card.cs
 * Description: A non-visual representation of a French 52-card based card to 
 *              be used in a card game.
 ***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace G4CardLib
{
    public class Card : ICloneable
    {
        #region Class level variables/declarations

        // Suit, rank, face, rotation
        public Suit suit;
        public Rank rank;
        public Face face;
        private bool rotated = false;

        // Class wide flags
        public static Suit trump; //= Suit.Spades;
        public static bool useTrumps = false;
        public static bool isAceHigh = true;

        #endregion

        #region Constructors

        /// <summary>
        /// Default card constructor.
        /// </summary>
        public Card()
        {
        }

        /// <summary>
        /// Parameterized card constructor for cards with a suit and rank.
        /// </summary>
        /// <param name="newSuit"></param>
        /// <param name="newRank"></param>
        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;                                                 //Set the suit
            rank = newRank;                                                 //Set the rank
            face = Face.Down;                                               //Make the card face down
            fixJokers();
        }

        /// <summary>
        /// Parameterized card constructor for cards with a suit, rank, and a face (up or down)
        /// </summary>
        /// <param name="newSuit"></param>
        /// <param name="newRank"></param>
        /// <param name="newFace"></param>
        public Card(Suit newSuit, Rank newRank, Face newFace)
        {
            suit = newSuit;
            rank = newRank;
            face = newFace;                                                 //Set the faceing (face up/down)

            fixJokers();
        }

        #endregion

        #region Internal methods

        internal void fixJokers()
        {
            // A joker can't be spades/clubs/diamonds/hearts. A non-joker can't be red/black.
            // Reckless abuse of the ternary operator.
            if (rank == Rank.Joker)
                suit = (suit == Suit.Clubs || suit == Suit.Spades) ? Suit.Black : (suit == Suit.Diamonds || suit == Suit.Hearts) ? Suit.Red : suit;
            else
                suit = (suit == Suit.Red || suit == Suit.Black) ? Suit.Spades : suit;

        }


        #endregion

        #region Public methods

        // Flip a card face
        public void Flip()
        {
            if (this.face == Face.Down)
                this.face = Face.Up;
            else
                this.face = Face.Down;
        }

        // Rotate a card's visual element
        public void Rotate()
        {
            Rotated = !Rotated;
        }
        
        // Override ToString() with a text representation of a card
        public override string ToString()
        {
            return "The " + rank + " of " + suit;
        }

        // ICloneable
        public object Clone()
        {
            return MemberwiseClone();
        }

        #endregion

        #region Properties

        // Rotation properties
        public bool Rotated
        {
            get
            {
                return rotated;
            }
            set
            {
                rotated = value;
            }
        }

        #endregion

        #region Operator overloads

        // IEquatable overload ==
        public static bool operator ==(Card card1, Card card2)
        {
            return (card1.suit == card2.suit) && (card1.rank == card2.rank);
        }

        // IEquatable overload !=
        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }

        // IEquatable overload Equals(object)
        public override bool Equals(object card)
        {
            return this == (Card)card;
        }

        // IEquatable overload >
        public static bool operator >(Card card1, Card card2)
        {
            if (card1.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (card1.rank == Rank.Ace)
                    {
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return true;
                    }
                    else
                    {
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return (card1.rank > card2.rank);
                    }
                }
                else
                {
                    return (card1.rank > card2.rank);
                }
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))
                    return false;
                else
                    return true;
            }
        }

        // IEquatable overload <
        public static bool operator <(Card card1, Card card2)
        {
            return !(card1 >= card2);
        }

        // IEquatable overload >=
        public static bool operator >=(Card card1, Card card2)
        {
            if (card1.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (card1.rank == Rank.Ace)
                    {
                        return true;
                    }
                    else
                    {
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return (card1.rank >= card2.rank);
                    }
                }
                else
                {
                    return (card1.rank >= card2.rank);
                }
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))
                    return false;
                else
                    return true;
            }
        }

        // IEquatable overload <=
        public static bool operator <=(Card card1, Card card2)
        {
            return !(card1 > card2);
        }

        // Get a unique integer representation of a card
        public override int GetHashCode()
        {
            // Hacky fix. This puts aces at the end of the rank and trump suit last.
            // Has spaces between numbers and doesn't account for jokers.

            int mySuit;
            int myRank;
            if (isAceHigh && rank == Rank.Ace)
                myRank = 14;
            else
                myRank = (int)rank;
            if (useTrumps && suit == trump)
                mySuit = (int)suit + 4;
            else
                mySuit = (int)suit;

            // 13 = assuming spades/clubs/hearts/diamonds have no jokers. Otherwise there WILL be a collision. But this means cards are cleanly numbered 1-52
            // 14 = These suits can have one joker without collision. But with this implementation jokers should only be reserved for Black/Red suits.
            return 13 * mySuit + myRank;
        }

        #endregion
    }
}
