using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TicTacToeConsole
{
    public class Board
    {
        //Every board starts the same. This will hold the board.
        public string[][] Arr { get; private set; } = new string[][]
        {
            //Tested in CanMakeBoard()
            new string[] { "1", "2", "3" },
            new string[] { "4", "5", "6" },
            new string[] { "7", "8", "9" },
        };

        //Renders a gameboard as a string easily printed to the console
        public string BoardAsString()
        {
            //Tested in CanMakeBoardString()
            StringBuilder sb = new StringBuilder();
            foreach (string[] row in Arr)
            {
                foreach (string cell in row)
                {
                    sb.Append($"|{cell}|");
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
        
        /// <summary>
        /// The only way to update an existing gameboard. It will update the Arr of the board with the provided symbol in the provided place.
        /// </summary>
        /// <param name="pos">the postion, from 1-9, where a change should be made.</param>
        /// <param name="symbol">The symbol to be placed in that position</param>
        public void Update(int pos, string symbol)
        {
            //Tested in CanEditBoard()
            Arr[(pos - 1) / 3][(pos - 1) % 3] = symbol;
        }

        /// <summary>
        /// Will analyze a board to find allowed inputs, returns as a string to be put into a RegEx (additional formatting required)
        /// </summary>
        /// <returns>Allowed moves in string, easy to pass into a RegEx</returns>
        public string AllowedAsString()
        {
            //Tested in CanIdentifyLegalMoves()
            StringBuilder sb = new StringBuilder();
            Regex rx = new Regex("\\d");
            foreach (string[] row in Arr)
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
        /// The logic of each turn. Player will make a move and update the board.
        /// </summary>
        /// <param name="player">the Player whose turn it is</param>
        /// <returns>The Board after the Player has made a move</returns>
        public void Turn(Player player)
        {
            Console.Clear();
            Console.WriteLine($"It is now {player.Name}'s turn.");
            Console.Write(BoardAsString());
            string cell = Program.CollectValidInput("desired square", $"^[{AllowedAsString()}]$", "nothing");
            Update(int.Parse(cell), player.Symbol);
        }
    }
}
