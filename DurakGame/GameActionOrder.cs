using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G4CardLib;
using System.Windows.Forms;

namespace DurakGame
{
    public partial class Game
    {

        /// <summary>
        /// Execute next step in gameActionOrder.
        /// GA0: First time setup (pretty much empty)
        /// GA1: Executed at start of game
        /// GA2: Start of turn
        /// GA3: Attacker's first move
        /// GA4: Defender move
        /// GA5: Attacker's continuation
        /// GA6: Game over
        /// Once the steps are finished, move it into internal documentation.
        /// </summary>
        public void Go()
        {
            Log.Write("Game action order " + gameActionOrder.ToString());

            switch (gameActionOrder)
            {
                case 0:
                    Log.Write("GA0: Variable init", false);

                    gameActionOrder = 1;
                    break;

                case 1:
                    // This action should only be run once-- at the start of each game.

                    Log.Write("GA1: Game setup", false);

                    // First game or tie game: Random dealer
                    if (Program.lastFool == -1 || Program.lastFool > playersInGame.Count() - 1)
                        dealer = rng.Next(playersInGame.Count());
                    else
                        dealer = Program.lastFool;

                    Log.Write(playersInGame[dealer].Name+" is dealing (" + (Program.lastFool == -1?"no fool last game":"fool from last game") + ").", true);

                    // Attacker: First clockwise player from dealer
                    attacker = nextPlayer(dealer);
                    nextAttacker = -1;

                    // Deal cards to players, starting from the first attacker
                    dealPlayerHands();

                    // Move onto next action
                    gameActionOrder = 2;

                    break;
                case 2:
                    Log.Write("GA2: Start of turn", false);
                    
                    humanWantsToTakeOrPass = false;

                    // At this point in the structure, the attacker is still set from the last round (OR dealer+1 on new game).
                    // Attacker is needed for topUpPlayerHands(). It's safe to change after that's been called though.

                    if (gameDeckPlayer.Deck.Count() > 0)
                    {
                        // Cards still in deck
                        Log.Write("Deck has " + gameDeckPlayer.Deck.Count().ToString() + " cards. Topping up player hands.", false);

                        // Top up player hands (see the method for more details on the order)
                        topUpPlayerHands();
                    }
                    else
                    {
                        // Empty deck
                        Log.Write("Deck is empty!", false);

                        // Remove players with empty hands from the game.
                        for (int playerIndex = playersInGame.Count(); playerIndex > 0; playerIndex--)
                        {
                            if (playersInGame[playerIndex-1].Deck.Count() == 0)
                            {
                                // Player ran out of cards, remove them from the game
                                Log.Write(playersInGame[playerIndex-1].Name + " ran out of cards and exits the game!", true);
                                playersInGame.RemoveAt(playerIndex-1);

                                if (playersInGame.Count() == 0)
                                {
                                    gameActionOrder = 6;
                                    break;
                                }

                                // Fix attacker position
                                if (playerIndex-1<nextAttacker)
                                    nextAttacker--;
                                else if (playerIndex-1 == nextAttacker)
                                    nextAttacker = nextPlayer(nextAttacker);
                            }
                        }

                        // Check victory condition: Only one player left (fool), zero players left (tie)
                        if (playersInGame.Count() <= 1)
                        {
                            gameActionOrder = 6;
                            break;
                        }
                    }

                    // Select next attacker
                    if (nextAttacker != -1)
                        attacker = nextAttacker;
                    
                    // Go to step 3
                    gameActionOrder = 3;
                    break;
                case 3:
                    Log.Write("GA3: Attacker's first move", false);

                    // A player only needs to select a card from their hand. It can be anything.
                    if (selectedCard == null)
                    {
                        if (attackingPlayer.IsHuman)
                        {
                            // Human attacks with any card
                            isHumanTurn = true;
                            Log.Write("Make your move, human.", true);
                        }
                        else
                        {
                            // AI attacks with any card (but still chooses the best one)
                            selectedCard = getAIAttackCardFromHand(attackingPlayer.Deck);

                            // If AI can't choose a card to attack with, it means its hand is empty (but we check anyway)
                            if (selectedCard == null)
                            {
                                if (attackingPlayer.Deck.Count() == 0)
                                    Log.Write("AI is out of cards! This should be checked for earlier..", true);
                                else
                                    throw new NotImplementedException();
                            }
                        }
                        
                        // Start case 3 over.
                        break;
                    }
                    else
                    {
                        // GA3 valid card selected from AI or human (no checking required)
                        Log.Write(attackingPlayer.Name + " attacks " + defendingPlayer.Name + " with " + selectedCard.ToString() + ".", true);
                        
                        // Move card from player to table
                        moveCardToTable(selectedCard);
                        attackingCard = selectedCard;

                        selectedCard = null;

                        // Go to case 4, defender's move
                        gameActionOrder = 4;
                    }

                    break;
                case 4:
                    Log.Write("GA4: Defender's move", false);

                    // Check to see if player has at least one card to defend against
                    // Check to see if player used the grab button
                    if (selectedCard == null)
                    {
                        if (defendingPlayer.IsHuman)
                        {
                            // Human move as defender
                            if (humanWantsToTakeOrPass)
                            {
                                Log.Write(defendingPlayer.Name + " takes " + gameTablePlayer.Deck.Count() + " card" + (gameTablePlayer.Deck.Count() == 1 ? "" : "s") + "!", true);
                                giveAllCardsOnTableToPlayer(defendingPlayer);
                                
                                // Defender doesn't get to attack next turn. Turn passed to player after defender
                                nextAttacker = nextPlayer(defender);

                                // Start round again (GA2)
                                gameActionOrder = 2;
                                break;
                            }
                            else
                            {
                                Log.Write("Human " + playersInGame[defender].Name + " is defending against " + attackingCard.ToString(), false);
                                Log.Write("Defend, human. Play a card or take.", false);

                                // Open up the option to take
                                setContextButtonToTake();

                                // Break out of GAO and back to the main form
                                isHumanTurn = true;
                                break;
                            }
                        }
                        else if (defendingPlayer.IsAI)
                        {
                            Log.Write("AI " + defendingPlayer.Name + " is defending against "+attackingCard.ToString(), false);

                            // AI selects card from hand
                            selectedCard = getAIDefenseCardFromHand(attackingCard, defendingPlayer.Deck);

                            if (selectedCard == null)
                            {
                                // Attack ends. AI was unsuccessful in defending.
                                Log.Write(defendingPlayer.Name + " takes " + gameTablePlayer.Deck.Count() + " card" + (gameTablePlayer.Deck.Count() == 1?"":"s") + "!", true);
                                
                                // AI takes all cards
                                giveAllCardsOnTableToPlayer(defendingPlayer);
                                
                                // Defender doesn't get to attack next turn.
                                nextAttacker = nextPlayer(defender);
                                
                                // Start of new round
                                gameActionOrder = 2;
                                break;
                            }

                        }
                    }
                    else
                    {
                        // GA4 unverified card selected
                        // Check move validity
                        if (!isValidDefendingMove(attackingCard,selectedCard))
                        {
                            // Invalid card played
                            Log.Write(defendingPlayer.Name + " tried to make an invalid move by defending with " + selectedCard.ToString() + "! Try again!", true);
                            
                            // Null the card
                            selectedCard = null;
                            
                            // Start GA4 again
                            break;
                        }
                        else
                        {
                            // Successful defense
                            Log.Write(defendingPlayer.Name+" defends successfully with "+selectedCard.ToString()+"!", true);
                            
                            moveCardToTable(selectedCard);

                            // End of GA4
                            selectedCard = null;
                            gameActionOrder = 5;
                        }
                    }
                    
                    break;
                case 5:
                    Log.Write("GA5: Attacker's continuation", false);

                    // Oops, the defender is out of cards! Take defender out of game
                    if (defendingPlayer.Deck.Count() == 0)
                    {
                        Log.Write(defendingPlayer.Name+" ran out of cards! Attack over!", true);

                        // Defending player has no cards, so don't continue the attack. Auto-pass.
                        giveAllCardsOnTableToPlayer(discardPilePlayer);
                        nextAttacker = defender;

                        // Start next turn
                        gameActionOrder = 2;
                        break;
                    }

                    if (selectedCard == null)
                    {
                        if (humanWantsToTakeOrPass && attackingPlayer.IsHuman)
                        {
                            // Human clicked on Pass

                            Log.Write(attackingPlayer.Name + " passes their attack.", true);

                            // Discard all cards on table
                            giveAllCardsOnTableToPlayer(discardPilePlayer);

                            // Defender is the new attacker
                            nextAttacker = defender;

                            // New turn with new attacker
                            gameActionOrder = 2;
                            break;
                        }
                        else if (attackingPlayer.IsHuman)
                        {
                            // Human hasn't selected an action yet
                            isHumanTurn = true;
                            setContextButtonToPass();
                            Log.Write("Make your move, human. You get to attack or pass.", true);
                            break;
                        }
                        else
                        {
                            // AI moves

                            // Have AI choose VALID card for attack
                            selectedCard = getAIContinuedAttackCardFromHand(attackingPlayer.Deck);

                            // If AI can't select a valid card, the AI passes.
                            if (selectedCard == null)
                            {
                                Log.Write(attackingPlayer.Name+" passes their attack.", false);
                                
                                giveAllCardsOnTableToPlayer(discardPilePlayer);
                                nextAttacker = defender;
                                gameActionOrder = 2;
                                break;
                            }
                            else
                                break;
                        }                       
                    }
                    else
                    {
                        // Card was chosen for attack
                        attackingCard = selectedCard;

                        // Check for valid card
                        if (!isValidCardForContinuedAttack(selectedCard))
                        {
                            // Invalid card chosen after all. Blank selectedCard and start this section again
                            Log.Write(attackingPlayer.Name + " tried to continue attack with " + selectedCard.ToString() + " but couldn't!", true);
                            selectedCard = null;
                            break;
                        }
                        else
                        {
                            // Valid card selected
                            Log.Write(attackingPlayer.Name + " continues attack with " + selectedCard.ToString(), true);

                            // Move card from player to table
                            attackingCard = selectedCard;
                            selectedCard = null;

                            moveCardToTable(attackingCard);

                            // Go to case 4, defender's move
                            gameActionOrder = 4;
                            break;
                        }
                    }
                case 6:
                    // Victory condition for someone

                    if (playersInGame.Count() == 0)
                    {
                        endOfGameMessage = "Tie game!";
                        Program.lastFool = -1;
                    }
                    else if (playersInGame.Count() == 1)
                    {
                        endOfGameMessage = playersInGame[0].Name + " is the fool!";
                        Program.lastFool = playersInGame[0].originalIndex;
                    }

                    Log.Write("Game over! "+endOfGameMessage, true);

                    // Stop game execution
                    gameStarted = false;
                    break;
                case 99:
                    // Stop game
                    Log.Write("Game stopped for unknown reasons.", false);
                    gameStarted = false;
                    break;
                case 100:
                    // Game action order overflow. User should not end up here.
                    throw new NotImplementedException();
                default:
                    gameActionOrder++;
                    break;

            }
        }
    }
}
