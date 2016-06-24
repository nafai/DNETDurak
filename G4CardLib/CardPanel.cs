/***
 * Assignment:  Final Project: Durak
 * Names:       Group 4: Gregory Hammond, Jesse McDonald, Joel Roth
 * Course:      DNET 4200
 * Date:        17 April, 2015
 * 
 * File:     	G4CardLib\CardPanel.cs
 * Description: A Windows Forms Panel-derived class that stores PictureCards.
 *              Also handles locations and mouse events.
 ***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using System.Diagnostics;

namespace G4CardLib
{
    public class CardPanel : System.Windows.Forms.Panel
    {
        // Todo: Consider consting these
        public Point INITIAL_POINT = new Point(10, 25); // point in the groupbox to start drawing in
        public int CARD_SPACING = 20; // Horizontal space between cards in px
        public int HOVER_PX = 30; // Px to move up when hovered
        public Point startingOffset = new Point(5, 0); // Px to move right,down
        public bool cardsHoverable = true;

        public CardPanel()
        {
            // Debug to see the panel
            //this.BackColor = Color.Teal;
            // Adjust the cardpanel to scale to the entire parent
            this.Dock = DockStyle.Fill;
            this.ControlAdded += new ControlEventHandler(this.Control_Changed);
            this.ControlAdded += new ControlEventHandler(this.Control_Added);
            this.ControlRemoved += new ControlEventHandler(this.Control_Changed);
            this.ControlRemoved += new ControlEventHandler(this.Control_Removed);
        }

        private void Control_Changed(object sender, ControlEventArgs e)
        {
            UpdateControlOrder();
        }

        private void Control_Added(object sender, ControlEventArgs e)
        {
            PictureCard thisControl = (PictureCard)e.Control;
            
            // Remove potential hover events
            thisControl.myPictureBox.MouseEnter -= new EventHandler(Control_Hover);
            thisControl.myPictureBox.MouseLeave -= new EventHandler(Control_Unhover);
        
            // Update location
            UpdateControlOrder();

            // Update Z-order
            thisControl.BringToFront();

            // Add hovering (if exists)
            if (thisControl.Hoverable && cardsHoverable)
            {
                //Debug.WriteLine("Hovering event added to card "+e.Control.ToString());
                thisControl.myPictureBox.MouseEnter += new EventHandler(Control_Hover);
                thisControl.myPictureBox.MouseLeave += new EventHandler(Control_Unhover);
            }
        }

        private void Control_Removed(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            
        }

        public void UpdateControlOrder()
        {
            foreach (PictureCard thisControl in this.Controls)
            {
                thisControl.resting_point = new Point(startingOffset.X + CARD_SPACING * thisControl.cardNumber, startingOffset.Y + HOVER_PX);
                thisControl.hovering_point = new Point(startingOffset.X + CARD_SPACING * thisControl.cardNumber, startingOffset.Y);
                thisControl.Location = thisControl.resting_point;

                // Rotated cards are to the bottom left of the deck
                if (thisControl.Rotated)
                    thisControl.Location = new System.Drawing.Point(thisControl.Location.X - 45, thisControl.Location.Y + 45);
            }
        }

        public void UpdateControlZOrder()
        {
            foreach(PictureCard thisControl in Controls)
            {
                thisControl.Name = "Card"+thisControl.cardNumber.ToString();
            }
            for (int index = 0; index < Controls.Count; index++)
            {
                Controls[Controls.IndexOfKey("Card" + index)].BringToFront();
            }
        }

        // Hover/unhover is handled by this class
        private void Control_Hover(object sender, EventArgs e)
        {
            Control myControl = (Control)((Control)sender).Parent;
            PictureCard myPC = (PictureCard)myControl;
            if (myPC.Hoverable)
                myControl.Location = myPC.hovering_point;            
        }

        private void Control_Unhover(object sender, EventArgs e)
        {
            Control myControl = (Control)((Control)sender).Parent;
            PictureCard myPC = (PictureCard)myControl;
            if (myPC.Hoverable)
                myControl.Location = myPC.resting_point;
        }

        public void manuallyRaiseCard(PictureCard thisCard)
        {
            thisCard.Location = thisCard.hovering_point;
        }
    }
}
