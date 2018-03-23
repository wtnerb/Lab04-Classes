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
            Assert.Equal("|1||2||3|\n|4||5||6|\n|7||8||9|\n", x.BoardAsString());
        }

        [Fact] void CanEditBoard()
        {
            Board b = new Board();
            b.Update(5, "X");
            b.Update(1, "X");
            b.Update(9, "O");
            b.Update(2, "X");
            Assert.Equal("|X||X||3|\n|4||X||6|\n|7||8||O|\n", b.BoardAsString());
        }

        [Fact] void CanMakePlayer()
        {
            Player tom = new Player("Tom", "A");
            Assert.Equal("Tom", tom.Name);
            Assert.Equal("A", tom.Symbol);
        }
    }
}
