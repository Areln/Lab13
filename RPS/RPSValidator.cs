using System;
using System.Collections.Generic;
using System.Text;

namespace RPS
{
    class RPSValidator
    {
        public static string GetInput(string message, bool blankSpace = false)
        {
            if (!blankSpace)
            {
                Console.WriteLine(message);
                return Console.ReadLine();
            }
            else
            {
                string input = GetInput(message);
                if (input == "")
                {
                    return GetInput(message, blankSpace);
                }
                else
                {
                    return input;
                }
            }

        }
        public static int ParseIntFromString(string message)
        {
            try
            {
                return int.Parse(GetInput(message));
            }
            catch
            {
                Console.WriteLine("Something went wrong, please try again: ");
                return ParseIntFromString(message);
            }
        }
    }
}
