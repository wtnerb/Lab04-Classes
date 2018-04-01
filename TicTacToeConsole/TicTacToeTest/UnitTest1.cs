using System;
using Xunit;
using TicTacToeConsole;
namespace TicTacToeTest
{
    public class UnitTest1
    {
        [Fact]
        public void CanMakeBoard()
        {
            Board b = new Board();
            string[][] a = new string[][] { new string[] { "1", "2", "3" },
                                            new string[] { "4", "5", "6" },
                                            new string[] { "7", "8", "9" } };
            Assert.Equal(a, b.Arr);
        }
                                            
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
        public void CanMakePlayerName()
        {
            Player tom = new Player("Tom", "A");
            Assert.Equal("Tom", tom.Name);
        }

        [Fact]
        public void CanMakePlayerSymbol()
        {
            Player tom = new Player("Tom", "A");
            Assert.Equal("A", tom.Symbol);

        }

        [Fact]
        public void CanDiscoverWin()
        {
            string[][] diagonalWin =
                {
                    new string[] { "O", "X", "X" },
                    new string[] {"4", "X", "6" },
                    new string[] {"X", "8", "9" }
                };
            Assert.True(Program.IsWin(diagonalWin));
        }

        [Fact]
        public void NoFalseWin()
        {            
            string[][] notWin =
                {
                    new string[] { "x", "X", "X" },
                    new string[] {"4", "5", "6" },
                    new string[] {"7", "8", "9" }
                };
            Assert.False(Program.IsWin(notWin));
        }

        [Fact]
        public void CanDiscoverTopWin()
        {
            string[][] Win =
                {
                    new string[] { "X", "X", "X" },
                    new string[] {"4", "5", "6" },
                    new string[] {"7", "8", "9" }
                };
            Assert.True(Program.IsWin(Win));
        }

        [Fact]
        public void CanDiscoverBottomWin()
        {
            string[][] Win =
                    {
                    new string[] { "1", "X", "X" },
                    new string[] {"4", "5", "6" },
                    new string[] {"X", "X", "X" }
                };
            Assert.True(Program.IsWin(Win));
        }

        [Fact]
        public void CanDiscoverRightWin()
        {
            string[][] Win =
                {
                    new string[] { "X", "X", "O" },
                    new string[] {"4", "5", "O" },
                    new string[] {"7", "8", "O" }
                };
            Assert.True(Program.IsWin(Win));
        }

        [Fact]
        public void CanDiscoverDiagWin()
        {
            string[][] Win =
                {
                    new string[] { "X", "2", "X" },
                    new string[] {"4", "X", "6" },
                    new string[] {"7", "8", "X" }
                };
            Assert.True(Program.IsWin(Win));
        }

        [Fact]
        public void CanIdentifyLegalMoves()
        {
            Board board = new Board();
            board.Update(1, "X");
            board.Update(2, "O");
            board.Update(5, "X");
            board.Update(9, "O");
            Assert.Equal("34678", board.AllowedAsString());
        }

        [Fact]
        public void CanIdentifyMoreLegalMoves()
        {
            Board board = new Board();
            Assert.Equal("123456789", board.AllowedAsString());
        }
    }
}
