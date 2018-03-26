using System;

namespace TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Persist the main menu
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        }

        public static string[,] board = new string[3, 3];
        //public static player player1, player2 = new player; //Construction for when player class works
        public static bool player = new bool(); // Temp code because player does not work with classes.  true = player 1, false = player 2
        public static int counter = 0; // Counts the number of sucessful moves.  If there are nine moves, the game is over.  If a winning move does not come right before this, the game is tied.


        /// <summary>
        /// Main Menu, display and IO
        /// </summary>
        /// <returns>Returns false</returns>
        public static bool MainMenu()
        {
            bool metaPlay = true; // Play again play in progress
            while (metaPlay)
            {
                string answer;
                bool play = true; // Individual game in progress
                player = true; // Player 1 is up first.
                counter = 0; // placed here again, for repeat plays
                Console.WriteLine("Tic Tac Toe");


                // Initialize the board
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        board[row, col] = "0";
                    }
                }

                while (play)
                {
                    DisplayBoard();
                    Console.WriteLine("Player 1 is X, Player 2 is O");
                    DisplayPlayerUp();
                    Console.WriteLine("Enter number of board position to move");
                    answer = ReadChar();
                    ProcessInput(answer);

                    // check for end of game condition
                    if (CheckWin())
                    {
                        play = false;
                    }
                    else if (counter >= 9)
                    {
                        play = false;
                        Console.WriteLine("Game ends in a tie.");
                    }
                }
                DisplayBoard();
                Console.WriteLine("Play again, Y/N?");
                metaPlay = PlayAgain(); // returns true if player wants to play again, otherwise false.
                play = metaPlay;
            }

            return false;
        }

        /// <summary>
        /// Displays board.  Inputs public static string board, outputs to console.
        /// </summary>
        public static void DisplayBoard()
        {
            int counter = 1; // Counter for displaying the cell number
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == "0")
                        Console.Write(counter);
                    else
                        Console.Write(board[row, col]);
                    if (col == 0 || col == 1)
                        Console.Write("||");
                    counter++;
                }
                Console.WriteLine(""); //Carriage return at end of line
            }
            
        }

        /// <summary>
        /// Displays notice for player 1 or player 2
        /// </summary>
        public static void DisplayPlayerUp()
        {
            if (player)
            {
                Console.WriteLine("Player 1 'X' up!");
            }
            else
            {
                Console.WriteLine("Player 2 'O' up!");
            }
        }

        /// <summary>
        /// Process Input.  Contains the switch/case statement for mapping the game board to numbers 1 through 9
        /// </summary>
        /// <param name="answer">Number requested to access the board</param>
        public static void ProcessInput(string answer)
        {
            int row = 0, col = 0;
            switch (answer)
            {
                case "1":
                    row = 0;
                    col = 0;
                    break;
                case "2":
                    row = 0;
                    col = 1;
                    break;
                case "3":
                    row = 0;
                    col = 2;
                    break;
                case "4":
                    row = 1;
                    col = 0;
                    break;
                case "5":
                    row = 1;
                    col = 1;
                    break;
                case "6":
                    row = 1;
                    col = 2;
                    break;
                case "7":
                    row = 2;
                    col = 0;
                    break;
                case "8":
                    row = 2;
                    col = 1;
                    break;
                case "9":
                    row = 2;
                    col = 2;
                    break;
            }
            
            if (board[row, col] == "0") // cell has to be empty
            {
                // A sucessful move
                counter++;
                if (player)
                    board[row, col] = "X"; // Player 1 gets X
                else
                    board[row, col] = "O"; // Player 2 gets O
                player = !player;          // Sucessful move, players 1 and 2 get flipped
                //Console.Clear();
            }
            else
            {
                Console.WriteLine("That cell is occupied.  Try again.");
            }
        }

        // <summary>
        /// Checks for winning condition.
        /// </summary>
        public static bool CheckWin()
        {
            // Check horizontals
            for (int row = 0; row < 3; row++)
            {
                if ((board[row, 0] == board[row, 1]) && (board[row, 1] == board[row, 2]))
                {
                    if (board[row, 0] == "X")
                    {
                        Console.WriteLine("X Wins!");
                        return true;
                    }
                    if (board[row, 0] == "O")
                    {
                        Console.WriteLine("O Wins!");
                        return true;
                    }
                }
            }
            // Check verticals
            for (int col = 0; col < 3; col++)
            {
                if ((board[0, col] == board[1, col]) && (board[1, col] == board[2, col]))
                {
                    if (board[0, col] == "X")
                    {
                        Console.WriteLine("X Wins!");
                        return true;
                    }
                    if (board[0, col] == "O")
                    {
                        Console.WriteLine("O Wins!");
                        return true;
                    }
                    //

                 }
            }
            // Check diagonals
            if ((board[0, 0] == board[1, 1]) && (board[1, 1] == board[2, 2]))
            {
                if (board[1, 1] == "X")
                {
                    Console.WriteLine("X Wins!");
                    return true;
                }
                if (board[1, 1] == "O")
                {
                    Console.WriteLine("O Wins!");
                    return true;
                }
            }
            if ((board[2, 0] == board[1, 1]) && (board[1, 1] == board[0, 2]))
            {
                if (board[1, 1] == "X")
                {
                    Console.WriteLine("X Wins!");
                    return true;
                }
                if (board[1, 1] == "O")
                {
                    Console.WriteLine("O Wins!");
                    return true;
                }
            }
            // If you've reached this point in the code, a winning condition has not been reached
            return false;
        }

        /// <summary>
        /// Isolated console read for determining if user wants to play again.
        /// HAS A CONSOLE.READLINE, CANNOT TEST!
        /// </summary>
        /// <returns>true if player wants to play again, otherwise false</returns>
        public static bool PlayAgain()
        {
            string response = Console.ReadLine();
            if (response == "Y" || response == "y")
                return true;
            return false;
        }

        /// <summary>
        /// Isolated console read for regular game input
        /// HAS A CONSOLE.READLINE, CANNOT TEST!
        /// </summary>
        /// <returns>Character determining board position</returns>
        public static string ReadChar()
        {
            return Console.ReadLine();
        }


    }





    // I followed the class demo code, and it still doesn't work:
    // Is the class supposed to be here, or in a sperate file?

    //public class player
    //{
    //    public player(bool up)
    //    {
    //        Up = up;
    //    }
    //}
}
