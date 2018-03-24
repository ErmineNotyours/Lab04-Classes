using System;

namespace TicTacToe
{
    class Program
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
    
        /// <summary>
        /// Main Menu, display and IO
        /// </summary>
        /// <returns>Returns false</returns>
        public static bool MainMenu()
        {
            string answer;
            bool play = true;
            player = true; // Player 1 is up first.
            Console.WriteLine("Tic Tac Toe");

            // Initialize the board
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board [row, col] = "0";
                }
            }

            while (play)
            {
                DisplayBoard();
                Console.WriteLine("Player 1 is X, Player 2 is O");
                DisplayPlayerUp();
                Console.WriteLine("Enter number of board position to move");
                answer = Console.ReadLine();
                ProcessInput(answer);
                // Check for end of game condition

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
                Console.WriteLine("Player 1 up!");
            }
            else
            {
                Console.WriteLine("Player 2 up!");
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
                if (player)
                    board[row, col] = "X"; // Player 1 gets X
                else
                    board[row, col] = "O"; // Player 2 gets O
                player = !player;          // Sucessful move, players 1 and 2 get flipped
                Console.Clear();
            }
            else
            {
                Console.WriteLine("That cell is occupied.  Try again.");
            }
        }

    }
    // I followed the class demo code, and it still doesn't work:
    
    //public class player
    //{
    //    public player(bool up)
    //    {
    //        Up = up;
    //    }
    //}
}
