using System;
using System.Xml.Linq;

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

            // Count is the number of elements that are present in the List
            // Capacity is the number of elements that the List can store before resizing is required


            List<string> theList = new List<string>();
            Console.WriteLine($"Capacity default: {theList.Capacity}");
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

                        Console.WriteLine($"Items in the list: ");
                        foreach (var item in theList)
                        {
                            Console.WriteLine(item);                               
                        }
                        Console.WriteLine($"Capacity: {theList.Capacity},  Count: {theList.Count}");

                        break;
                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"Items in the list: ");
                        foreach (var item in theList)
                        {
                            Console.WriteLine(item);                             
                        }
                        Console.WriteLine($"Capacity: {theList.Capacity},  Count: {theList.Count}"); 
                        break;

                    case '0':
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please, only enter \"+\" or \"-\" in front of the string.");
                        break;
                }

               
            }

            // Fråga 2. Listans kapacitet ökar först när den underliggande arrayen är full (count=capacity) och vi vill lägga till ett nytt element.
            // Fråga 3. Default kapacitet när första elementet läggs till är 4. Kapaciteten ökar sedan exponentiellt, genom att dubbleras när den
            //          underliggande arrayen är full.
            // Fråga 4. Listans kapacitet ökar inte i samma takt som element läggs till pga att den lagrar värdena i en array. En array har en fix storlek,
            //          så att lägga till nya element är kostsamt. Det kräver att en ny, längre array skapas och de tidigare elementen kopieras över till
            //          den nya. 
            // Fråga 5. Kapaciteten minskar inte när element tas bort ur listan.
            // Fråga 6. När man vet på förhand hur många element man vill lägga till är det fördelaktigt att använda en egendefinierad array i stället för lista. 

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