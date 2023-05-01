namespace mis_221_pa_5_mcscott5
{
    public class ReportTerminal
    {
        public static void reportMenu()
        {
            string userInput = GetMenuChoice();
            while (userInput != "6")
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
            System.Console.WriteLine("------------------------------------------");
            Console.WriteLine("1:   Print Individual Customer Sessions Report");
            Console.WriteLine("2:   Print Historical Customer Sessions Report");
            Console.WriteLine("3:   Print Historical Revenue Report");
            Console.WriteLine("4:   Print Historical Revenue Chart");
            Console.WriteLine("5:   Print Historical Income Statement Report");
            Console.WriteLine("6:   Return to Main Menu");
            System.Console.WriteLine("------------------------------------------");
        }

        static bool ValidMenuChoice(string userInput)
        {
            if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5" || userInput == "6")
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
            ReportGenerator rGen = new ReportGenerator();
            if (userInput == "1")
            {
                //System.Console.WriteLine("individual customer");
                //rGen.PrintIndividualCustomerReport();
                rGen.IncomeStatement();
            }
            else if (userInput == "2")
            {
                //System.Console.WriteLine("all customers");
                rGen.PrintHistoricalCustomerReports();
            }
            else if (userInput == "3")
            {
                //System.Console.WriteLine("revenue");
                rGen.PrintHistoricalRevenueReports();
                //rGen.PrintHistoricalRevenueChart();
            }
            else if (userInput == "4")
            {
                //System.Console.WriteLine("revenue");
                //rGen.PrintHistoricalRevenueReports();
                rGen.PrintHistoricalRevenueChart();
            }
            else if (userInput == "5")
            {
                //System.Console.WriteLine("revenue");
                rGen.IncomeStatement();
            }

        }
    }
}