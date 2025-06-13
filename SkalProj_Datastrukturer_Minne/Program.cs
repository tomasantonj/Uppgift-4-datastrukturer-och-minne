using System;
using System.Drawing;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
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
        /// Examines Stack and Heap memory allocation
        /// </summary
        // x & y in this function is a value type of int and is stored on the stack.
        // When we assign x = y; we are copying the value of y into x but not the reference.
        // when we then assign y = 4; we are changing the value of y, but it does not affect x.
        //public int ReturnValue1()
        //{
        //    int x = new int();
        //    x = 3;
        //    int y = new int();
        //    y = x;
        //    y = 4;
        //    return x;
        //}

        // X in this function is a reference to the object MyInt, and is stored on the heap. So when we change the value of y, it does not affect x.
        // When we assign x.MyValue = 3, we are creating a new object on the heap, and y is a reference to that object.
        // When we assign y = x, we are making y a reference to the same object as x. So when we change y.MyValue, it does not affect x.MyValue.
        //public int ReturnValue2()
        //{
        //    MyInt x = new MyInt();
        //    x.MyValue = 3;
        //    MyInt y = new MyInt();
        //    y = x;
        //    y.MyValue = 4;
        //    return x.MyValue
        //    }


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
            var theList = new List<string>();
            while (true)
            {

                Console.WriteLine("\nEnter +Name to add, -Name to remove, or 0 to return to main menu:");
                string? input = Console.ReadLine();

                // make sure input isnt null or empty
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                    continue;
                }

                char nav = input[0]; // Get the first character for navigation
                string value = input.Length > 1 ? input.Substring(1).Trim() : ""; // Get the rest of the input as the value

                if (nav == '0') // return to previous menu or exit if 0
                    break;

                switch (nav)
                {
                    case '+':
                        if (string.IsNullOrEmpty(value))
                        {
                            Console.WriteLine("What name do you want to add?");
                        }
                        else
                        {
                            theList.Add(value);
                            Console.WriteLine($"Added \"{value}\" to the list.");
                        }
                        break;
                    case '-':
                        if (string.IsNullOrEmpty(value))
                        {
                            Console.WriteLine("What name do you want to remove?");
                        }
                        else if (theList.Remove(value))
                        {
                            Console.WriteLine($"Removed \"{value}\" from the list.");
                        }
                        else
                        {
                            Console.WriteLine($"\"{value}\" is not in the list.");
                        }
                        break;
                    default:
                        Console.WriteLine("Use only + or - followed by a name, or 0 to exit.");
                        break;
                }

                Console.WriteLine($"List count: {theList.Count}, capacity: {theList.Capacity}");

            }
        }

        /// <summary>
        /// Examines the datastructure Queue

        //2.När ökar listans kapacitet ? (Alltså den underliggande arrayens storlek)
        // När vi ligger till ett element i listan och den underliggande arrayen är full så ökar kapaciteten. 
        // Listor har alltid en underliggande array som lagrar elementen, och när den arrayen är full så skapas en ny array med dubbla den tidigares kapacitet.
        // Listan kan vara 4 av 4 element stor, och när vi lägger till ett 5:e element så skapas ny array med storlek av 8.
        //3.Med hur mycket ökar kapaciteten?
        // När kapaciteten ökar, så dubblas den underliggande arrayens storlek. Den nya arrayen dubblar i storlek när arrayen är full.
        // Den börjar med 4 element, sen 8, 16, 32 och så vidare. 
        //4.Varför ökar inte listans kapacitet i samma takt som element läggs till ?
        // Eftersom att arrayen har en fast storlek, och eftersom att vi har tillgänglig plats i arrayen fortfarande,
        // och om vi skulle öka varje gång vi lägger till ett element skulle den fortfarande växa enligt ovan regel och fort bli väldigt stor.
        //5.Minskar kapaciteten när element tas bort ur listan?
        // Nej, array kapaciteten stannar kvar på storleken den hade när den skapades.
        //6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
        // Så länge vi vet hur många element vi ska ha i en array och inte kommer ändra storleken på den arrayen, så är det bättre att använda en array än en lista.

        /// </summary>

        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            var theQueue = new Queue<string>();
            while (true)
            {
                Console.WriteLine("\nEnter +Value to enqueue, - to dequeue, or 0 to return to main menu:");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                    continue;
                }

                char nav = input[0];
                string value = input.Length > 1 ? input.Substring(1).Trim() : "";

                if (nav == '0')
                    break;

                switch (nav)
                {
                    case '+':
                        if (string.IsNullOrEmpty(value))
                        {
                            Console.WriteLine("Please provide a value to enqueue.");
                        }
                        else
                        {
                            theQueue.Enqueue(value);
                            Console.WriteLine($"Enqueued \"{value}\" to the queue.");
                        }
                        break;
                    case '-':
                        if (theQueue.Count == 0)
                        {
                            Console.WriteLine("Queue is empty. Nothing to dequeue.");
                        }
                        else
                        {
                            string dequeued = theQueue.Dequeue();
                            Console.WriteLine($"Dequeued \"{dequeued}\" from the queue.");
                        }
                        break;
                    default:
                        Console.WriteLine("Use +Value to enqueue, - to dequeue, or 0 to exit.");
                        break;
                }

                Console.WriteLine("Current queue (front to back):");
                foreach (var item in theQueue)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"Queue count: {theQueue.Count}");
            }
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
            * 2. Implementera en ReverseText-metod som läser in en sträng från användaren och
            * med hjälp av en stack vänder ordning på teckenföljden för att sedan skriva ut den
            * omvända strängen till användaren.
            */
            var theStack = new Stack<string>();
            while (true)
            {
                Console.WriteLine("\nEnter +Value to push, - to pop, r to reverse text, or 0 to return to main menu:");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                    continue;
                }

                char nav = input[0];
                string value = input.Length > 1 ? input.Substring(1).Trim() : "";

                if (nav == '0')
                    break;

                switch (nav)
                {
                    case '+':
                        if (string.IsNullOrEmpty(value))
                        {
                            Console.WriteLine("Please provide a value to push.");
                        }
                        else
                        {
                            theStack.Push(value);
                            Console.WriteLine($"Pushed \"{value}\" onto the stack.");
                        }
                        break;
                    case '-':
                        if (theStack.Count == 0)
                        {
                            Console.WriteLine("Stack is empty. Nothing to pop.");
                        }
                        else
                        {
                            string popped = theStack.Pop();
                            Console.WriteLine($"Popped \"{popped}\" from the stack.");
                        }
                        break;
                    case 'r':
                    case 'R':
                        Console.WriteLine("Enter text to reverse:");
                        string? textToReverse = Console.ReadLine();
                        if (string.IsNullOrEmpty(textToReverse))
                        {
                            Console.WriteLine("Input cannot be empty.");
                        }
                        else
                        {
                            string reversed = ReverseText(textToReverse);
                            Console.WriteLine($"Reversed: {reversed}");
                        }
                        break;
                    default:
                        Console.WriteLine("Use +Value to push, - to pop, r to reverse text, or 0 to exit.");
                        break;
                }

                Console.WriteLine("Current stack (top to bottom):");
                foreach (var item in theStack)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"Stack count: {theStack.Count}");
            }
        }
        // Method to reverse text using a stack
        static string ReverseText(string input)
        {
            var stack = new Stack<char>();
            foreach (char c in input)
            {
                stack.Push(c);
            }

            var reversed = new System.Text.StringBuilder();
            while (stack.Count > 0)
            {
                reversed.Append(stack.Pop());
            }
            return reversed.ToString();
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             * 1. Skapa med hjälp av er nya kunskap funktionalitet för att kontrollera en välformad
             * sträng på papper. Du ska använda dig av någon eller några av de datastrukturer vi
             * precis gått igenom. Vilken datastruktur använder du?
             * 2. Implementera funktionaliteten i metoden CheckParentheses. Låt programmet läsa
             * in en sträng från användaren och returnera ett svar som reflekterar huruvida
             * strängen är välformad eller ej.
             */
            Console.WriteLine("\nEnter a string to check for correct parenthesis/bracket/brace matching:");
            while (true)
            {
                string? input = Console.ReadLine();
                if (input == "0")
                    break;

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Try again:");
                    continue;
                }

                if (IsParenthesisCorrect(input))
                {
                    Console.WriteLine("Correct paranthesis usage");
                }
                else
                {
                    Console.WriteLine("Incorrect paranthesis usage");
                }
                Console.WriteLine("\nEnter another string to check:");
            }
        }

        /// <summary>
        /// Using a dictionary and pop and push this method checks if the paranthesis (or brackets or braces) in a string is correctly matched.
        /// It then returns true if they are correctly matched, otherwise false.
        /// </summary>
        static bool IsParenthesisCorrect(string input)
        {
            var stack = new Stack<char>();
            var pairs = new Dictionary<char, char>
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            foreach (char c in input)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0 || stack.Pop() != pairs[c])
                        return false;
                }
            }
            return stack.Count == 0;
        }

    }
}

