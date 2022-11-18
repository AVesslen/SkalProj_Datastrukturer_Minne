using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {

        // Fråga 1. Stacken lagrar värdetyper. Stacken har bra koll på vad som finns i den. Rensar sig själv när en metod har körts.
        // Heapen kan lagra variabler av både värdetyper och referenstyper. När ett objekt inte längre har en referens
        // som pekar på det, behöver Garbage Collection hjälpa till att rensa bort det. 

        // Fråga 2. En värdetyp är tex. bool, char, decimal, double, enum, float, int, long. Lagras där de deklareras.
        // En referenstyp är tex class, object, string, interface. En referenstyp håller inte värdet på objektet som det
        // refererar till, det håller en referens till det objektet. En referenstyp lagras på heapen.

        // Fråga 3. I första metoden deklareras en int x och vi sätter värdet till 3.
        // Sen deklareras y och sätts lika med x. Då skapas en kopia av x. När sedan y ändrar
        // sitt värde till 4, är det bara i kopian värdet ändras, så x är oförändrat. Int är en värdetyp.
        //
        // I andra metoden är MyInt en klass och därför en referenstyp. Vi skapar ett objekt, med en "pekare" x i stacken, som pekar på det riktiga objektet
        // på heapen. Stacken innehåller alltså bara en referens till det lagrade värdet på heapen. När vi sedan skapar
        // ett nytt objekt y och sätter y=x, kommer y peka på x på heapen. När y får värdet 4, ändras värdet på heapen. Eftersom både 
        // x och y är referenstyper kommer de båda peka på samma objekt. Därför pekar även x på 4. 


        static void Main()
        {
           
            string textToReverse = "My name is Anna";
            try
            {
                string reversedText = ReverseText(textToReverse);
                Console.WriteLine($"{textToReverse}. After reversed: {reversedText}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


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
                        Console.WriteLine(CheckParanthesis());                       
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

       
        // Examines the datastructure List      
        static void ExamineList()
        {
            List<string> theList = new List<string>();
            bool isRunning = true;
            while (isRunning)
            {
               string message=" Enter a string with a \"+\" in front, if you want to add the string to the list."
                     + "\n Enter a string with a \"-\" in front, it you want to remove the string from the list"
                     + "\n Or enter 0 to exit to the main menu";

                string input = AskForString(message); // Calls the method AskForString to ensure that the input is not empty
                char nav = input[0];
                string value = input.Substring(1);   //Takes the characters from the second index of string and forward


                switch (nav)
                {
                    case '+':
                        theList.Add(value);                       
                        PrintItemsInList(theList);
                        Console.WriteLine($"Capacity: {theList.Capacity},  Count: {theList.Count}"); //Capacity is the number of elements that the List<T> can store before resizing is required
                        break;                                                                       //Count is the number of elements contained in List<T>                                                                                            

                    case '-':
                        theList.Remove(value);
                        PrintItemsInList(theList);
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

            // Fråga 1.2. Listans kapacitet ökar först när den underliggande arrayen är full (count=capacity) och vi vill lägga till ett nytt element.
            // Fråga 1.3. Default kapacitet när första elementet läggs till är 4. Kapaciteten ökar sedan exponentiellt, genom att dubbleras när den
            //            underliggande arrayen är full (4,8,16,32,64... osv.)
            // Fråga 1.4. Listans kapacitet ökar inte i samma takt som element läggs till pga att den lagrar värdena i en array. En array har en fix storlek,
            //            så att lägga till nya element är kostsamt. Det kräver att en ny, längre array skapas och de tidigare elementen kopieras över till
            //            den nya. 
            // Fråga 1.5. Kapaciteten minskar inte när element tas bort ur listan.
            // Fråga 1.6. När man vet på förhand hur många element man vill lägga till är det fördelaktigt att använda en egendefinierad array i stället för lista. 
        }

        static void PrintItemsInList(List<string> list)
        {
            Console.WriteLine($"Items in the list: ");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

       
        // Examines the datastructure Queue       
        static void ExamineQueue()
        {       
            Queue<string> theQueue = new Queue<string>();
            bool isRunning = true;
            while (isRunning)
            {
                string message=" Enter a string with a \"+\" in front, if you want to enqueue (add item to the queue)."
                     + "\n Enter a \"-\", if you want to enqueue (remove the first item from the queue)."
                     + "\n Or enter 0 to exit to the main menu";

                string input = AskForString(message);
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(value);
                        PrintItemsInQueue(theQueue); 
                        break;

                    case '-':
                        if (theQueue.Count > 0)
                            theQueue.Dequeue();

                        PrintItemsInQueue(theQueue);
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

        private static void PrintItemsInQueue(Queue<string> queue)
        {
            Console.WriteLine($"Items in the queue: ");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }


        // Examines the datastructure Stack      
        static void ExamineStack()
        {
            Stack<string> theStack = new Stack<string>();
            bool isRunning = true;
            while (isRunning)
            {
                string message = " Enter a string with a \"+\" in front, if you want to push (add item to the stack)."
                     + "\n Enter a \"-\", if you want to pop (remove the last item from the stack)."
                     + "\n Or enter 0 to exit to the main menu";

                string input = AskForString(message);
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theStack.Push(value);
                        PrintItemsInStack(theStack);
                        break;

                    case '-':
                        if (theStack.Count > 0)
                            theStack.Pop();
                        PrintItemsInStack(theStack);
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
            // Fråga 3.1. I det här fallet med ICA-kön är det inte så smart att använda en stack, eftersom den som ställer sig 
            //          först i kön är den som kommer lämna kön sist, enligt Först In Sist Ut principen. Kalle
            //          kommer därför inte kunna lämna kön förrän de andra har gjort det. 

        
        private static void PrintItemsInStack(Stack<string> stack)
        {
            Console.WriteLine($"Items in the stack: ");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }

        static string ReverseText(string text)   // Returns a reversed text by using the Stack type
            {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException($"'{nameof(text)}' cannot be null or whitespace.");
            }

            char[] charArray = text.ToCharArray();   //Devides the string into characters and puts them in an array
                int length = charArray.Length;

                Stack<char> stack = new Stack<char>();

                foreach (char letter in charArray)
                {
                    stack.Push(letter);
                }

                for (int i = 0; i < length; i++)
                {
                    charArray[i] = stack.Pop();
                }

                string reversedText = new string(charArray);
                return reversedText;
            }



        // Fråga 4.1. För den här metoden kan det vara lämpligt att använda datastrukturen stack. Då kan man lätt frigöra 
        //            de paranteser som hör ihop, för att sedan komma åt och frigöra nästa.

        // Checks if the parenthesis in a string are Correct or incorrect.
        static string CheckParanthesis()
        {          
               
            string message = "Write a string with parenthesis";
            string input = AskForString(message);


            Stack<char> stack = new Stack<char>(input.Length);

            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == '[' || c == '<')
                    stack.Push(c);                                   // A "left parenthesis" is added to the stack
                else if (c == ')' || c == '}' || c == ']' || c == '>')
                {
                    if (stack.Count == 0)
                        return $"{input}: incorrect";

                    char removed = stack.Pop();  // The last added left paranthesis in the stack is removed to see if it 
                                                 // corresponds to the right paranthesis 
                    if (c == ')' && removed != '(' || c == '}' && removed != '{' || c == ']' && removed != '['
                        || c == '>' && removed != '<')

                        return $"{input}: incorrect";
                }
            }

            if (stack.Count > 0)
                return $"{input}: incorrect";

            return $"{input}: correct";
        }



        static string AskForString(string message)  // Checks if a string is null or empty and returns a valid string
        {
            string answer;
            bool success = false;

            do
            {
                Console.WriteLine(message); 
                answer =Console.ReadLine();

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







    }
}