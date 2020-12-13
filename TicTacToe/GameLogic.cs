using System;


namespace TicTacToe
{
    class GameLogic
    {
        // Sets up the game board.
        private string[,] _gameBoard =
        {
            { "1", "2", "3" },
            { "4", "5", "6" },
            { "7", "8", "9" }
        };

        // Draws the game board.
        public void DrawBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", _gameBoard[0, 0], _gameBoard[0, 1], _gameBoard[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", _gameBoard[1, 0], _gameBoard[1, 1], _gameBoard[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", _gameBoard[2, 0], _gameBoard[2, 1], _gameBoard[2, 2]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("                 ");
        }

        // Gets the player unput.
        public string PlayerInput(int playerNumber)
        {
            while (true)
            {
                // Dependant on player, picks what to call them.
                Console.WriteLine($"Player {playerNumber.ToString()}, please pick a square:");
                // Gets the player choice.
                var choice = Console.ReadLine();

                // Checks if it's a number.
                if (int.TryParse(choice, out var choiceInt))
                {
                    // If it is, turn to a number and check is's between 1 and 9.
                    choiceInt = int.Parse(choice);
                    if (choiceInt <= 9 && choiceInt >= 1)
                    {
                        if (SquareIsFree(choice))
                        {
                            return choice;
                        }
                        Console.WriteLine("That square is already taken, please choose another");
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
        }

        // Checks if the square that was picked is free.
        private bool SquareIsFree(string choice)
        {
            foreach (var square in _gameBoard)
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
            const int boardHeight = 3;
            const int boardWidth = 3;
            var icon = playerTracker == 1 ? "X" : "O";

            for (var w = 0; w < boardWidth; w++)
            {
                for (var h = 0; h < boardHeight; h++)
                {
                    if (_gameBoard[w, h].Equals(choice))
                    {
                        _gameBoard[w, h] = icon;
                    }
                }
            }
        }

        // Checks all the vistory conditions, if one is met, it will return the winning symbol.
        public string CheckForVictor()
        {
            if (_gameBoard[0,0].Equals(_gameBoard[0,1]) && _gameBoard[0, 1].Equals(_gameBoard[0, 2]))
            {
                return _gameBoard[0, 0];
            }
            if (_gameBoard[1, 0].Equals(_gameBoard[1, 1]) && _gameBoard[1, 1].Equals(_gameBoard[1, 2]))
            {
                return _gameBoard[1, 0];
            }
            if (_gameBoard[2, 0].Equals(_gameBoard[2, 1]) && _gameBoard[2, 1].Equals(_gameBoard[2, 2]))
            {
                return _gameBoard[2, 0];
            }
            if (_gameBoard[0, 0].Equals(_gameBoard[1, 0]) && _gameBoard[1, 0].Equals(_gameBoard[2, 0]))
            {
                return _gameBoard[0, 0];
            }
            if (_gameBoard[0, 1].Equals(_gameBoard[1, 1]) && _gameBoard[1, 1].Equals(_gameBoard[2, 1]))
            {
                return _gameBoard[0, 1];
            }
            if (_gameBoard[0, 2].Equals(_gameBoard[1, 2]) && _gameBoard[1, 2].Equals(_gameBoard[2, 2]))
            {
                return _gameBoard[0, 2];
            }
            if (_gameBoard[0, 0].Equals(_gameBoard[1, 1]) && _gameBoard[1, 1].Equals(_gameBoard[2, 2]))
            {
                return _gameBoard[0, 0];
            }
            if (_gameBoard[0, 2].Equals(_gameBoard[1, 1]) && _gameBoard[1, 1].Equals(_gameBoard[2, 0]))
            {
                return _gameBoard[0, 2];
            }
            return "";
        }

        // Loop to check if there is a draw.
        // Makes sure there is always a number avalible to pick.
        public bool CheckForDraw()
        {
            foreach (var square in _gameBoard)
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
            Console.WriteLine("(Any key for Yes or N to quit)");
            var answer = Console.ReadLine().ToLower();
            return !answer.Equals("n");
        }

        // Resets the gameboard to starting state.
        public void Reset()
        {
            _gameBoard = new [,]
            {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
            };
        }
    }

}
