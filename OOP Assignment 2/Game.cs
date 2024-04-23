using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            //start the game 
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
                choice = Console.ReadLine(); //accept user input
            }
            //catch exceptions related to Console.ReadLine 
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
                sevensOut.SevensOutGame(); //start Sevens Out game 
            }
            else if (choice == "2")
            {
                ThreeOrMore threeOrMore = new ThreeOrMore();
                threeOrMore.ThreeOrMoreGame(); //Start Three Or More game 
            }
            else if (choice == "3")
            {
                Statistics statistics = new Statistics();
                statistics.ViewStats(); //show statistics page 
            }
            else if (choice == "4")
            {
                Testing testing = new Testing();
                testing.TestMethod(); //run all tests 
            }
            else
            {
                Console.WriteLine("Please Input A Valid Option");
                Start(); //rerun the start method when invalid option inputted 
            }

        }

        public void Restart(int num)
        {
            //Completely Unnecessary as do not need to rest the variables but works so dont want to touch 
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
            string SevensOutTextPath = Path.Combine(Directory.GetCurrentDirectory(), "SevensOutStats.txt"); //get local path for SevensOutStats
            string ThreeOrMoreTextPath = Path.Combine(Directory.GetCurrentDirectory(), "ThreeOrMoreStats.txt"); //get local path for ThreeOrMoreStats
            //when either file does not exist write an array to it, creating the file in the process
            if (!File.Exists(SevensOutTextPath)) 
            {
                string[] arr = ["0", "999", "0", "0", "0", "999"]; //array to be written to the file 
                File.WriteAllLines(SevensOutTextPath, arr);
            }
            if (!File.Exists(ThreeOrMoreTextPath))
            {
                string[] arr = ["0", "0"]; //array to be written to the file 
                File.WriteAllLines(ThreeOrMoreTextPath, arr);
            }
        }
    }
}
