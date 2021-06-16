using System;

namespace RockPaperScissors
{
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
        public string[] CHOICES {get;} = {"ROCK", "PAPER", "SCISSORS"};

        /*
            RESULTS is a table to be use as RESULTS[PLAYER1][PLAYER2]
            SUCH THAT 1 = PLAYER1 WIN, 0 = TIE, -1 = PLAYER2 WIN
            I'm NOT CHEATING. I just use lookup tables all the time writing firmware. I only looked up how to use multi-dimensonal arrays.
        */
        public int[,] RESULTS {get;} = new int[,] 
        { {0, -1, 1},
          {1, 0, -1},
          {-1, 1, 0}
        };
        public int roundsPerGame {get; set;} = 3;
        public int totalGamesPlayed {get;} = 0;
        public int totalGamesUser1Won {get;} = 0;
        public int totalGamesTied {get;} = 0;
        public string user1 {get;set;} = "Player 1";
        public string user2 {get;set;} = "Computer";
        
        /****************************************
            RPS GAME INSTANCE FUNCTIONS
        *****************************************/
        
        /*
            FUCNTION: getPlayerChoice
            USAGE: PROMPT AND RECIEVE PLAYER'S RPS CHOICE FROM CONSOLE. 
            INPUT: NONE
            RETURN: PLAYER'S RPS CHOICE
        */
        public int getUserChoiceConsole() 
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
            
            int user1Choice = getUserChoiceConsole();
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
            
            //Plays the RPS roundsPerGame Times
            for(int i=0; i<roundsPerGame; i++)
            {
                //Runs 1 round of RPS
                roundResult = startRound(i+1);
                switch(roundResult)
                {
                    case 1:
                        roundsWon++;
                        break;
                    case 0:
                        roundsTied++;
                        break;
                    case -1:
                        roundsWon--;
                        break;
                }
            }
        }
    }
}