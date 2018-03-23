using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeTest
{
    public class Player
    {
        public Player(string name, string symbol)
        {
            Name = name;
            if (symbol.Length != 1)
            {
                throw new Exception("Player symbols can only be a single character");
            }
            Symbol = symbol;
        }
        public string Name { get; private set;}
        public string Symbol { get; private set; }
    }
}
