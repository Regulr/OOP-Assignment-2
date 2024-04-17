using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_2
{
    internal class ThreeOrMore
    {
        public int ThreeOrMoreScoreP1;
        public int ThreeOrMoreScoreP2;
        public bool AI = false;
        Die die = new Die();
        //methods 
        public void ThreeOrMoreGame() 
        {
            Console.WriteLine("How many players?: ");
            Console.WriteLine("1. One Player");
            Console.WriteLine("2. Two Players");

            String choice = "";
            try
            {
                choice = Console.ReadLine();
            }
            catch (IOException)
            {
                Console.WriteLine("Please Input A Valid Option");
                ThreeOrMoreGame();
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Please Input A Valid Option");
                ThreeOrMoreGame();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Please Input A Valid Option");
                ThreeOrMoreGame();
            }

            if (Int32.TryParse(choice, out int i) && i == 1)
            {
                AI = true;
            }
            else if (Int32.TryParse(choice, out int j) && j == 2)
            {
                AI = false;
            }
            else
            {
                Console.WriteLine("Please Input A Valid Option");
                ThreeOrMoreGame();
            }

            //initialise the game 
            int player = 1;
            Console.WriteLine("Player Ones Turn: ");
            Turn(player);
        }

        public void Turn(int player)
        {
            Console.WriteLine("Press p to take your turn: ");

            if (Console.ReadLine() == "p")
            {
                //array of 5 values 
                int[] dieValues = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    die.Roll();
                    Console.WriteLine(die.DieValue);
                    dieValues[i] = die.DieValue;
                }

                //check for any sets 
                int count = 0;
                for (int i = 0; i < dieValues.Length; i++)
                {
                    if (dieValues[0] == dieValues[i])
                    {
                        count++;
                    }
                }
                if (count < 5)
                {
                    count = 0;
                    for (int i = 0; i < dieValues.Length; i++)
                    {
                        if (dieValues[1] == dieValues[i])
                        {
                            count++;
                        }
                    }

                    if (count < 4)
                    {
                        count = 0;
                        for (int i = 0; i < dieValues.Length; i++)
                        {
                            if (dieValues[2] == dieValues[i])
                            {
                                count++;
                            }
                        }

                        if (count < 3)
                        {
                            count = 0;
                            for (int i = 0; i < dieValues.Length; i++)
                            {
                                if (dieValues[3] == dieValues[i])
                                {
                                    count++;
                                }
                            }
                        }
                    }

                }

                //award points accordingly
                if (player == 1)
                {
                    if (count == 5)
                    {
                        Console.WriteLine("You got a 5 of a kind!");
                        ThreeOrMoreScoreP1 = ThreeOrMoreScoreP1 + 12;
                        Console.WriteLine("Your current score is " + ThreeOrMoreScoreP1);
                        SwitchPlayer(player);
                    }
                    else if (count == 4)
                    {
                        Console.WriteLine("You got a 4 of a kind!");
                        ThreeOrMoreScoreP1 = ThreeOrMoreScoreP1 + 6;
                        Console.WriteLine("Your current score is " + ThreeOrMoreScoreP1);
                        SwitchPlayer(player);
                    }
                    else if (count == 3)
                    {
                        Console.WriteLine("You got a 3 of a kind!");
                        ThreeOrMoreScoreP1 = ThreeOrMoreScoreP1 + 3;
                        Console.WriteLine("Your current score is " + ThreeOrMoreScoreP1);
                        SwitchPlayer(player);
                    }
                    else if (count == 2)
                    {
                        Console.WriteLine("You got a 2 of a kind!");
                        Console.WriteLine("Have another roll");
                        Turn(player);
                    }
                    else
                    {
                        Console.WriteLine("Nothing!");
                        Console.WriteLine("Your current score is " + ThreeOrMoreScoreP1);
                        SwitchPlayer(player);
                    }
                }
                else
                {
                    if (count == 5)
                    {
                        Console.WriteLine("You got a 5 of a kind!");
                        ThreeOrMoreScoreP2 = ThreeOrMoreScoreP2 + 12;
                        Console.WriteLine("Your current score is " + ThreeOrMoreScoreP2);
                        SwitchPlayer(player);
                    }
                    else if (count == 4)
                    {
                        Console.WriteLine("You got a 4 of a kind!");
                        ThreeOrMoreScoreP2 = ThreeOrMoreScoreP2 + 6;
                        Console.WriteLine("Your current score is " + ThreeOrMoreScoreP2);
                        SwitchPlayer(player);
                    }
                    else if (count == 3)
                    {
                        Console.WriteLine("You got a 3 of a kind!");
                        ThreeOrMoreScoreP2 = ThreeOrMoreScoreP2 + 3;
                        Console.WriteLine("Your current score is " + ThreeOrMoreScoreP2);
                        SwitchPlayer(player);
                    }
                    else if (count == 2)
                    {
                        Console.WriteLine("You got a 2 of a kind!");
                        Console.WriteLine("Have another roll");
                        Turn(player);
                    }
                    else
                    {
                        Console.WriteLine("Nothing!");
                        Console.WriteLine("Your current score is " + ThreeOrMoreScoreP2);
                        SwitchPlayer(player);
                    }
                }
            }
            else
            {
                Turn(player);
            }
        }

        public void SwitchPlayer(int player)
        {
            Statistics statistics = new Statistics();
            //change the current player
            if(player == 1)
            {
                if (ThreeOrMoreScoreP1 >= 20)
                {
                    statistics.Player1WinCountTOM();
                    Winner("One");
                }
                Console.WriteLine("Player Twos Turn: ");
                player = player +1;
                Turn(player);
            }
            else
            {
                if (ThreeOrMoreScoreP2 >= 20)
                {
                    if(AI == false) 
                    {
                        statistics.Player2WinCountTOM();
                    }
                    Winner("Two");
                }
                Console.WriteLine("Player Ones Turn: ");
                player = player -1;
                if (AI == false)
                {
                    Turn(player);
                }
                else 
                { 
                    AITurn(player);
                }
            }
        }

        public void Winner(string num)
        {
            Console.WriteLine("Player " + num + " Wins!");
            EndGame();
        }

        public void EndGame()
        {
            Console.WriteLine("Press m to go to the main menu or r to play this game again");

            String inp = "";

            try
            {
                inp = Console.ReadLine();
            }
            catch (IOException)
            {
                Console.WriteLine("Please Input A Valid Option");
                EndGame();
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Please Input A Valid Option");
                EndGame();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Please Input A Valid Option");
                EndGame();
            }

            if (inp == "m")
            {
                Game game = new Game();
                game.Restart(0);
            }
            else if (inp == "r")
            {
                ThreeOrMoreScoreP1 = 0;
                ThreeOrMoreScoreP2 = 0;
                ThreeOrMoreGame();
            }
            else
            {
                Console.WriteLine("Please Input a Valid Option");
                EndGame();
            }
        }

        public void AITurn(int player)
        {
            //array of 5 values 
            int[] dieValues = new int[5];
            for (int i = 0; i < 5; i++)
            {
                die.Roll();
                Console.WriteLine(die.DieValue);
                dieValues[i] = die.DieValue;
            }

            //check for any sets 
            int count = 0;
            for (int i = 0; i < dieValues.Length; i++)
            {
                if (dieValues[0] == dieValues[i])
                {
                    count++;
                }
            }
            if (count < 5)
            {
                count = 0;
                for (int i = 0; i < dieValues.Length; i++)
                {
                    if (dieValues[1] == dieValues[i])
                    {
                        count++;
                    }
                }

                if (count < 4)
                {
                    count = 0;
                    for (int i = 0; i < dieValues.Length; i++)
                    {
                        if (dieValues[2] == dieValues[i])
                        {
                            count++;
                        }
                    }

                    if (count < 3)
                    {
                        count = 0;
                        for (int i = 0; i < dieValues.Length; i++)
                        {
                            if (dieValues[3] == dieValues[i])
                            {
                                count++;
                            }
                        }
                    }
                }

            }

            //award points accordingly
            if (player == 1)
            {
                if (count == 5)
                {
                    Console.WriteLine("You got a 5 of a kind!");
                    ThreeOrMoreScoreP1 = ThreeOrMoreScoreP1 + 12;
                    Console.WriteLine("Your current score is " + ThreeOrMoreScoreP1);
                    SwitchPlayer(player);
                }
                else if (count == 4)
                {
                    Console.WriteLine("You got a 4 of a kind!");
                    ThreeOrMoreScoreP1 = ThreeOrMoreScoreP1 + 6;
                    Console.WriteLine("Your current score is " + ThreeOrMoreScoreP1);
                    SwitchPlayer(player);
                }
                else if (count == 3)
                {
                    Console.WriteLine("You got a 3 of a kind!");
                    ThreeOrMoreScoreP1 = ThreeOrMoreScoreP1 + 3;
                    Console.WriteLine("Your current score is " + ThreeOrMoreScoreP1);
                    SwitchPlayer(player);
                }
                else if (count == 2)
                {
                    Console.WriteLine("You got a 2 of a kind!");
                    Console.WriteLine("Have another roll");
                    Turn(player);
                }
                else
                {
                    Console.WriteLine("Nothing!");
                    Console.WriteLine("Your current score is " + ThreeOrMoreScoreP1);
                    SwitchPlayer(player);
                }
            }
            else
            {
                if (count == 5)
                {
                    Console.WriteLine("You got a 5 of a kind!");
                    ThreeOrMoreScoreP2 = ThreeOrMoreScoreP2 + 12;
                    Console.WriteLine("Your current score is " + ThreeOrMoreScoreP2);
                    SwitchPlayer(player);
                }
                else if (count == 4)
                {
                    Console.WriteLine("You got a 4 of a kind!");
                    ThreeOrMoreScoreP2 = ThreeOrMoreScoreP2 + 6;
                    Console.WriteLine("Your current score is " + ThreeOrMoreScoreP2);
                    SwitchPlayer(player);
                }
                else if (count == 3)
                {
                    Console.WriteLine("You got a 3 of a kind!");
                    ThreeOrMoreScoreP2 = ThreeOrMoreScoreP2 + 3;
                    Console.WriteLine("Your current score is " + ThreeOrMoreScoreP2);
                    SwitchPlayer(player);
                }
                else if (count == 2)
                {
                    Console.WriteLine("You got a 2 of a kind!");
                    Console.WriteLine("Have another roll");
                    Turn(player);
                }
                else
                {
                    Console.WriteLine("Nothing!");
                    Console.WriteLine("Your current score is " + ThreeOrMoreScoreP2);
                    SwitchPlayer(player);
                }
            }
        }
    }
}
