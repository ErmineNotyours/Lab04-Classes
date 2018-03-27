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
                displayMenu = Game.MainMenu();
            }
        }
    }

}
