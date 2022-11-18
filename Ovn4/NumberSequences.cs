using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn4
{
    public class NumberSequences
    {

        // Fråga 6.3. En iterativ funktion verkar mer minnesvänlig.
        //            En rekursiv funktion ger ofta en elegantare kod, men kräver mer minne i stacken.
        //            Minne i stacken frigörs inte förrän metoden har returnerat. Om man anropar en metod, i metoden,
        //            läggs info på i stacken varje gång metoden anropas. Så "gamla" värden sparas för att komma ihåg dem.
        //            Om mer minne i stacken försöker användas än vad som finns tillgängligt orsakar det s.k. stack overflow. 


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


        public static int IterativeEven(int n) // Iterative function to calculate the n:th EVEN number
        {  
                if (n == 0)
                {
                    Console.WriteLine("Please enter a value>0");  
                    return 0;
                }

            int result = 2;
            for (int i = 0; i < n - 1; i++)
            {
                result += 2;
            }

            return result;
        }

       public static int IterativeFibonacci(int n) // Iterative function to calculate the n:th number in the Fibonacci sequence
       {            
            int firstNumber = 0;
            int secondNumber = 1;
            int result = 0;

            if (n == 0) return n;            
            if (n == 1) return n;

            for (int i = 2; i < n + 1; i++)
            {
                result = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = result;
            }            
            return result;
       }








    }
}
