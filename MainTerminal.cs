namespace mis_221_pa_5_mcscott5
{
    public class MainTerminal
    {
        public void mainMenu()
        {
            string userInput = GetMenuChoice();
            while (userInput != "5")
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
            Console.WriteLine("1:   Manage Trainer Data");
            Console.WriteLine("2:   Manage Listing Data");
            Console.WriteLine("3:   Manage Customer Booking Data");
            Console.WriteLine("4:   Run Reports");
            Console.WriteLine("5:   Exit Application");
            System.Console.WriteLine("------------------------------------------");
        }

        static bool ValidMenuChoice(string userInput)
        {
            if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5")
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
                System.Console.WriteLine("trainer");
                TrainerTerminal.trainerMenu();
            }
            else if (userInput == "2")
            {
                System.Console.WriteLine("listing");
                ListingTerminal.listingMenu();
            }
            else if (userInput == "3")
            {
                System.Console.WriteLine("booking");
                BookingTerminal.bookingMenu();
            }
            else if (userInput == "4")
            {
                System.Console.WriteLine("reports");
                ReportTerminal.reportMenu();
            }

        }
    }
}