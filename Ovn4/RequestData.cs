using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn4
{
    public class RequestData
    {

        public static string AskForString(string message)  // Checks if a string is null or empty and returns a valid string
        {
            string answer;
            bool success = false;

            do
            {
                Console.WriteLine(message);
                answer = Console.ReadLine();

                if (string.IsNullOrEmpty(answer))
                {
                    Console.WriteLine($"You must enter a valid string");
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return answer!;
        }


        public static int AskForInt(string message)
        {
            bool isInt = false;
            int output;
            do
            {
                Console.WriteLine(message);
                string numberText = Console.ReadLine();
                isInt = int.TryParse(numberText, out output);
                if (!isInt)
                    Console.WriteLine("That was not a valid input. Please try again.");
                else if (output < 0)     //In this exercise, we are only interested in values >= 0 
                {
                    isInt = false;
                    Console.WriteLine("Please enter a positive number");
                }
            }
            while (isInt == false);

            return output;
        }








    }
}
