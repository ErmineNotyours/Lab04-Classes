using System;
using Xunit;
using TicTacToe;
using static TicTacToe.Program;

namespace TicTacToeTest
{
    public class UnitTest1
    {
        [Fact]
        public void ProcessInputTest1()
        {
            string[,] myArray = new string[,] { { "0", "0" }, { "0", "0" }, { "0", "0" }, { "0", "0" }, { "0", "0" } };
            bool Player1 = true;
            Assert.Equal(9, Game.ProcessInput("2", myArray , 8, ref Player1)); // 3rd parameter must be one less than expected result.  Other parameters have no effect.
        }

        [Fact]
        public void ProcessInputTest2()
        {
            bool Player1 = true;
            string[,] myArray = new string[,] { { "0", "0" }, { "0", "0" }, { "0", "0" }, { "0", "0" }, { "0", "0" } };
            Assert.Equal(8, Game.ProcessInput("2", myArray, 7, ref Player1)); // 3rd parameter must be one less than expected result.  Other parameters have no effect.
        }

        [Fact]
        public void ProcessInputTest3()
        {
            bool Player1 = true;
            string[,] myArray = new string[,] { { "0", "0" }, { "0", "0" }, { "0", "0" }, { "0", "0" }, { "0", "0" } };
            Assert.Equal(9, Game.ProcessInput("2", myArray, 8, ref Player1)); // 3rd parameter must be one less than expected result.  Other parameters have no effect.
        }

    }
}
