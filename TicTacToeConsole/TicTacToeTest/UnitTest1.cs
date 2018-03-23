using System;
using Xunit;
using TicTacToeConsole;
namespace TicTacToeTest
{
    public class UnitTest1
    {
        [Fact]
        public void CanMakeBoardString()
        {
            Board x = new Board();
            Assert.Equal("|1||2||3|\n|4||5||6|\n|7||8||9|\n", x.BoardAsString(x.Arr));
        }
    }
}
