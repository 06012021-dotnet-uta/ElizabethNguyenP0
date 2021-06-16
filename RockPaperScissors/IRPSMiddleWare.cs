using System;

namespace RockPaperScissors
{
    public interface IRPSMiddleWare
    {
        void displayWelcomeMessage(RPSGameInstance game);
        void displayAllGamesResults(RPSGameInstance game);
        void displayRoundResults(RPSGameInstance game);
        void displayLastGameResults(RPSGameInstance game);
        void displayAllChoices(RPSGameInstance game);
        RPSGameInstance.CHOICES getRPSChoice();
        void setUserInformation(RPSGameInstance game);
    }

    class RPSToConsoleMiddleware : IRPSMiddleWare
    {
        void displayWelcomeMessage(RPSGameInstance game)
        {
            Console.WriteLine(game.welcomeMessage);
        }

        void displayGameResults(RPSGameInstance game)
        {
            Console.WriteLine("\n" + game.totalGamesPlayed + " GAME PLAYED:");
            Console.WriteLine(game.user1 + " won " + game.totalGamesUser1Won + " games.");
            Console.WriteLine(game.user2 + " won " + (game.totalGamesPlayed-game.totalGamesUser1Won-game.totalGamesTied) + " games.");
            Console.WriteLine(game.totalGamesTied + " games tied.");
        }
    }
}