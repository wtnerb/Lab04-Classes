using System;

namespace TicTacToeConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static bool IsWin(string[][] board)
        {
            //check row
            foreach (string[] row in board)
            {
                if (row[0] == row[1] && row[1] == row[2])
                {
                    return true;
                }
            }

            //check cols
            for (byte col = 0; col < 3; col++)
            {
                if (board[1][col] == board[0][col] && board[1][col] == board[2][col])
                {
                    return true;
                }
            }

            //check diags, top left then top right
            if ((board[0][0] == board[1][1] && board[1][1] == board[2][2]) //diag including top left
                || board[0][2] == board[1][1] && board[1][1] == board[2][0]) //diag incling top right
            {
                return true;
            }
            return false;
        }

    }
}
