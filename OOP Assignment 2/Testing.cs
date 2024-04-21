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
            Thread.Sleep(3000);
            SevensOutTesting();
            Thread.Sleep(500);
            Console.WriteLine("Testing Three Or More Game...");
            Thread.Sleep(3000);
            ThreeOrMoreTesting();
            Thread.Sleep(500);
            Console.WriteLine("Returning To Home Page...");
            Thread.Sleep(2000);
            Game game = new Game(); 
            game.Start();
        }

        public void SevensOutTesting()
        {
            SevensOut sevensOut = new SevensOut();
            testing = true;
            Debug.Assert(sevensOut.AITurn(1) == true, "Test Stop At 7: failed");
            testing = false;
            Console.WriteLine("Testing Complete");
        }

        public void ThreeOrMoreTesting()
        {
            ThreeOrMore threeOrMore = new ThreeOrMore();
            testing = true;
            Debug.Assert(threeOrMore.SwitchPlayer(1) == true, "Test Recognise Winner: failed");
            testing = false;
            Console.WriteLine("Testing Complete");
        }
    }
}
