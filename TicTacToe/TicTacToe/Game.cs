using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; } // To tell you the truth, Player2 is never accessed.  The logic of who is playing is only determined off of Player1's state.  For some reason, Visual Studio is not underlining this in green.

        /// <summary>
        /// Main Menu, display and IO
        /// </summary>
        /// <returns>Returns false</returns>
        public static bool MainMenu()
        {

            string[,] board = new string[3, 3];

            bool metaPlay = true; // Play again play in progress
            while (metaPlay)
            {
                string answer;
                bool play = true; // Individual game in progress
                bool Player1 = true; // Player 1 is up first.
                int counter = 0; //  Counts the number of sucessful moves.  If there are nine moves, the game is over.  If a winning move does not come right before this, the game is tied.
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
                    DisplayBoard(board);
                    Console.WriteLine("Player 1 is X, Player 2 is O");
                    DisplayPlayerUp(Player1);
                    Console.WriteLine("Enter number of board position to move");
                    answer = ReadChar();
                    counter = ProcessInput(answer, board, counter, Player1);

                    // check for end of game condition
                    if (CheckWin(board))
                    {
                        play = false;
                    }
                    else if (counter >= 9)
                    {
                        play = false;
                        Console.WriteLine("Game ends in a tie.");
                    }
                }
                DisplayBoard(board);
                Console.WriteLine("Play again, Y/N?");
                metaPlay = PlayAgain(); // returns true if player wants to play again, otherwise false.
                play = metaPlay;
            }

            return false; // Trips end of program
        }

        /// <summary>
        /// Process Input.  Contains the switch/case statement for mapping the game board to numbers 1 through 9
        /// </summary>
        /// <param name="answer">Number requested to access the board</param>
        /// <param name="board">The board that holds the game state</param>
        /// <param name="counter">The current turn number.  Advanced here on a sucessful turn</param>
        /// <param name="Player1">State of Player1: true, player1 is playing, false player2 is playing</param>
        public static int ProcessInput(string answer, string [,] board, int counter, bool Player1)
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
                if (Player1)
                    board[row, col] = "X"; // Player 1 gets X
                else
                    board[row, col] = "O"; // Player 2 gets O
                Player1 = !Player1;        // Sucessful move, players 1 and 2 get flipped
                //Console.Clear();
            }
            else
            {
                Console.WriteLine("That cell is occupied.  Try again.");
            }
            return counter;
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
        /// Displays board.  Inputs public static string board, outputs to console.
        /// </summary>
        public static void DisplayBoard(string[,] board)
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
        public static void DisplayPlayerUp(bool Player1)
        {
            if (Player1)
            {
                Console.WriteLine("Player 1 'X' up!");
            }
            else
            {
                Console.WriteLine("Player 2 'O' up!");
            }
        }



        // <summary>
        /// Checks for winning condition.
        /// </summary>
        public static bool CheckWin(string [,] board)
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
        /// Isolated console read for regular game input
        /// HAS A CONSOLE.READLINE, CANNOT TEST!
        /// </summary>
        /// <returns>Character determining board position</returns>
        public static string ReadChar()
        {
            return Console.ReadLine();
        }
    }
}
