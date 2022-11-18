using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn4
{
    public class NumberSequences
    {


        public static int RecursiveEven(int n) //Recursive function to calculate the n:th EVEN number
        {
            if (n == 0)
            {
                Console.WriteLine("A value=0 is not allowed");  //Quick fix to avoid stack overflow when n=0
                return 0;
            }

            if (n == 1)
            {
                return 2;
            }
            return (RecursiveEven(n - 1) + 2);
            Console.WriteLine("hej");
        }


       public static int RecursiveFibonacci(int n)  //Recursive function to calculate the n:th number in the Fibonacci sequence 0,1,1,2,3,5,8,13,21...etc
       {            
            if (n == 0) return n;
            if (n == 1) return n;
            return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
       }


        public static int IterativeEven() // Iterative function to calculate the n:th EVEN number
        {
            string message = "Enter a number: ";
            int n = RequestData.AskForInt(message);

            int result = 2;
            for (int i = 0; i < n - 1; i++)
            {
                result += 2;
            }

            Console.WriteLine($"The {n}:th even number is: {result}");
            return result;
        }

       public static int IterativeFibonacci() // Iterative function to calculate the n:th number in the Fibonacci sequence
       {
            string message = "Enter a number: ";
            int n = RequestData.AskForInt(message);

            if (n == 0) return n;
            if (n == 1) return n;
            int firstNumber = 0;
            int secondNumber = 1;
            int result = 0;

            for (int i = 2; i < n + 1; i++)
            {
                result = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = result;
            }
            Console.WriteLine($"The {n}:th number of the Fibonacci sequence is: {result}");
            return result;
       }








    }
}
