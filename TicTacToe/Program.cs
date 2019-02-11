using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TicTacToe
{
    class Program
    {

        static void Main(string[] args)
        {
            // Creates the game object.
            GameLogic game = new GameLogic();

            // Sets the bool for the game loop, and trackers for the turn
            // and the player.
            bool gameRunning = true;
            int turnCounter = 1;
            int playerTracker = 1;

            // Game loop.
            while (gameRunning)
            {
                // If turn is divisable by 2, it's player twos turn.
                // Otherwise its players ones.
                if (turnCounter % 2 == 0)
                {
                    playerTracker = 2;
                }
                else
                {
                    playerTracker = 1;
                }

                // Draws the grid.
                game.DrawBoard();

                // Gets the choice and updates the grid.
                string playerChoice = game.PlayerInput(playerTracker);
                game.UpdateGrid(playerChoice, playerTracker);

                // Adds to the turn counter.
                turnCounter++;

                // Checks for a victory, announces the victor, and asks if you want to reset.
                string victor = game.CheckForVictor();
                if (victor != "")
                {
                    if (victor == "X")
                    {
                        victor = "Player 1";
                    }
                    else
                    {
                        victor = "Player 2";
                    }
                    // Shows the winnig board.
                    Console.Clear();
                    game.DrawBoard();

                    // Congratulates player on the win.
                    Console.WriteLine(" ");
                    Console.WriteLine("Congratualtion {0}! You have won", victor);
                    Console.WriteLine(" ");

                    // Asks if they want to reset or quit.
                    if (game.ResetOrQuit())
                    {
                        game.Reset();
                        turnCounter = 1;
                    }
                    else
                    {
                        gameRunning = false;
                    }
                }

                // Checks for a draw, announces the draw, and asks if you want to reset.
                if (game.CheckForDraw())
                {
                    // Shows the drawing board.
                    Console.Clear();
                    game.DrawBoard();
                    Console.WriteLine(" ");
                    Console.WriteLine("Looks like you drew!");
                    Console.WriteLine(" ");

                    // Asks if they want to reset or quit.
                    if (game.ResetOrQuit())
                    {
                        game.Reset();
                        turnCounter = 1;
                    }
                    else
                    {
                        gameRunning = false;
                    }
                }
                // Clear the screen each loop.
                Console.Clear();
            }

        }
    }



}
