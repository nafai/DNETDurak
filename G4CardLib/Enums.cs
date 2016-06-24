/***
 * Assignment:  Final Project: Durak
 * Names:       Group 4: Gregory Hammond, Jesse McDonald, Joel Roth
 * Course:      DNET 4200
 * Date:        17 April, 2015
 * 
 * File:        G4CardLib\Enums.cs
 * Description: All enums used in G4CardLib. Split from their respective 
 *              classes as per consultation 2 directive.
 *              
 *              Card enums:     Suit, SuitNoJokers, Rank, RankNoJokers, Face
 *              Deck enums:     DeckSize
 *              Player enums:   PlayerType
 ***/

using System;

namespace G4CardLib
{
    #region Card class enums

    // Suit enum: Red/Black used exclusively for jokers
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades,
        Red,
        Black
    }

    // Used for filling comboboxes
    public enum SuitNoJokers
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum Rank
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Joker
    }

    // Used for filling comboboxes
    public enum RankNoJokers
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    // Cound be a bool, or could also store rotation
    public enum Face
    {
        Up,
        Down
    }
    #endregion

    #region Deck class enums

    /// <summary>
    /// An enumeration of different sizes of decks.
    /// </summary>
    public enum DeckSize
    {
        /// <summary>
        /// A standard deck of 52 cards.
        /// </summary>
        RegularDeck,
        /// <summary>
        /// A standard deck of 52 cards and the addition of the two jokers.
        /// </summary>
        RegularDeckWithJokers,
        /// <summary>
        /// A standard durak deck of 36 cards ranging from sixes to aces.
        /// </summary>
        Durak36Deck,
        /// <summary>
        /// A durak deck of 20 cards including only the tens and face cards.
        /// </summary>
        Durak20Deck
    }

    #endregion

    #region Player class enums
    public enum PlayerType
    {
        Human,
        AI,
        None
    }
    #endregion

}
