using System;
using System.Collections.Generic;
using System.IO;

namespace RPS
{
    public enum Roshambo { Rock, Paper, Scissors }

    class RoshamboApp
    {
        public static string path = "../../../PlayerData.txt";
        static string runAgain = "y";
        public static Dictionary<string ,Player> players = new Dictionary<string, Player>();
        public static PlayerReal selectedPlayer;
        public static PlayerAI selectedOpponent;
        static void Main(string[] args)
        {
            //initial data read
            ReadData();
            //login
            UserLogin();
            //get opponent
            SelectOpponent();
            //loops the whole program
            while (runAgain != "n")
            {
                DetermineWinner(selectedPlayer, selectedOpponent);
                SaveData();
                Rerun();
            }
        }
        static void DetermineWinner(PlayerReal player1, PlayerAI player2) 
        {
            player1.generateRoshambo();
            player2.generateRoshambo();
            Console.WriteLine($"{player1.Name} played {player1.Choice}\n{player2.Name} played {player2.Choice}");
            if (player1.Choice == player2.Choice)
            {
                Console.WriteLine("TIE ROUND!");
            }
            else if (player1.Choice == Roshambo.Paper)
            {
                if (player2.Choice == Roshambo.Rock)
                {
                    player1.Wins++;
                    Console.WriteLine($"\n{player1.Name} Won!");
                }
                else
                {
                    player2.Wins++;
                    Console.WriteLine($"\n{player2.Name} Won!");
                }
            }
            else if (player1.Choice == Roshambo.Rock)
            {
                if (player2.Choice == Roshambo.Scissors)
                {
                    player1.Wins++;
                    Console.WriteLine($"\n{player1.Name} Won!");
                }
                else
                {
                    player2.Wins++;
                    Console.WriteLine($"\n{player2.Name} Won!");
                }
            }
            else if(player1.Choice == Roshambo.Scissors)
            {
                if (player2.Choice == Roshambo.Paper)
                {
                    player1.Wins++;
                    Console.WriteLine($"\n{player1.Name} Won!");
                }
                else
                {
                    player2.Wins++;
                    Console.WriteLine($"\n{player2.Name} Won!");
                }
            }
            Console.WriteLine($"{player1.Wins} | {player2.Wins}");
        }
        static void SelectOpponent()
        {
            Console.WriteLine();
            foreach (string item in players.Keys)
            {
                if (item != selectedPlayer.Name)
                {
                    Console.WriteLine(item);
                }
            }
            string sel = RPSValidator.GetInput("Select your Opponent", true);
            PlayerReal temp = (PlayerReal)players.GetValueOrDefault(sel);
            selectedOpponent = new PlayerAI(temp.Name, temp.Wins);
            Console.WriteLine($"Existing Player: {selectedOpponent.Name} | {selectedOpponent.Wins}");
        }
        static void UserLogin() 
        {
            string user = RPSValidator.GetInput("Welcome, please enter your name: ", true);
            if (players.ContainsKey(user))
            {
                selectedPlayer = (PlayerReal)players.GetValueOrDefault(user);
                Console.WriteLine($"Existing Player: {selectedPlayer.Name} | {selectedPlayer.Wins}");
            }
            else
            {
                Console.WriteLine("New Player");
                players.Add(user, new PlayerReal(user));
                selectedPlayer = (PlayerReal)players.GetValueOrDefault(user);
                SaveData();
            }
        }
        static void Rerun()
        {
            Console.WriteLine("Run Again?(y/n): ");
            runAgain = Console.ReadLine();
        }

        static void ReadData()
        {
            StreamReader reader = new StreamReader(path);
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] lines = line.Split(',');
                players.Add(lines[0],new PlayerReal(lines[0], int.Parse(lines[1])));
                Console.WriteLine($"Loaded: {lines[0]}, {lines[1]}");
                line = reader.ReadLine();
            }
            reader.Close();
        }
        static void SaveData()
        {
            if (selectedOpponent != null)
            {
                players.GetValueOrDefault(selectedOpponent.Name).Wins = selectedOpponent.Wins;
            }
            StreamWriter writer = new StreamWriter(path);
            foreach (KeyValuePair<string,Player> player in players)
            {
                writer.WriteLine($"{player.Value.Name},{player.Value.Wins}");
            }
            writer.Close();
            Console.WriteLine("Data Saved!");
        }
    }
}
