using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ApplicationLayer
{
    public class UserIO
    {

        /*
        public void DisplayPage(Page currentPage)
        {
            Console.WriteLine(currentPage.PageHeader);
            Console.WriteLine(currentPage.MenuPrompt);
        }
        */

        static public void ConsolePrintLn(string message)
        {
            Console.WriteLine(message);
        }

        static public string GetUserInput()
        {
            var response = new string("");
            while (response == "")
            {
                Console.WriteLine("Please Enter An Option: ");
                response = Console.ReadLine();
                response = response.Trim();
                response = CleanInput(response);
            }
            return response;
        }

        static public string GetUserInput(string prompt)
        {
            var response = new string("");
            while (response == "")
            {
                Console.WriteLine(prompt);
                response = Console.ReadLine();
                //response = response.Trim();
                response = CleanInput(response);
            }
            return response;
        }

        static public string GetUserInputNoClean(string prompt)
        {
            var response = new string("");
            while (response == "")
            {
                Console.WriteLine(prompt);
                response = Console.ReadLine();
            }
            return response;
        }

        static public string GetUserInputNoClean()
        {
            var response = new string("");
            while (response == "")
            {
                response = Console.ReadLine();
            }
            return response;
        }

        //THIS CODE FOR CleanInput is taken from 
        //https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-strip-invalid-characters-from-a-string
        static public string CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings.
            try
            {
                return Regex.Replace(strIn, @"[^\w\.@-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            // If we timeout when replacing invalid characters,
            // we should return Empty.
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

        static public void ConsolePrintList(List<string> list)
        {
            foreach(var line in list)
            {
                Console.WriteLine(line);
            }
        }

        static public void ConsolePrintNumberedList(List<string> list)
        {
            int index = 1;
            foreach (var line in list)
            {
                Console.WriteLine(index + ": " + line);
                index++;
            }
        }

        static public bool GetUserConfirmation(string prompt)
        {
            string response;
            do
            {
                Console.WriteLine( prompt + " (Y/n)");
                response = Console.ReadLine();
                response.Trim();
                response = response.ToUpper();
            } while (!(response == "Y" || response == "N"));

            if(response == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
