/***
 * Assignment:  Final Project: Durak
 * Names:       Group 4: Gregory Hammond, Jesse McDonald, Joel Roth
 * Course:      DNET 4200
 * Date:        17 April, 2015
 * 
 * File:        G4CardLib\PictureCard.cs
 * Description: A graphical representation of a playing card. Contains a card
 *              object and passes references of its properties. Also contains
 *              click event and manipulation of the image.
 ***/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using G4CardLib;

namespace G4CardLib
{
    public partial class PictureCard : UserControl, IEquatable<PictureCard>, IComparable<PictureCard>
    {
        #region Class level variables/declarations

        /// <summary>
        /// A reference to the card stored and the PictureBox representation of said card
        /// </summary>
        private Card card;
        public PictureBox myPictureBox = new PictureBox();
        public static int backgroundSelection = 1;

        /// <summary>
        /// Card visual elements
        /// </summary>
        public Size originalCardSize = new Size(100, 145);

        /// <summary>
        /// Card display flags
        /// </summary>
        private bool hoverable = true;

        /// <summary>
        /// Location of card in relation to others when spread out
        /// </summary>
        public int cardNumber;

        public Point resting_point;
        public Point hovering_point;

        public Player myPlayer;

        #endregion

        #region Constructors
        
        public PictureCard()
        {
            // Default constructor: Face down ace of spades (used in VS UserControlTestContainer)
            InitThis();
            InitializeComponent();
            card = new Card(Suit.Spades, Rank.Ace, Face.Down);
        }

        public PictureCard(Suit newSuit, Rank newRank, Face newFace)
        {
            // Constructor that mimics a card's constructor (without creating a Card)
            InitThis();
            InitializeComponent();
            card = new Card(newSuit, newRank, newFace);
        }

        public PictureCard(Card newCard)
        {
            // Constructor that accepts a Card object
            InitThis();
            InitializeComponent();
            card = newCard;
        }

        #endregion

        #region Properties
        
        // Get/set the card's suit
        public Suit Suit
        {
            get
            {
                return card.suit;
            }
            set
            {
                // Only update if the suit actually changed
                if (value != card.suit)
                {
                    card.suit = value;
                    UpdateImage();
                }
            }
        }

        // Get/set the card's rank
        public Rank Rank
        {
            get
            {
                return card.rank;
            }
            set
            {
                // Only update if the rank actually changed
                if (value != card.rank)
                {
                    card.rank = value;
                    UpdateImage();
                }
            }
        }

        // Get/set the card's face
        public Face Face
        {
            get
            {
                return card.face;
            }
            set
            {
                // Only update if the face actually changed
                if (value != card.face)
                {
                    card.face = value;
                    UpdateImage();
                }
            }
        }

        // Get/set rotation flag
        public bool Rotated
        {
            get
            {
                return card.Rotated;
            }

            set
            {
                // Only update if the rotation actually changed
                if (value != card.Rotated)
                {
                    card.Rotated = value;
                    UpdateImage();
                }
            }
        }

        // Get/set hoverable flag
        public bool Hoverable
        {
            get
            {
                return hoverable;
            }
            set
            {
                hoverable = value;
            }
        }

        // Return the resource name for the card image (could be rolled into myBitmap if we wanted to)
        private string filename
        {
            get
            {
                // Output: suit_rank (rank is a number when available)
                String filenameBuilder = card.suit.ToString().ToLower() + "_";
                if (card.face == Face.Down)
                {
                    filenameBuilder = "card_back_"+backgroundSelection.ToString();
                    if (Properties.Resources.ResourceManager.GetObject(filenameBuilder).Equals(null))
                        filenameBuilder = "card_back_1"; // default
                }
                else if (1 < (int)card.rank && (int)card.rank <= 10)
                    filenameBuilder += (int)card.rank;
                else
                    filenameBuilder += card.rank.ToString().ToLower();

                return filenameBuilder;
            }
        }

        // Return a bitmap from this card's information
        private Bitmap myBitmap
        {
            get
            {
                try
                {
                    // Create a bitmap from the resource file
                    Bitmap thisBitmap = new Bitmap((Image)Properties.Resources.ResourceManager.GetObject(filename));

                    // Check rotation and apply accordingly
                    if (card.Rotated)
                        thisBitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    
                    return thisBitmap;

                }
                catch (NullReferenceException)
                {
                    // File not found
                    throw new Exception("Card file not found. Check references.");
                }
            }
        }

        #endregion

        #region Private methods
        
        // First time initialization of this object
        private void InitThis()
        {
            // Scale the internal PictureBox to the dimensions of the outer control
            myPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            
            // Add event handlers
            myPictureBox.Click += PictureCard_Click;
        }

        // Call when image changes value, face, rotation
        internal void UpdateImage()
        {
            card.fixJokers();

            // Update the PB image
            myPictureBox.Image = myBitmap;

            // Adjust the PictureBox size depending on card rotation
            if (Rotated)
                myPictureBox.Size = new Size(originalCardSize.Height, originalCardSize.Width);
            else
                myPictureBox.Size = new Size(originalCardSize.Width, originalCardSize.Height);

            // Resize the control to match the PictureBox
            Size = new Size(myPictureBox.Size.Width, myPictureBox.Size.Height);
        }

        #endregion

        #region Public Methods

        // Flip card face up/down and call the event handler
        public void Flip()
        {
            card.Flip();
            UpdateImage();
            if (CardFlipped != null)
                CardFlipped(this, new CardEventArgs(this));

        }

        // Rotate the card
        public void Rotate()
        {
            Rotated = !Rotated;
        }

        // ToString() hides face down cards in this class
        public override string ToString()
        {
            //if (card.face == Face.Down)
            //    return "Face Down";
            //else
                return card.ToString();
        }

        // Get a Card type object from this object
        public Card ToCard()
        {
            return card;
        }

        #endregion

        #region Events

        // Event declarations
        public event EventHandler<CardEventArgs> CardSelected;
        public event EventHandler<CardEventArgs> CardFlipped;

        // PictureBox clicked -> CardSelected (with CardEventArgs)
        void PictureCard_Click(object sender, EventArgs e)
        {
            if (CardSelected != null)
                CardSelected(this, new CardEventArgs(this));
        }


        // Control load (also used in UserControlTestContainer)
        private void PictureCard_Load(object sender, EventArgs e)
        {
            
            // Add the picturebox to this container's controls
            this.Controls.Add(myPictureBox);
            
            // Update the picturebox image
            UpdateImage();
        }
        
        #endregion

        #region Operators

        // (Card)PictureCard downcasts a PictureCard to a Card
        public static explicit operator Card(PictureCard pictureCard)
        {
            return pictureCard.ToCard();
        }

        // (PictureCard)Card upcasts a Card to a PictureCard
        public static explicit operator PictureCard(Card regularCard)
        {
            return new PictureCard(regularCard);
        }

        // IEquatable Equals(PictureCard) operator
        public bool Equals(PictureCard other)
        {
            // False if other not defined
            if (other == null) return false;
            // True if suit == rank
            return (this.card.rank.Equals(other.card.rank) && this.card.suit.Equals(other.card.suit));
        }

        // IEquatable Equals(Object) operator
        public override bool Equals(Object o)
        {
            // Stub: Might collide, probably won't.
            return (o.GetHashCode() == this.GetHashCode());
        }

        // IEquatable == operator
        public static bool operator ==(PictureCard card1, PictureCard card2)
        {
            if ((object)card1 == null || ((object)card2) == null)
                return Object.Equals(card1, card2);

            return card1.Equals(card2);
        }

        // IEquatable != operator
        public static bool operator !=(PictureCard card1, PictureCard card2)
        {
            return !card1.Equals(card2);
        }

        // Same as a Card.GetHashCode()
        public override int GetHashCode()
        {
            return ((Card)this).GetHashCode();
        }

        // IComparable CompareTo() 
        public int CompareTo(PictureCard compareCard)
        {
            // A null value means that this object is greater. 
            if (compareCard == null)
                return 1;
            else
                return this.GetHashCode().CompareTo(compareCard.GetHashCode());
        }


        #endregion
    }
}
