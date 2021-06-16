namespace RockPaperScissors
{
    public class TraditionalRPS : RPSGame
    {
        //public TraditionalRPS(): RPSGame;

        public string RPSWelcomeMessage {get;} = "Hello, welcome to traditional rock, paper, scissors.";
        public string RPSType {get;} = "Traditional RPS";
        public string[] Chocies {get;} = {"ROCK", "PAPER", "SCISSORS"};
        public int[,] WinnerComparisonTable {get;} = new int[,] 
        { {0, -1, 1},
          {1, 0, -1},
          {-1, 1, 0}
        };
    }

    public class BigBangRPS : RPSGame
    {
    	public BigBangRPS(){}

    	public string RPSWelcomeMessage = "Hello, welcome to Big Bang style rock, paper, scissors.";
    	public string RPSType {get;} = "Big Bang RPS";
    	public string[] Chocies {get;} = {"ROCK", "PAPER", "SCISSORS", "LIZARD", "SPOCK"};
    	public int[,] WinnerComparisonTable {get;} = new int[,]
    	{
    		{0,-1,1,1,-1},
    		{1,0,-1,-1,1},
    		{-1,1,0,1,-1},
    		{-1,1,-1,0,1},
    		{1,-1,1,-1,0}
    	};
    }
}