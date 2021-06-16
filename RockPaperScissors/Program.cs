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

            Console.WriteLine("\t" + game.user1 + ", let's play Rock, Paper, Scissors!!!!!");
            
            do
            {
                game.startGame();
                do{
                    Console.WriteLine("Would continue to test your luck and play again????????? >:D (Y/n)");
                    response = Console.ReadLine();
                    response = response.ToUpper();
                } while(!(response == "Y" || response == "N"));
            } while(response == "Y");
            Console.WriteLine("Thanks for stopping by!");
        }
    }
}
