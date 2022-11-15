using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        /// 

        // Fråga 1. Stacken lagrar värdetyper. Rensar sig själv. "Sist in först ut"
        // Heapen kan lagra variabler av både värdetyper och referenstyper. Behöver hjälp av Garbage Collection för att rensa.

        // Fråga 2. En värdetyp är tex. bool, char, decimal, double, enum, float, int, long. Lagras där de deklareras.
        // En referenstyp är tex class, object, string, interface. En referenstyp håller inte värdet på objektet som det
        // refererar till, det håller en referens till det objektet. En referenstyp lagras på heapen.

        // Fråga 3. I första metoden deklareras en int x och vi sätter värdet till 3.
        // Sen deklareras y och sätts lika med x. Då skapas en kopia av x. När sedan y ändrar
        // sitt värde till 4, är det bara i kopian värdet ändras, så x är oförändrat. Int är en värdetyp.
        //
        // I andra metoden är MyInt en klass och därför en referenstyp. Vi skapar ett objekt x i stacken, som pekar på det riktiga objektet
        // på heapen. Stacken innehåller alltså bara en referens till det lagrade värdet på heapen. När vi sedan skapar
        // ett nytt objekt y och sätter y=x, kommer y peka på x på heapen. När y får värdet 4, ändras värdet på heapen. Eftersom både 
        // x och y är referenstyper kommer de båda peka på samma objekt. Därför pekar även x på 4. 


        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}

            List<string> theList = new List<string>();
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine(" Enter a string with a \"+\" in front, if you want to add the string."
                     + "\n Enter a string with a \"-\" in front, it you want to remove the string"
                     + "\n Or enter 0 to exit to the main menu");

                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        break;
                    case '-':
                        theList.Remove(value);
                        break;
                    case '0':
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please, only enter \"+\" or \"-\" in front of the string.");
                        break;


                }
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}