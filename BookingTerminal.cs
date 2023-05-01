namespace mis_221_pa_5_mcscott5
{
    public class BookingTerminal
    {
        public static void bookingMenu()
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
            Console.WriteLine("1:   View all available training sessions");
            Console.WriteLine("2:   View available training sessions by trainer");
            Console.WriteLine("3:   Book a session");
            Console.WriteLine("4:   Update session status");
            Console.WriteLine("5:   Return to Main Menu");
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
            BookingUtility bUtil = new BookingUtility();
            if (userInput == "1")
            {
                bUtil.ViewAllAvailableTrainingSessions();
            }
            else if (userInput == "2")
            {
                //System.Console.WriteLine("book");
                bUtil.ViewAvailableTrainingSessionsByTrainer();
            }
            else if (userInput == "3")
            {
                //System.Console.WriteLine("book");
                bUtil.BookSession();
            }
            else if (userInput == "4")
            {
                //System.Console.WriteLine("update");
                bUtil.UpdateBookingStatus();
            }

        }
    }
}