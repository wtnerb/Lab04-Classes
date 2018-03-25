using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeConsole
{
    public class Player
    {
        /// <summary>
        /// Player constructor. Will set name and symbol. After creation, those are retrievable but not changable.
        /// </summary>
        /// <param name="name">Player name</param>
        /// <param name="symbol">Player symbol</param>
        public Player(string name, string symbol)
        {
            Name = name;
            if (symbol.Length != 1)
            {
                throw new Exception("Player symbols can only be a single character string");
            }
            Symbol = symbol;
        }
        public string Name { get; private set;}
        public string Symbol { get; private set; }
    }
}
