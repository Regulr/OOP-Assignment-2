using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_2
{
    internal class SevensOut
    {
        public int SevensOutScoreP1;
        public int SevensOutScoreP2;
        public int Round;

        //methods
        public void SevensOutGame()
        {
            //initialise the game
            Console.WriteLine("Please Choose How Many Rounds You Would Like To Play: ");
            Console.WriteLine("1");
            Console.WriteLine("2");
            Console.WriteLine("3");
            Console.WriteLine("4");

            int player = 1;

            String choice = "";
            try
            {
                choice = Console.ReadLine();
            }
            catch (IOException)
            {
                Console.WriteLine("Please Input A Valid Option");
                SevensOutGame();
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Please Input A Valid Option");
                SevensOutGame();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Please Input A Valid Option");
                SevensOutGame();
            }

            if (Int32.TryParse(choice, out int i) && i<=4 && i>0)
            {
                Round = i;
                Turn(player);
            }
            else
            {
                Console.WriteLine("Please Input A Valid Option");
                SevensOutGame();
            }
        }
        public void Turn(int player)
        {
            //anything relating to the players turn
            Die die = new Die();
            int die1 = 0;
            int die2 = 0;
            while (die1 + die2 != 7)
            {
                Console.WriteLine("Press r to roll the dice");
                if (Console.ReadLine() == "r")
                {
                    die.Roll();
                    die1 = die.DieValue;
                    Console.WriteLine(die1);
                    die.Roll();
                    die2 = die.DieValue;
                    Console.WriteLine(die2);
                    int score = die1 + die2;
                    if (score != 7)
                    {
                        if (player == 1)
                        {
                            SevensOutScoreP1 = SevensOutScoreP1 + score;
                        }
                        else
                        {
                            SevensOutScoreP2 = SevensOutScoreP2 + score;
                        }
                    }
                    else
                    {
                        if (player == 1)
                        {
                            Console.WriteLine("Your Current Score is " + SevensOutScoreP1);
                        }
                        else
                        {
                            Console.WriteLine("Your Current Score is " + SevensOutScoreP2);
                        }
                        SwitchPLayer(player);
                    }
                }
                else
                {
                    Turn(player);
                }
            }

        }

        public void SwitchPLayer(int player)
        {
            //switching which players turn it is 
            if (player == 1) 
            {
                player = 2;
            }
            else
            {
                player = 1;
                if(Round > 1)
                {
                    Round--;
                }
                else
                {
                    Winner();
                }
            }

            Console.WriteLine("Current Player: Player " + player);
            Turn(player);
        }

        public void Winner()
        {
            if (SevensOutScoreP1 > SevensOutScoreP2)
            {
                Console.WriteLine("Player 1 Wins With " + SevensOutScoreP1 + "Points!");
            }
            else if (SevensOutScoreP1 < SevensOutScoreP2)
            {
                Console.WriteLine("Player 2 Wins With " + SevensOutScoreP2 + "Points!");
            }
            else
            {
                Console.WriteLine("Its a Draw!");
            }

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
                game.Restart();
            }
            else if(inp == "r")
            {
                SevensOutScoreP1 = 0;
                SevensOutScoreP2 = 0;
                SevensOutGame();
            }
            else
            {
                Console.WriteLine("Please Input a Valid Option");
                EndGame();
            }
        }
    }
}
