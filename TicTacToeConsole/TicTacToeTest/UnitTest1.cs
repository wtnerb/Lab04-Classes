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

        [Fact]
        void CanMakePlayer()
        {
            Player tom = new Player("Tom", "A");
            Assert.Equal("Tom", tom.Name);
            Assert.Equal("A", tom.Symbol);
        }

        [Fact]
        [InlineData(())]
        void CanDiscoverWin(string[] arr)
        {
            string[] topWin = { "X", "X", "X", "4", "5", "6", "7", "8", "9" };
            string[] bottomWin = { "1", "2", "3", "4", "5", "6", "X", "X", "X" };
            string[] rightWin = { "1", "2", "O", "4", "5", "O", "7", "8", "O" };
            string[] notWin = { "1", "X", "X", "4", "5", "6", "7", "8", "9" };
            string[] diagWin = { "1", "X", "X", "4", "X", "6", "X", "8", "9" };
            string[] diagonalWin = { "X", "X", "3", "4", "X", "6", "7", "8", "X" };
            Assert.True(Board.Win(topWin));
            Assert.True(Board.Win(bottomWin));
            Assert.True(Board.Win(rightWin));
            Assert.True(Board.Win(diagWin));
            Assert.True(Board.Win(diagonalWin));
            Assert.False(Board.Win(notWin));
        }
    }
}
