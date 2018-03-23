using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeConsole
{
    public class Board
    {
        public string[][] Arr { get; set; } = new string[][]
        {
            new string[] { "1", "2", "3" },
            new string[] { "4", "5", "6" },
            new string[] { "7", "8", "9" },
        };

        public string BoardAsString(string[][] array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string[] row in array)
            {
                foreach (string cell in row)
                {
                    sb.Append($"|{cell}|");
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}
