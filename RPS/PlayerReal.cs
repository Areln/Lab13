using System;
using System.Collections.Generic;
using System.Text;

namespace RPS
{
    class PlayerReal : Player
    {
        public Roshambo Choice { get; set; }

        public PlayerReal(string n):base(n) 
        {
        
        }
        public PlayerReal(string n, int wins) : base(n, wins)
        {
        
        }
        public override void generateRoshambo()
        {
            Console.WriteLine();
            try
            {
                int sel = (RPSValidator.ParseIntFromString($"1) Rock\n2) Paper\n3) Scissors")) - 1;
                if (sel > 2 || sel < 0)
                {
                    Console.WriteLine("you did not select a move, try again");
                    generateRoshambo();
                }
                else
                {
                    Choice = (Roshambo)sel;
                }
            }
            catch
            {
                Console.WriteLine("input not recognized");
                generateRoshambo();
            }
        }
    }
}
