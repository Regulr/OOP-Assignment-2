using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_2
{
    internal class SevensOut: Game
    {
        public int SevensOutScoreP1;
        public int SevensOutScoreP2;
        public int Round;
        public bool AI = false;

        //methods
        public void SevensOutGame()
        {
            //choose option between 1-2
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
            //play singleplayer 
            if (Int32.TryParse(choice, out int i) && i == 1)
            {
                AI = true;
                RoundAmount();
            }
            //play 2 player 
            else if(Int32.TryParse(choice, out int j) && j == 2)
            {
                AI = false;               
                RoundAmount();
            }
            //input invalid recall method 
            else
            {
                Console.WriteLine("Please Input A Valid Option");
                SevensOutGame();
            }
        }

        public void RoundAmount() 
        {
            //choose an option between 1-4
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
            //catch exceptions related to Console.ReadLine
            catch (IOException)
            {
                Console.WriteLine("Please Input A Valid Option");
                RoundAmount();
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Please Input A Valid Option");
                RoundAmount();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Please Input A Valid Option");
                RoundAmount();
            }
            //when choice is an int within accepted parameters set that to be number of rounds 
            if (Int32.TryParse(choice, out int i) && i <= 4 && i > 0)
            {
                Round = i;
                Turn(player); //start the game 
            }
            //when choice is not valid 
            else
            {
                Console.WriteLine("Please Input A Valid Option");
                RoundAmount(); //recall method 
            }
        }

        public void Turn(int player)
        {
            //anything relating to the players turn
            int count = 0; //number of turns taken
            Die die = new Die();
            Statistics statistics = new Statistics();
            int die1 = 0; //first die value 
            int die2 = 0; //second die value 
            while (die1 + die2 != 7) //while the game isnt won (two values dont add up to 7)
            {
                Console.WriteLine("Press r to roll the dice");
                if (Console.ReadLine() == "r") //when the user inputs r 
                {
                    count++; //add to the turn count 
                    die.Roll(); //roll the first die 
                    die1 = die.DieValue;
                    Console.WriteLine(die1);
                    die.Roll(); //roll the second die 
                    die2 = die.DieValue;
                    Console.WriteLine(die2);
                    int score = die1 + die2; //add the two rolls together
                    if (score != 7) //when turn does not need to end 
                    {
                        if (player == 1)
                        {
                            SevensOutScoreP1 = SevensOutScoreP1 + score; //add to player ones score 
                        }
                        else
                        {
                            SevensOutScoreP2 = SevensOutScoreP2 + score; //add to player twos score 
                        }
                    }
                    else //when 7 is scored and turn needs to end  
                    {
                        if (player == 1)
                        {
                            SevensOutScoreP1 = SevensOutScoreP1 + score; //add to player ones score
                            Console.WriteLine("Your Current Score is " + SevensOutScoreP1); //tell the user their score after the round 
                        }
                        else
                        {
                            SevensOutScoreP2 = SevensOutScoreP2 + score; //add to player twos score
                            Console.WriteLine("Your Current Score is " + SevensOutScoreP2); //tell the user their score after the round
                        }
                        statistics.ShortestStreakSO(count); //check for shortest streak
                        statistics.LongestStreakSO(count); //check for longest streak 
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
            //when playing with AI player 2 is the ai and needs the AITurn method instead   
            if(AI == true && player == 2)
            {
                AITurn(player);
            }
            else
            {
                Turn(player);
            }
        }

        public void Winner()
        {
            Statistics statistics = new Statistics();
            if (SevensOutScoreP1 > SevensOutScoreP2) //if player one wins 
            {
                statistics.HighScore7Game(SevensOutScoreP1); //check for high score 
                if(AI == false)
                {
                    statistics.LowScore7Game(SevensOutScoreP2); //check for lowscore from player two when not playing against AI 
                }
                statistics.Player1WinCountSO(); //add to win count for player 1
                Console.WriteLine("Player 1 Wins With " + SevensOutScoreP1 + " Points!");
            }
            else if (SevensOutScoreP1 < SevensOutScoreP2) //if player 2 wins 
            {
                if (AI == false)
                {
                    statistics.HighScore7Game(SevensOutScoreP2); //check for high score 
                    statistics.Player2WinCountSO(); //add to win count 
                }
                statistics.LowScore7Game(SevensOutScoreP1); //check for lowscore from player 1 
                Console.WriteLine("Player 2 Wins With " + SevensOutScoreP2 + " Points!");
            }
            //when score is a draw 
            //only need to check player ones scores as both players scored the same 
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

            if (inp == "m")
            {
                //go back to main menu 
                Restart(0);
            }
            else if(inp == "r")
            {
                //restart the sevens out game 
                SevensOutScoreP1 = 0;
                SevensOutScoreP2 = 0;
                SevensOutGame();
            }
            //catch incorrect inputs 
            else
            {
                Console.WriteLine("Please Input a Valid Option");
                EndGame();
            }
        }

        //same as Turn but without any user inputs 
        public bool AITurn(int player)
        {
            int count = 0;
            Die die = new Die();
            Statistics statistics = new Statistics();
            int die1 = 0;
            int die2 = 0;
            while (die1 + die2 != 7)
            {
                int score = 7; //start at 7 for testing purposes 
                if (Testing.testing == false) //skip this when testing 
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
                        return false; //fail test
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
                        return true; //pass test 
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
            return false; //fail test 
        }
    }
}
