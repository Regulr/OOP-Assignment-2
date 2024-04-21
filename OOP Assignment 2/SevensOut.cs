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
        public bool AI = false;

        //methods
        public void SevensOutGame()
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

            if (Int32.TryParse(choice, out int i) && i == 1)
            {
                AI = true;
                RoundAmount();
            }
            else if(Int32.TryParse(choice, out int j) && j == 2)
            {
                AI = false;               
                RoundAmount();
            }
            else
            {
                Console.WriteLine("Please Input A Valid Option");
                SevensOutGame();
            }
        }

        public void RoundAmount() 
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

            if (Int32.TryParse(choice, out int i) && i <= 4 && i > 0)
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
            int count = 0;
            Die die = new Die();
            Statistics statistics = new Statistics();
            int die1 = 0;
            int die2 = 0;
            while (die1 + die2 != 7)
            {
                Console.WriteLine("Press r to roll the dice");
                if (Console.ReadLine() == "r")
                {
                    count++;
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
                            SevensOutScoreP1 = SevensOutScoreP1 + score;
                            Console.WriteLine("Your Current Score is " + SevensOutScoreP1);
                        }
                        else
                        {
                            SevensOutScoreP2 = SevensOutScoreP2 + score;
                            Console.WriteLine("Your Current Score is " + SevensOutScoreP2);
                        }
                        statistics.ShortestStreakSO(count);
                        statistics.LongestStreakSO(count);
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
                player = player + 1;
            }
            else
            {
                player = player - 1;
                if (Round > 1)
                {
                    Round--;
                }
                else
                {
                    Winner();
                }
            }

            Console.WriteLine("Current Player: Player " + player);
            if(AI == false)
            {
                Turn(player);
            }
            else
            {
                AITurn(player);
            }
        }

        public void Winner()
        {
            Statistics statistics = new Statistics();
            if (SevensOutScoreP1 > SevensOutScoreP2)
            {
                statistics.HighScore7Game(SevensOutScoreP1);
                if(AI == false)
                {
                    statistics.LowScore7Game(SevensOutScoreP2);
                }
                statistics.Player1WinCountSO();
                Console.WriteLine("Player 1 Wins With " + SevensOutScoreP1 + " Points!");
            }
            else if (SevensOutScoreP1 < SevensOutScoreP2)
            {
                if (AI == false)
                {
                    statistics.LowScore7Game(SevensOutScoreP2);
                }
                statistics.LowScore7Game(SevensOutScoreP1);
                statistics.Player2WinCountSO();
                Console.WriteLine("Player 2 Wins With " + SevensOutScoreP2 + " Points!");
            }
            else
            {
                statistics.HighScore7Game(SevensOutScoreP1);
                statistics.LowScore7Game(SevensOutScoreP1);
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
                game.Restart(0);
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

        public bool AITurn(int player)
        {
            int count = 0;
            Die die = new Die();
            Statistics statistics = new Statistics();
            int die1 = 0;
            int die2 = 0;
            while (die1 + die2 != 7)
            {
                int score = 7;
                if (Testing.testing == false)
                {
                    count++;
                    die.Roll();
                    die1 = die.DieValue;
                    Console.WriteLine(die1);
                    die.Roll();
                    die2 = die.DieValue;
                    Console.WriteLine(die2);
                    score = die1 + die2;
                }   
                if (score != 7)
                {
                    if (Testing.testing == true)
                    {
                        return false;
                    }
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
                    if(Testing.testing == true)
                    {
                        return true;
                    }
                    if (player == 1)
                    {
                        SevensOutScoreP1 = SevensOutScoreP1 + score;
                        Console.WriteLine("Your Current Score is " + SevensOutScoreP1);
                    }
                    else
                    {
                        SevensOutScoreP2 = SevensOutScoreP2 + score;
                        Console.WriteLine("Your Current Score is " + SevensOutScoreP2);
                    }
                    SwitchPLayer(player);
                }                   
            }
            return false;
        }
    }
}
