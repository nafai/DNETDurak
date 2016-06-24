/***
 * Assignment:  Final Project: Durak
 * Names:       Group 4: Gregory Hammond, Jesse McDonald, Joel Roth
 * Course:      DNET 4200
 * Date:        17 April, 2015
 * 
 * File:        DurakGame\GameSetup.cs
 * Description: Class variables, constructors, and other functions and methods 
 *              used to set up the game class.
 *              
 *              This class doesn't contain components used after a Game has 
 *              been instantiated.
 ***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G4CardLib;
using System.Windows.Forms;
using System.Collections;
using System.Collections.ObjectModel;


namespace DurakGame
{
    public partial class Game
    {
        #region Class Variables

        //Declarations:

        /// <summary>
        /// The default number of players.
        /// </summary>
        private const int PLAYER_COUNT_DEFAULT = 6;
        /// <summary>
        /// The maximum number of players permitted per game.
        /// </summary>
        private const int PLAYER_COUNT_MAX = 6;
        /// <summary>
        /// The minimum players per game.
        /// </summary>
        private const int PLAYER_COUNT_MIN = 1;

        /// <summary>
        /// A private integer that stores the number of cards that are delt at the start of the game.
        /// </summary>
        private int playerHandSize = 6;
        public Deck gameDeck = new Deck();
        public Player gameDeckPlayer = new Player("Fake player (Deck)", PlayerType.None);
        public Player gameTablePlayer = new Player("Fake player (Table)", PlayerType.None);
        public Player discardPilePlayer = new Player();

        public readonly string[] DEFAULT_PLAYER_NAMES = { "Player 1 (Human)", "Player 2 (AI)", "Player 3 (AI)", "Player 4 (AI)", "Player 5 (AI)", "Player 6 (AI)" };
        public PictureBox pbTrumpImage;
        public static String userMessageLog;
        private Random rng = new Random();
        private int dealer;
        private int attacker;
        private int nextAttacker;
        private int gameActionOrder = 0;
        public event EventHandler ResumeLoop;
        internal bool gameStarted = true;
        internal bool isHumanTurn = false;
        private PictureCard selectedCard;
        private PictureCard attackingCard;
        internal Button btnContextual;
        private bool humanWantsToTakeOrPass = false;
        internal string endOfGameMessage = "";

        /// <summary>
        /// The size of the deck.
        /// </summary>
        private DeckSize deckSize;

        private Collection<Player> playersInGame = new Collection<Player>();

        #endregion

        #region Constructors

        /// <summary>
        /// Default game constructor.
        /// </summary>
        public Game()
        {
        }

        public Game(int numberOfPlayers)
        {
            AddPlayersToGame(numberOfPlayers);
        }

        #endregion


        public void startGame()
        {
            Log.Write("New game started. Setting up.", false);

            // Set the number of cards in the deck.
            deckSize = Program.optionGameDeckSize;
            // 20 card deck: Each player gets an even number of cards. Cap at 6 card hands.
            if (Program.optionGameDeckSize == DeckSize.Durak20Deck && playersInGame.Count() > 2)
                playerHandSize = 20 / playersInGame.Count();

            // init deck
            SetupNewGameDeck();

            // Initial user message log text (different from game log)
            Log.Write("Game setup complete.", false);

            gameActionOrder = 0;
        }

        private void AddPlayersToGame(int numberOfPlayers)
        {
            if (numberOfPlayers < 2)
                throw new Exception("Must have at least two players in the game");
            else if (numberOfPlayers > 6)
                throw new Exception("This game cannot support more than six players.");

            playersInGame.Add(new Player(Program.noHumanPlayer?"Player 1 (AI)":DEFAULT_PLAYER_NAMES[0], Program.noHumanPlayer?PlayerType.AI:PlayerType.Human));
            playersInGame.Add(new Player(DEFAULT_PLAYER_NAMES[1], PlayerType.AI));

            Player.ALL_CARDS_FACE_UP = Program.noHumanPlayer;

            if (numberOfPlayers >= 3)
                playersInGame.Add(new Player(DEFAULT_PLAYER_NAMES[2], PlayerType.AI));
            if (numberOfPlayers >= 4)
                playersInGame.Add(new Player(DEFAULT_PLAYER_NAMES[3], PlayerType.AI));
            if (numberOfPlayers >= 5)
                playersInGame.Add(new Player(DEFAULT_PLAYER_NAMES[4], PlayerType.AI));
            if (numberOfPlayers == 6)
                playersInGame.Add(new Player(DEFAULT_PLAYER_NAMES[5], PlayerType.AI));

            foreach(Player thisPlayer in playersInGame)
            {
                thisPlayer.originalIndex = playersInGame.IndexOf(thisPlayer);
            }
        }

        private void SetupNewGameDeck()
        {
            // Init internal temporary deck
            gameDeck = new Deck();
            gameDeck.AddNewDeck(deckSize);

            // Shuffle the deck
            gameDeck.Shuffle();

            // Set up the fake player that owns the deck (visual)

            // Game deck cards aren't spread out like a player panel
            gameDeckPlayer.playerPanel.CARD_SPACING = 0;

            // Remove hovering from the deck panel
            gameDeckPlayer.playerPanel.cardsHoverable = false;

            // Move deck panel over a bit
            gameDeckPlayer.playerPanel.startingOffset = new System.Drawing.Point(45, 5);

            // Enumerate each card in the internal deck and add it to the fake player's "hand".
            foreach (PictureCard thisCard in gameDeck)
                gameDeckPlayer.Add(thisCard);

            // Subscribe to find out when the deck is empty
            gameDeckPlayer.LastCardRemoved += LastCardRemovedFromDeckHandler;

            // Trump card!
            Card.trump = gameDeckPlayer.Deck.First().ToCard().suit;
            Card.useTrumps = true;

            // Flip card face up
            gameDeckPlayer.Deck.First().Face = Face.Up;

            // Rotate card
            gameDeckPlayer.Deck.First().Rotate();
        }

    }
}
