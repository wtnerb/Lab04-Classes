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
            new string[] { "1", "2", "3" },
            new string[] { "4", "5", "6" },
            new string[] { "7", "8", "9" },
        };

        //Renders a gameboard as a string easily printed to the console
        public string BoardAsString()
        {
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
            Arr[(pos - 1) / 3][(pos - 1) % 3] = symbol;
        }


    }
}
