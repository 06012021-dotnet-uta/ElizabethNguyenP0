using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            RPSGameInstance game = new RPSGameInstance();
            string response;
            Console.WriteLine("Hello! Who are you?");
            game.user1 = Console.ReadLine();

            Console.WriteLine(game.user1 + ", let's play Rock, Paper, Scissors!!!!!");
            
            do
            {
                game.startGame();
                do{
                    Console.WriteLine("Would continue to test your luck and play again????????? >:D (Y/n)");
                    response = Console.ReadLine();
                    response = response.ToUpper();
                }while(!(response == "Y" || response == "N"));
            } while(response == "Y");
            Console.WriteLine("Thanks for stopping by!");
        }
    }

    public class RPSGameInstance
    {
        public RPSGameInstance() //Constructor
        {
            Console.WriteLine("Game Instance Started."); //If was expand to multiple games. Print instance ID.
        }
        
        /***************************************
            RPS GAME INSTANCE VARIABLES
        ****************************************/
        //public enum Choices {ROCK=0, PAPER=1, SCISSORS=2} //Possible RPS Choices
        public string[] CHOICES = {"ROCK", "PAPER", "SCISSORS"};

        /*
            RESULTS is a table to be use as RESULTS[PLAYER1][PLAYER2]
            SUCH THAT 1 = PLAYER1 WIN, 0 = TIE, -1 = PLAYER2 WIN
            I'm NOT CHEATING. I just use lookup tables all the time writing firmware. I only looked up how to use multi-dimensonal arrays.
        */
        public int[,] RESULTS = new int[,] 
        { {0, -1, 1},
          {1, 0, -1},
          {-1, 1, 0}
        };
        public int roundsPerGame = 3;
        public int totalGamesPlayed = 0;
        public int totalGamesUser1Won = 0;
        public int totalGamesTied = 0;
        public string user1 = "Player 1";
        public string user2 = "Computer";
        
        /****************************************
            RPS GAME INSTANCE FUNCTIONS
        *****************************************/
        
        /*
            FUCNTION: getPlayerChoice
            USAGE: PROMPT AND RECIEVE PLAYER'S RPS CHOICE FROM CONSOLE. 
            INPUT: NONE
            RETURN: PLAYER'S RPS CHOICE
        */
        public int getUserChoice() 
        {
            string choice;
            int playerChoice = 0;
            bool validResponse = false;
            while(validResponse == false)
            {
                //Prompt and collect response.
                Console.WriteLine("Choose wisely: uwu");
                for(int i=0;i<CHOICES.Length;i++)
                {
                    Console.WriteLine(i + ": " + CHOICES[i]);
                }
                
                choice = Console.ReadLine();
                
                //Parse Response and check for valid answer
                validResponse = int.TryParse(choice, out playerChoice);
                if(playerChoice < 0 || playerChoice >= CHOICES.Length)
                {
                    validResponse = false;
                    Console.WriteLine("\t Invalid choice. Are you tryna cheat?\n");
                } 
            }
            
            return playerChoice;
        }

        /*
            FUNCTION: RNJesusComputerResponse
            USAGE: USES FAKE RANDOM NUMBER GENERATE TO MAKE AND SET COMPUTER RESPONSE
            INPUT: NONE
            RETURN: COMPUTER'S RPS CHOICE
        */
        public int RNJesusComputerResponse()
        {
            Random random = new Random();
            int computerChoice = random.Next(0,3);
            return computerChoice;
        }

        /*
            FUCNTION: startRound
            USAGE: RUNS 1 ROUND OF RPS
            INPUT: ROUND NUMBER
            RETURNS: WINNER OF ROUND SUCH THAT 1 = PLAYER1 WIN, 0 = TIE, -1 = PLAYER2 WIN
        */
        public int startRound(int round = 0)
        {
            Console.WriteLine("\n\t" +"Round " + round + " start!");
            
            int user1Choice = getUserChoice();
            Console.WriteLine("\t" + user1 + " chose " + CHOICES[user1Choice] + ".");
            int user2Choice = RNJesusComputerResponse();
            Console.WriteLine("\t" + user2 + " chose " + CHOICES[user2Choice] + ".");
            return RESULTS[user1Choice, user2Choice]; 
        }

        /*
            FUNCTION: startGame
            USAGE: RUN 1 GAME OF RPS
            INPUT: NONE
            RETURNS: NONE
        */
        public void startGame()
        {
            int roundResult = 0;
            int roundsWon = 0;
            int roundsTied = 0;
            for(int i=0; i<roundsPerGame; i++)
            {
                roundResult = startRound(i+1);
                Console.Write("\t");
                switch(roundResult)
                {
                    case 1:
                        Console.WriteLine(user1 + " wins!");
                        roundsWon++;
                        break;
                    case 0:
                        Console.WriteLine("It's a tie!");
                        roundsTied++;
                        break;
                    case -1:
                        Console.WriteLine(user2 + " wins!");
                        roundsWon--;
                        break;
                }
            }
            if(roundsWon > 0)
            {
                Console.WriteLine(user1 + " wins this game");
                totalGamesUser1Won++; 
            }
            else if(roundsWon == 0)
            {
                Console.WriteLine("This game tied. Nice try.");
                totalGamesTied++;
            }
            else
            {
                Console.WriteLine(user2 + " wins the game. QAQ Better luck next time.");
            }
            totalGamesPlayed++;
            
            Console.WriteLine("\n" + totalGamesPlayed + " GAME PLAYED:");
            Console.WriteLine(user1 + " won " + totalGamesUser1Won + " games.");
            Console.WriteLine(user2 + " won " + (totalGamesPlayed-totalGamesUser1Won-totalGamesTied) + " games.");
            Console.WriteLine(totalGamesTied + " games tied.");
        }
    }
}
