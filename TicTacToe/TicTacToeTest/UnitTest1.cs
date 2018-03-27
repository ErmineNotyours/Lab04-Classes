using System;
using Xunit;
using TicTacToe;
using static TicTacToe.Program;

namespace TicTacToeTest
{
    public class UnitTest1
    {
        [Fact]
        public void ProcessInputTest()
        {
            string[,] myArray = new string[,] { { "0", "0" }, { "0", "0" }, { "0", "0" }, { "0", "0" }, { "0", "0" } }; 
            Assert.Equal(9, Game.ProcessInput("2", myArray , 8, true)); // 3rd parameter must be one less than expected result.  Other parameters have no effect.
        }

        //string[,] myArray = new string[,] { { "0", "0" }, { "0", "0" }, { "0", "0" }, { "0", "0" }, { "0", "0" } };

        //[Theory]
        //[InlineData ("1", { { "0", "0" }, { "0", "0" }, { "0", "0" }, { "0", "0" }, { "0", "0" } }, 8, 9)]
        //public void ProcessInputTheoryTest()
        //{
            
        //}
    }
}
