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
        public void CanMakePlayer()
        {
            Player tom = new Player("Tom", "A");
            Assert.Equal("Tom", tom.Name);
            Assert.Equal("A", tom.Symbol);
        }

        [Fact]
        public void CanDiscoverWin()
        {
            string[][] topWin = 
                {
                    new string[] { "X", "X", "X" },
                    new string[] {"4", "5", "6" },
                    new string[] {"7", "8", "9" }
                };
            string[][] bottomWin =
                {
                    new string[] { "1", "X", "X" },
                    new string[] {"4", "5", "6" },
                    new string[] {"X", "X", "X" }
                };
            string[][] rightWin =
                {
                    new string[] { "X", "X", "O" },
                    new string[] {"4", "5", "O" },
                    new string[] {"7", "8", "O" }
                };
            string[][] notWin =
                {
                    new string[] { "x", "X", "X" },
                    new string[] {"4", "5", "6" },
                    new string[] {"7", "8", "9" }
                };
            string[][] diagWin =
                {
                    new string[] { "X", "2", "X" },
                    new string[] {"4", "X", "6" },
                    new string[] {"7", "8", "X" }
                };
            string[][] diagonalWin =
                {
                    new string[] { "O", "X", "X" },
                    new string[] {"4", "X", "6" },
                    new string[] {"X", "8", "9" }
                };
            Assert.True(Program.IsWin(topWin));
            Assert.True(Program.IsWin(bottomWin));
            Assert.True(Program.IsWin(rightWin));
            Assert.True(Program.IsWin(diagWin));
            Assert.True(Program.IsWin(diagonalWin));
            Assert.False(Program.IsWin(notWin));
        }

        [Fact]
        public void CanIdentifyLegalMoves()
        {
            Board brd1 = new Board();
            brd1.Update(1, "X");
            brd1.Update(2, "O");
            brd1.Update(5, "X");
            brd1.Update(9, "O");
            Board board = new Board();
            Assert.Equal("34678", Program.AllowedAsString(brd1));
            Assert.Equal("123456789", Program.AllowedAsString(board));

        }
    }
}
