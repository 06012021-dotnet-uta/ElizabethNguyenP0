using System;
using System.Collections.Generic;

namespace ApplicationLayer
{
    public class GetValid
    {
        public GetValid()
        {
            //Console.WriteLine("Get Valid Class initialized");
        }

        static public int Age()
        {
            bool validInput = false;
            int age = -1;
            while (validInput == false || age <= 0 || age > 100)
            {
                validInput = Int32.TryParse(UserIO.GetUserInput("Enter your age:"), out age);
            }
            return age;
        }

        static public string StringLength(int length)
        {
            string stringInput = "";
            while (stringInput == "" || stringInput.Length > length)
            {
                stringInput = UserIO.GetUserInput("(Max of " + length + " characters.)");
            }
            return stringInput;
        }

        static public string StringInput(int length, string prompt)
        {
            string stringInput = "";
            while (stringInput == "" || stringInput.Length > length)
            {
                stringInput = UserIO.GetUserInput(prompt + "(Max of " + length + " characters.)");
            }
            return stringInput;
        }

        static public int OptionChoice<T>(List<T> item)
        {
            int UserChoice = -1;
            bool validInput = false;
            int index = 1;

            while (validInput == false || UserChoice <= 0 || UserChoice > item.Count)
            {
                foreach (var line in item)
                {
                    Console.WriteLine(index + ": " + line);
                    index++;
                }
                index = 1;
                validInput = Int32.TryParse(UserIO.GetUserInput("Please select an option of the list above:"), out UserChoice);
            }
            return UserChoice;
        }
        static public int NumberOption(int size)
        {
            bool validInput = false;
            int option = -1;
            while (validInput == false || option <= 0 || option > size)
            {
                validInput = Int32.TryParse(UserIO.GetUserInput("Enter the option you want:"), out option);
            }
            return option;
        }

        static public int NumberOption(string prompt, int size)
        {
            bool validInput = false;
            int option = -1;
            while (validInput == false || option <= 0 || option > size)
            {
                validInput = Int32.TryParse(UserIO.GetUserInput(prompt), out option);
            }
            return option;
        }
    }
}
