using System;

namespace RockPaperScissors
{
    public abstract class RPSGame : BasicGameFunctionality
    {
        public RPSGame()
        {
            RPSWelcomeMessage = "Abstract RPS Welcome";
            RPSType = "Abstract RPS Type";
            Choices = new string[] {"Empty","Choices"};
            WinnerCalculationTable = new int[,] {{0 , 0}, {0, 0}};
        }
        public RPSGame(string welcomeMessage, string gameType, string[] choices, int[,] winnerTable)
        {
            RPSWelcomeMessage = welcomeMessage;
            RPSType = gameType;
            Choices = choices;
            WinnerCalculationTable = winnerTable;
        }
        string RPSWelcomeMessage {get;} = "Abstract RPS";
        string RPSType {get;} = "Abstract RPS Type";
        string[] Choices {get;}
        int[,] WinnerCalculationTable;

        public int CalculateRoundWinner(int player_one_choice, int player_two_choice)
        {
        	return WinnerCalculationTable[player_one_choice, player_two_choice];
        }

        public int CheckForValidIntegerChoice(int integer_choice)
        {
        	if(integer_choice < 0 || integer_choice > Choices.Length)
        	{
        		return -1;
        	}
            return integer_choice;
        }
    }
}