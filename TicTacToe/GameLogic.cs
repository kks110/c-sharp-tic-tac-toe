using System;


namespace TicTacToe
{
    class GameLogic
    {
        // Sets up the game board.
        public string[,] gameBoard = new string[,]
        {
            { "1", "2", "3" },
            { "4", "5", "6" },
            { "7", "8", "9" }
        };

        // Draws the game board.
        public void DrawBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", gameBoard[0, 0], gameBoard[0, 1], gameBoard[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", gameBoard[1, 0], gameBoard[1, 1], gameBoard[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", gameBoard[2, 0], gameBoard[2, 1], gameBoard[2, 2]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("                 ");
        }

        // Gets the player unput.
        public string PlayerInput(int playerNumber)
        {
            int choiceInt = 0;
            string choice = "";
            bool validEntry = false;


            while (!validEntry)
            {
                // Dependant on player, picks what to call them.
                if (playerNumber == 1)
                {
                    Console.WriteLine("Player 1, please pick a square:");
                }
                else
                {
                    Console.WriteLine("Player 2, please pick a square:");
                }
                // Gets the player choice.
                choice = Console.ReadLine();

                // Checks if it's a number.
                if (int.TryParse(choice, out choiceInt))
                {
                    // If it is, turn to a number and check is's between 1 and 9.
                    choiceInt = int.Parse(choice);
                    if (choiceInt <= 9 && choiceInt >= 1)
                    {
                        if (SquareIsFree(choice))
                        {
                            validEntry = true;
                        }
                        else
                        {
                            Console.WriteLine("That square is already taken, please choose another");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please choose a number between 1 and 9");
                    }
                }
                else
                {
                    Console.WriteLine("That was not a number, please enter a number");
                }
            }

            return choice;
        }

        // Checks if the square that was picked is free.
        private bool SquareIsFree(string choice)
        {
            foreach (string square in gameBoard)
            {
                if (square.Equals(choice))
                {
                    return true;
                }

            }

            return false;
        }

        // Updates the grid with the players choice.
        public void UpdateGrid(string choice, int playerTracker)
        {
            int boardHeight = 3;
            int boardWidth = 3;
            string icon = "";

            if (playerTracker == 1)
            {
                icon = "X";
            }
            else
            {
                icon = "O";
            }

            for (int w = 0; w < boardWidth; w++)
            {
                for (int h = 0; h < boardHeight; h++)
                {
                    if (gameBoard[w, h].Equals(choice))
                    {
                        gameBoard[w, h] = icon;
                    }
                }
            }
        }

        // Checks all the vistory conditions, if one is met, it will return the winning symbol.
        public string CheckForVictor()
        {
            if (gameBoard[0,0].Equals(gameBoard[0,1]) && gameBoard[0, 1].Equals(gameBoard[0, 2]))
            {
                return gameBoard[0, 0];
            }
            else if (gameBoard[1, 0].Equals(gameBoard[1, 1]) && gameBoard[1, 1].Equals(gameBoard[1, 2]))
            {
                return gameBoard[1, 0];
            }
            else if (gameBoard[2, 0].Equals(gameBoard[2, 1]) && gameBoard[2, 1].Equals(gameBoard[2, 2]))
            {
                return gameBoard[2, 0];
            }
            else if (gameBoard[0, 0].Equals(gameBoard[1, 0]) && gameBoard[1, 0].Equals(gameBoard[2, 0]))
            {
                return gameBoard[0, 0];
            }
            else if (gameBoard[0, 1].Equals(gameBoard[1, 1]) && gameBoard[1, 1].Equals(gameBoard[2, 1]))
            {
                return gameBoard[0, 1];
            }
            else if (gameBoard[0, 2].Equals(gameBoard[1, 2]) && gameBoard[1, 2].Equals(gameBoard[2, 2]))
            {
                return gameBoard[0, 2];
            }
            else if (gameBoard[0, 0].Equals(gameBoard[1, 1]) && gameBoard[1, 1].Equals(gameBoard[2, 2]))
            {
                return gameBoard[0, 0];
            }
            else if (gameBoard[0, 2].Equals(gameBoard[1, 1]) && gameBoard[1, 1].Equals(gameBoard[2, 0]))
            {
                return gameBoard[0, 2];
            }
            else
            {
                return "";
            }
        }

        // Loop to check if there is a draw.
        // Makes sure there is always a number avalible to pick.
        public bool CheckForDraw()
        {
            foreach (string square in gameBoard)
            {
                if (square != "X" && square != "O")
                {
                    return false;
                }

            }

            return true;
        }

        // Asks the player if they would like to reset the game or quit.
        public bool ResetOrQuit()
        {
            Console.WriteLine("Would you like to play again?");
            Console.WriteLine("(Y for Yes or N to quit)");
            string answer = Console.ReadLine();
            answer = answer.ToLower();
            if (answer.Equals("n"))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        // Resets the gameboard to starting state.
        public void Reset()
        {
            gameBoard = new string[,]
            {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
            };
        }
    }

}
