namespace mis_221_pa_5_mcscott5
{
    public class ListingTerminal
    {
        public static void listingMenu()
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
            System.Console.WriteLine("------------------------------------------");
            Console.WriteLine("1:   Add Listing");
            Console.WriteLine("2:   Delete Listing");
            Console.WriteLine("3:   Edit Listing");
            Console.WriteLine("4:   Return to Main Menu");
            System.Console.WriteLine("------------------------------------------");
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
            ListingUtility lUtil = new ListingUtility();
            if (userInput == "1")
            {
                //System.Console.WriteLine("add");
                lUtil.AddListing();
            }
            else if (userInput == "2")
            {
                //System.Console.WriteLine("delete");
                lUtil.DeleteListing();
            }
            else if (userInput == "3")
            {
                //System.Console.WriteLine("edit");
                lUtil.EditListing();
            }

        }
    }
}