using System;
using System.Text.RegularExpressions;

namespace TicTacToeConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Welcome to Brent's TicTacToe. To start the game ...");
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

        public static String[][] CreatePlayers()
        {
            string[][] output = 
                {
                    new String[] {"", ""},
                    new String[] {"", ""}
                };
            Regex validName = new Regex("\\w+");
            Regex validSymbol = new Regex("^[A-Z]$");
            output[0][0] = CollectValidInput("Player 1's name.", validName, "Nothing is forbidden to player1");
            
        }

        public string CollectValidInput(string prompt, Regex valid, string forbid)
        {
            byte count = 0;
            while (count < 8)
            {
                Console.WriteLine($"Please insert {prompt}");
                count++;
                try
                {
                    string userInput = Console.ReadLine();
                    if (forbid.IsMatch(userInput))
                    {
                        throw new Exception("invalid user input");
                    }
                    else if (valid.IsMatch(userInput))
                    {
                        return userInput;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, that input is invalid. Try again!");
                }
            }
            Console.WriteLine("Too many invalid inputs.");
            throw new Exception("too many invalid inputs");
        }

    }
}
