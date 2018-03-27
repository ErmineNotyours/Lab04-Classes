using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Used to create the variables Player1 and Player2
/// </summary>
namespace TicTacToe
{
    public class Player
    {
        public Player(bool up)
        {
            Up = up; // True if player is up (currently playing)
        }
        public bool Up { get; set; }
        
    }
}
