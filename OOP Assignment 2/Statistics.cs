using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace OOP_Assignment_2
{
    internal class Statistics
    {

        //methods
        public void viewStats()
        {
            string[] arr = File.ReadAllLines("SevensOutStats.txt");
            string[] arr2 = File.ReadAllLines("ThreeOrMoreStats.txt");
            Console.WriteLine(" ");
            Console.WriteLine("Statistics:");
            Console.WriteLine(" ");
            Console.WriteLine("Sevens Out Stats:");
            Console.WriteLine(" ");
            Console.WriteLine("High Score:      " + arr[0]);
            Console.WriteLine("Low Score:       " + arr[1]);
            Console.WriteLine("Player 1 Wins:   " + arr[2]);
            Console.WriteLine("Player 2 Wins:   " + arr[3]);
            Console.WriteLine("Longest Streak:  " + arr[4]);
            Console.WriteLine("Shortest Streak: " + arr[5]);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Three Or More Stats:");
            Console.WriteLine(" ");
            Console.WriteLine("Player 1 Wins:   " + arr2[0]);
            Console.WriteLine("Player 2 Wins:   " + arr2[1]);
            returnMenu();
        }

        public void returnMenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Press m to return to main menu");
            if (Console.ReadLine() == "m")
            {
                Game game = new Game();
                game.Start();
            }
            else
            {
                Console.WriteLine("Please Enter a correct value");
                returnMenu();
            }
        }
        //check if high score and update the high score if it is the case
        public void HighScore7Game(int score)
        {
            string[] arr = File.ReadAllLines("SevensOutStats.txt");
            if (score > Int32.Parse(arr[0]))
            {
                arr[0] = score.ToString();
                File.WriteAllLines("SevensOutStats.txt", arr);
            }
        }

        public void LowScore7Game(int score)
        {
            string[] arr = File.ReadAllLines("SevensOutStats.txt");
            if (score < Int32.Parse(arr[1]))
            {
                arr[1] = score.ToString();
                File.WriteAllLines("SevensOutStats.txt", arr);
            }
        }

        //add to win count
        public void Player1WinCountTOM()
        {
            string[] arr = File.ReadAllLines("ThreeOrMoreStats.txt");
            int temp = Int32.Parse(arr[0]);
            temp = temp + 1; 
            arr[0] = temp.ToString();
            File.WriteAllLines("ThreeOrMoreStats.txt", arr);
        }

        public void Player1WinCountSO()
        {
            string[] arr = File.ReadAllLines("SevensOutStats.txt");
            int temp = Int32.Parse(arr[2]);
            temp = temp + 1;
            arr[2] = temp.ToString();
            File.WriteAllLines("SevensOutStats.txt", arr);
        }

        public void Player2WinCountTOM()
        {
            string[] arr = File.ReadAllLines("ThreeOrMoreStats.txt");
            int temp = Int32.Parse(arr[1]);
            temp = temp + 1;
            arr[1] = temp.ToString();
            File.WriteAllLines("ThreeOrMoreStats.txt", arr);
        }

        public void Player2WinCountSO()
        {
            string[] arr = File.ReadAllLines("SevensOutStats.txt");
            int temp = Int32.Parse(arr[3]);
            temp = temp + 1;
            arr[3] = temp.ToString();
            File.WriteAllLines("SevensOutStats.txt", arr);
        }

        //streaks
        public void LongestStreakSO(int count)
        {
            string[] arr = File.ReadAllLines("SevensOutStats.txt");
            if (count < Int32.Parse(arr[4]))
            {
                arr[4] = count.ToString();
                File.WriteAllLines("SevensOutStats.txt", arr);
            }
        }

        public void ShortestStreakSO(int count)
        {
            string[] arr = File.ReadAllLines("SevensOutStats.txt");
            if (count > Int32.Parse(arr[5]))
            {
                arr[5] = count.ToString();
                File.WriteAllLines("SevensOutStats.txt", arr);
            }
        }
    }
}
