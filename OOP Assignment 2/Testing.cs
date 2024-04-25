using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_2
{
    internal class Testing
    {
        public static bool testing = false;
        public static bool testing2 = false;
        //Methods
        public void TestMethod()
        {
            Console.WriteLine("Testing Sevens Out Game...");
            Thread.Sleep(3000); //wait inbetween tests for better user experience 
            SevensOutTesting();
            Thread.Sleep(500);
            Console.WriteLine("Testing Three Or More Game...");
            Thread.Sleep(3000);
            ThreeOrMoreTesting();
            Thread.Sleep(500);
            Console.WriteLine("Testing Dice Roll...");
            Thread.Sleep(3000);
            DieTesting();
            Thread.Sleep(500);
            Console.WriteLine("Returning To Home Page...");
            Thread.Sleep(2000); //give user times to read results 
            //go back to the main menu
            Game game = new Game(); 
            game.Start();
        }

        public void SevensOutTesting()
        {
            SevensOut sevensOut = new SevensOut();
            testing = true; //enables testing only aspects and disables other aspects
            Debug.Assert(sevensOut.AITurn(1) == true, "Test Stop At 7: failed"); //check that round finishes when 7 is scored 
            testing = false; //disables testing so game can be played normally
            Console.WriteLine("Testing Complete");
        }

        public void ThreeOrMoreTesting()
        {
            ThreeOrMore threeOrMore = new ThreeOrMore();
            testing = true; //enables testing only aspects and disables other aspects
            Debug.Assert(threeOrMore.SwitchPlayer(1) == true, "Test Recognise Winner: failed"); //check that when one player has a score of 20 
            testing = false; //disables testing so game can be played normally
            Console.WriteLine("Testing Complete");
        }

        public void DieTesting()
        {
            Die die = new Die();
            Debug.Assert(die.Roll() > 0 && die.Roll() < 7, "Test Die Roll: failed"); //check that dice roll gives a number between 1-6
            Console.WriteLine("Testing Complete");
        }
    }
}
