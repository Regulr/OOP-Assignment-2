using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OOP_Assignment_2
{
    internal class Game
    {
        static void Main(string[] args)
        {
            //call Start Mehtod
            string SevensOutTextPath = Path.Combine(Directory.GetCurrentDirectory(), "SevensOutStats.txt");
            string ThreeOrMoreTextPath = Path.Combine(Directory.GetCurrentDirectory(), "ThreeOrMoreStats.txt");
            Game game = new Game();
            game.Start();
        }

        public void Start() 
        {
            FillTextFiles();
            //choose option between 1-4 
            Console.WriteLine("Please Choose An Option Between 1-4:");
            Console.WriteLine("1: Sevens Out Game");
            Console.WriteLine("2: Three Or More Game");
            Console.WriteLine("3: Statistic");
            Console.WriteLine("4: Testing");

            String choice = "";

            try
            {
                choice = Console.ReadLine();
            }
            catch(IOException)
            { 
                Console.WriteLine("Please Input A Valid Option");
                Start();
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Please Input A Valid Option");
                Start();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Please Input A Valid Option");
                Start();
            }

            // go to appropriate class or method depending on choice
            if (choice == "1")
            {
                SevensOut sevensOut = new SevensOut();
                sevensOut.SevensOutGame();
            }
            else if (choice == "2")
            {
                ThreeOrMore threeOrMore = new ThreeOrMore();
                threeOrMore.ThreeOrMoreGame();
            }
            else if (choice == "3")
            {
                Statistics statistics = new Statistics();
                statistics.viewStats();
            }
            else if (choice == "4")
            {
                Testing testing = new Testing();
            }
            else
            {
                Console.WriteLine("Please Input A Valid Option");
                Start();
            }

        }

        public void Restart(int num)
        {
            //Reset any globals, update statistics and 
            if (num == 0)
            {
                SevensOut sevensOut = new SevensOut();
                sevensOut.SevensOutScoreP1 = 0;
                sevensOut.SevensOutScoreP2 = 0;
                Start();
            }
            else
            {
                ThreeOrMore threeOrMore = new ThreeOrMore();
                threeOrMore.ThreeOrMoreScoreP1 = 0;
                threeOrMore.ThreeOrMoreScoreP2 = 0;
                Start();
            }

        }

        public void FillTextFiles() 
        {
            string SevensOutTextPath = Path.Combine(Directory.GetCurrentDirectory(), "SevensOutStats.txt");
            string ThreeOrMoreTextPath = Path.Combine(Directory.GetCurrentDirectory(), "ThreeOrMoreStats.txt");
            if (!File.Exists(SevensOutTextPath)) 
            {
                string[] arr = ["0", "999", "0", "0", "0", "999"];
                File.WriteAllLines(SevensOutTextPath, arr);
            }
            if (!File.Exists(ThreeOrMoreTextPath))
            {
                string[] arr = ["0", "0"];
                File.WriteAllLines(ThreeOrMoreTextPath, arr);
            }
        }
    }
}
