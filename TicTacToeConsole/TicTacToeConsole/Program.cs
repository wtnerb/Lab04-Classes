using System;
using System.Text.RegularExpressions;
using TicTacToeConsole;
using System.Text;

namespace TicTacToeConsole
{
    public class Program
    {
        /// <summary>
        /// Sets up game, runs game function, pauses at end so user can read the game end before the app exists
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Welcome to Brent's TicTacToe. To start the game ...");
            //Names can be one word long. This will be passed into a RegEx later.
            string validNameRx = "^\\w+$";
            //Only a single, capital letter can be the symbol. This will be passed into a RegEx later.
            string validLetter = "^[A-Z]$";
            string name = CollectValidInput("Player 1's name.", validNameRx, "Nothing is forbidden to player1");
            Console.WriteLine("Valid symbols are any capital letter.");
            string sym = CollectValidInput("Player 1's symbol", validLetter, "aa");
            Player player1 = new Player(name, sym);
            Console.Clear();
            Console.WriteLine($"Thank you {player1.Name}, now press any key to set up player 2");
            Console.ReadKey();
            //Same logic as above, but player1's name and symbol are forbidden to player2
            name = CollectValidInput("Player 2's name.", validNameRx, $"^{player1.Name}$");
            sym = CollectValidInput("Player 2's symbol", validLetter, $"^{player1.Symbol}$");
            Player player2 = new Player(name, sym);
            Console.Clear();
            Console.WriteLine("Thank you both! The game is ready to begin.");
            PlayGame(player1, player2);
            Console.ReadKey();
        }

        /// <summary>
        /// Checks to see if there is a win on the board.
        /// </summary>
        /// <param name="board">Board represented as a jagged array</param>
        /// <returns>true if win is found, false otherwise</returns>
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

        /// <summary>
        /// Will prompt the user for input, validate that it is allowed, and validate that it is not forbidden.
        /// </summary>
        /// <param name="prompt">Complete the sentence "Please provide "</param>
        /// <param name="allowed">A string of a RegEx of allowed inputs</param>
        /// <param name="forbid">A string of a Regex of forbidden inputs within the allowed space</param>
        /// <returns>a valid input or an app breaking exception if too many invalid inputs are provided</returns>
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

        /// <summary>
        /// The logic of each turn. Player will make a move and update the board.
        /// </summary>
        /// <param name="board">the Board the game is being played upon</param>
        /// <param name="player">the Player whose turn it is</param>
        /// <returns>The Board after the Player has made a move</returns>
        public static Board Turn(Board board, Player player)
        {
            Console.Clear();
            Console.WriteLine($"It is now {player.Name}'s turn.");
            Console.Write(board.BoardAsString());
            string cell = CollectValidInput("desired square", $"^[{AllowedAsString(board)}]$", "nothing");
            board.Update(int.Parse(cell), player.Symbol);
            return board;
        }

        /// <summary>
        /// Will analyze a board to find allowed inputs, returns as a string to be put into a RegEx (additional formatting required)
        /// </summary>
        /// <param name="board">The board as it is</param>
        /// <returns>Allowed moves in string, easy to pass into a RegEx</returns>
        public static string AllowedAsString(Board board)
        {
            StringBuilder sb = new StringBuilder();
            Regex rx = new Regex("\\d");
            foreach (string[] row in board.Arr)
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

        /// <summary>
        /// p1 and p2 play TTT until one or the other wins OR 9 moves have been made without a win and there is a draw.
        /// </summary>
        /// <param name="p1">Player 1</param>
        /// <param name="p2">Player 2</param>
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
            Console.Clear();
            Console.Write(board.BoardAsString());
            Console.WriteLine("Draw!");
        }

    }
}
