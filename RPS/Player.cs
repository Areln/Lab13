using System;
using System.Collections.Generic;
using System.Text;

namespace RPS
{
    abstract class Player
    {
        public string Name { get; set; }
        //public bool IsAI { get; set; }
        public int Wins { get; set; }

        public Player(string name)
        {
            Name = name;
            Wins = 0;
        }
        public Player(string name, int wins)
        {
            Name = name;
            Wins = wins;
        }
        public abstract void generateRoshambo();
    }
}
