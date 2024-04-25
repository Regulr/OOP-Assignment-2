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
            //display options 
            Console.WriteLine("How many players?: ");
            Console.WriteLine("1. One Player");
            Console.WriteLine("2. Two Players");

            String choice = "";
            try
            {
                choice = Console.ReadLine(); //accept user input 
            }
            //catch exceptions related to Console.ReadLine
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
            //if oneplayer then use AI player
            if (Int32.TryParse(choice, out int i) && i == 1)
            {
                AI = true;
            }
            //if two player disable AI player
            else if (Int32.TryParse(choice, out int j) && j == 2)
            {
                AI = false;
            }
            else
            {
                Console.WriteLine("Please Input A Valid Option");
                ThreeOrMoreGame(); //recall method
            }

            //initialise the game 
            int player = 1;
            Console.WriteLine("Player Ones Turn: ");
            Turn(player);
        }

        public void Turn(int player)
        {
            Console.WriteLine("Press p to take your turn: ");

            if (Console.ReadLine() == "p") //accept user input 
            {
                //array of 5 values 
                int[] dieValues = new int[5];
                for (int i = 0; i < 5; i++) //get 5 values to fill array 
                {
                    die.Roll(); //roll dice for random number 
                    Console.WriteLine(die.DieValue);
                    dieValues[i] = die.DieValue; //add number to array 
                }

                //check for any sets 
                int count = 0;
                for (int i = 0; i < dieValues.Length; i++) //look for 5 of a kind 
                {
                    if (dieValues[0] == dieValues[i])
                    {
                        count++; //add to the count when numbers are the same 
                    }
                }
                if (count < 5) //if not all are the same look for 4 of a kind 
                {
                    count = 0;
                    for (int i = 0; i < dieValues.Length; i++)
                    {
                        if (dieValues[1] == dieValues[i])
                        {
                            count++;
                        }
                    }

                    if (count < 4) //check for 3 of a kind 
                    {
                        count = 0;
                        for (int i = 0; i < dieValues.Length; i++)
                        {
                            if (dieValues[2] == dieValues[i])
                            {
                                count++;
                            }
                        }

                        if (count < 3) //check for a 2 ofa  kind 
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
                    if (count == 5) //when count is 5 
                    {
                        Console.WriteLine("You got a 5 of a kind!");
                        ThreeOrMoreScoreP1 = ThreeOrMoreScoreP1 + 12; //add 12 points to the score 
                        Console.WriteLine("Your current score is " + ThreeOrMoreScoreP1);
                        SwitchPlayer(player);
                    }
                    else if (count == 4) //when count is 4
                    {
                        Console.WriteLine("You got a 4 of a kind!");
                        ThreeOrMoreScoreP1 = ThreeOrMoreScoreP1 + 6; //add 6 points to the score
                        Console.WriteLine("Your current score is " + ThreeOrMoreScoreP1);
                        SwitchPlayer(player);
                    }
                    else if (count == 3) //when count is 3
                    {
                        Console.WriteLine("You got a 3 of a kind!");
                        ThreeOrMoreScoreP1 = ThreeOrMoreScoreP1 + 3; //add 3 points to the score 
                        Console.WriteLine("Your current score is " + ThreeOrMoreScoreP1);
                        SwitchPlayer(player);
                    }
                    else if (count == 2) //when count is 2
                    {
                        //player gets another go 
                        Console.WriteLine("You got a 2 of a kind!");
                        Console.WriteLine("Have another roll");
                        Turn(player);
                    }
                    else //when count is 1
                    {
                        //no points switch player 
                        Console.WriteLine("Nothing!");
                        Console.WriteLine("Your current score is " + ThreeOrMoreScoreP1);
                        SwitchPlayer(player);
                    }
                }
                else //same stuff as player 1 but for player 2 
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
                Turn(player); //when users input is not valid recall method 
            }
        }

        public bool SwitchPlayer(int player)
        {
            Statistics statistics = new Statistics();
            //change the current player
            if(player == 1)
            {
                if(Testing.testing == true)
                {
                    ThreeOrMoreScoreP1 = 20; //set the score to 20 for testing purposes 
                }
                if (ThreeOrMoreScoreP1 >= 20) //when winning score reached 
                {
                    if (Testing.testing == true)
                    {
                        ThreeOrMoreScoreP1 = 0;
                        return true; //passing the test 
                    }
                    statistics.Player1WinCountTOM(); //add to win count 
                    Winner("One");
                }
                Console.WriteLine("Player Twos Turn: ");
                player = player +1; //switch to player 2
                Turn(player);
            }
            else
            {
                if (ThreeOrMoreScoreP2 >= 20)
                {
                    if(AI == false) 
                    {
                        statistics.Player2WinCountTOM(); //when no ai add to plaer2s win count 
                    }
                    Winner("Two");
                }
                Console.WriteLine("Player Ones Turn: ");
                player = player -1; //switch to player 1
                if (AI == false)
                {
                    Turn(player); //player 2 is a human 
                }
                else 
                { 
                    AITurn(player); //player 2 is not a human
                }
            }
            return false;
        }

        public void Winner(string player)
        {
            Console.WriteLine("Player " + player + " Wins!"); 
            EndGame(); //finish the game 
        }

        public void EndGame()
        {
            Console.WriteLine("Press m to go to the main menu or r to play this game again");

            String inp = "";

            try
            {
                inp = Console.ReadLine(); //accept user input 
            }
            //catch exceptions related to Console.ReadLine
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
            //go back to main menu 
            if (inp == "m")
            {
                Game game = new Game();
                game.Restart(0);
            }
            //restart the ThreeOrMore game 
            else if (inp == "r")
            {
                ThreeOrMoreScoreP1 = 0;
                ThreeOrMoreScoreP2 = 0;
                ThreeOrMoreGame();
            }
            else
            {
                Console.WriteLine("Please Input a Valid Option");
                EndGame(); //recall method when user inputs incorrect value 
            }
        }

        //same as normal turn but without user inputs 
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
