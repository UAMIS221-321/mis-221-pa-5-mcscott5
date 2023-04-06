namespace mis_221_pa_5_mcscott5
{
    public class ReportTerminal
    {
        public static void reportMenu()
        {
            string userInput = GetMenuChoice();
            while (userInput != "4")
            {
                Route(userInput);
                userInput = GetMenuChoice();
            }
        }

        static string GetMenuChoice()
        {
            DisplayMenu();
            string userInput = Console.ReadLine();

            while (!ValidMenuChoice(userInput))
            {
                Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();

                DisplayMenu();
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        static void DisplayMenu()
        {
            Console.WriteLine("1:   Print Individual Customer Sessions Report");
            Console.WriteLine("2:   Print Historical Customer Sessions Report");
            Console.WriteLine("3:   Print Historical Revenue Report");
            Console.WriteLine("4:   Return to Main Menu");
        }

        static bool ValidMenuChoice(string userInput)
        {
            if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Route(string userInput)
        {
            if (userInput == "1")
            {
                System.Console.WriteLine("individual customer");
            }
            else if (userInput == "2")
            {
                System.Console.WriteLine("all customers");
            }
            else if (userInput == "3")
            {
                System.Console.WriteLine("revenue");
            }

        }
    }
}