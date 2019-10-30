using System;
using System.Collections.Generic;
using System.Text;

namespace RPS
{
    class PlayerAI : Player
    {
        public Roshambo Choice { get; set; }

        public PlayerAI(string n) : base(n)
        {

        }
        public PlayerAI(string n, int wins) : base(n, wins)
        {

        }

        public override void generateRoshambo()
        {
            Random r = new Random();
            //Choice = (Roshambo)r.Next(0, 3);
            Choice = Roshambo.Paper;
        }
    }
}
