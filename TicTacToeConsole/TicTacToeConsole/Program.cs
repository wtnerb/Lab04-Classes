using System;
using System.Text.RegularExpressions;
using TicTacToeConsole;
using System.Text;

namespace TicTacToeConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Welcome to Brent's TicTacToe. To start the game ...");
            Console.Write("Player 1,");
            string validNameRx = "^\\w+$";
            string validLetter = "^[A-Z]$";
            string name = CollectValidInput("Player 1's name.", validNameRx, "Nothing is forbidden to player1");
            Console.WriteLine("Valid symbols are any capital letter.");
            string sym = CollectValidInput("Player 1's symbol", validLetter, "aa");
            Player player1 = new Player(name, sym);
            Console.Clear();
            Console.WriteLine($"Thank you {player1.Name}, now press any key to set up player 2");
            Console.ReadKey();
            name = CollectValidInput("Player 2's name.", validNameRx, $"^{player1.Name}$");
            sym = CollectValidInput("Player 2's symbol", validLetter, $"^{player1.Symbol}$");
            Player player2 = new Player(name, sym);
            Console.Clear();
            Console.WriteLine("Thank you both! The game is ready to begin.");
            PlayGame(player1, player2);
            Console.ReadKey();
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
                || (board[0][2] == board[1][1] && board[1][1] == board[2][0])) //diag incling top right
            {
                return true;
            }
            return false;
        }

        public static string CollectValidInput(string prompt, string allowed, string forbid)
        {
            byte count = 0;
            Regex valid = new Regex(allowed);
            Regex forbidden = new Regex(forbid);
            while (count < 8)
            {
                Console.WriteLine($"Please provide {prompt}");
                count++;
                try
                {
                    string userInput = Console.ReadLine();
                    if (forbidden.IsMatch(userInput))
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
                    Console.WriteLine("Sorry, that input is invalid. Try again!");
                }
            }
            Console.WriteLine("Too many invalid inputs.");
            throw new Exception("too many invalid inputs");
        }

        public static Board Turn(Board board, Player player)
        {
            Console.Clear();
            Console.WriteLine($"It is now {player.Name}'s turn.");
            Console.Write(board.BoardAsString());
            string cell = CollectValidInput("desired square", $"^[{AllowedAsString(board.Arr)}]$", "nothing");
            board.Update(int.Parse(cell), player.Symbol);
            return board;
        }

        public static string AllowedAsString(string[][] array)
        {
            StringBuilder sb = new StringBuilder();
            Regex rx = new Regex("\\d");
            foreach (string[] row in array)
            {
                foreach (string cell in row)
                {
                    if (rx.IsMatch(cell))
                    {
                        sb.Append(cell);
                    }
                }
            }
            return sb.ToString();
        }

        public static void PlayGame(Player p1, Player p2)
        {
            Console.Clear();
            Board board = new Board();
            for (byte i = 0; i < 9; i++)
            {
                Player current = (i % 2 == 0) ? p1 : p2;
                board = Turn(board, current);
                if (IsWin(board.Arr))
                {
                    Console.WriteLine($"{current.Name} Wins!");
                    return;
                }
            }
            Console.WriteLine("Draw!");
        }

    }
}
