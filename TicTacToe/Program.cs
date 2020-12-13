using System;

namespace TicTacToe
{
    class Program
    {

        static void Main(string[] args)
        {
            // Creates the game object.
            var game = new GameLogic();

            // Sets the bool for the game loop, and trackers for the turn
            // and the player.
            var gameRunning = true;
            var turnCounter = 1;

            
            // Game loop.
            while (gameRunning)
            {
                // If turn is divisable by 2, it's player twos turn.
                // Otherwise its players ones.
                var playerTracker = (turnCounter % 2 == 0)? 2 : 1;
                
                // Draws the grid.
                game.DrawBoard();

                // Gets the choice and updates the grid.
                var playerChoice = game.PlayerInput(playerTracker);
                game.UpdateGrid(playerChoice, playerTracker);

                // Adds to the turn counter.
                turnCounter++;

                // Checks for a victory, announces the victor, and asks if you want to reset.
                var victor = game.CheckForVictor();
                if (victor != "")
                {
                    victor = victor == "X" ? "Player 1" : "Player 2";
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
