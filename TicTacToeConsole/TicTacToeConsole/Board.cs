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

        public void Update(int pos, string symbol)
        {
            Arr[(int)(pos - 1) / 3][(pos - 1) % 3] = symbol;
        }

        
    }
}
