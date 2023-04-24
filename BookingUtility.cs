namespace mis_221_pa_5_mcscott5
{
    public class BookingUtility
    {
        public static List<Booking> Bookings = new List<Booking>();

        public void ViewAllAvailableTrainingSessions()
        {
            bool found = false;
            foreach (Listing l in ListingUtility.Listings)
            {
                if (l.GetListingStatus() == "Open")
                {
                    found = true;
                    System.Console.WriteLine(l.ToString());
                    System.Console.WriteLine("--------------------");
                }
            }
            if (!found) System.Console.WriteLine("There are no avaiable sessions!");
        }

        public void ViewAvailableTrainingSessionsByTrainer()
        {
            bool found = false;
            System.Console.WriteLine("Please enter a trainer name: ");
            string inName = Console.ReadLine();
            foreach (Listing l in ListingUtility.Listings)
            {
                if (l.GetListingStatus() == "Open" && l.GeTrainerName() == inName)
                {
                    found = true;
                    System.Console.WriteLine(l.ToString());
                    System.Console.WriteLine("--------------------");
                }
            }
            if (!found) System.Console.WriteLine("There are no avaiable sessions for trainers with that name!");
        }

        public void BookSession()
        {
            System.Console.WriteLine("Please enter id of a listing you wish to book: ");
            int searchID = int.Parse(Console.ReadLine());

            while (!ListingUtility.ListingExists(searchID))
            {
                System.Console.WriteLine("Listing does not exist!");
                System.Console.WriteLine("Please enter id of a listing you wish to book: ");
                searchID = int.Parse(Console.ReadLine());
            }

            foreach (Listing l in ListingUtility.Listings)
            {
                if (l.GetId() == searchID)
                {
                    Random rnd = new Random();
                    int newID = rnd.Next(10000000);
                    while (BookingExists(newID))
                    {
                        newID = rnd.Next();
                    }

                    System.Console.WriteLine("Please enter a customer name: ");
                    string customerName = Console.ReadLine();

                    System.Console.WriteLine("Please enter a customer email: ");
                    string customerEmail = Console.ReadLine();
                    

                    //TO-DO: ADD TRAINER ID FIELD TO LISTINGS
                    Booking newBooking = new Booking(newID, customerName, customerEmail, l.GetDate(), l.GetTrainerId(), l.GeTrainerName(), l.GetCost());
                    Bookings.Add(newBooking);
                    Save();
                    break;
                }
            }
        }

        public static bool BookingExists(int searchID)
        {
            foreach (Booking b in Bookings)
            {
                if (b.GetSessionId() == searchID)
                {
                    return true;
                }
            }
            return false;
        }

        public void Save()
        {
            StreamWriter outFile = new StreamWriter("transactions.txt");
            foreach (Booking b in Bookings)
            {
                outFile.WriteLine(b.ToFile());
            }
            outFile.Close();
        }

        public static void PopulateBookings()
        {
            StreamReader inFile = new StreamReader("transactions.txt");
            string line;
            while ((line = inFile.ReadLine()) != null)
            {
                string[] temp = line.Split('#');
                Booking newBooking = new Booking(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], double.Parse(temp[6]));
                Bookings.Add(newBooking);

            }

            inFile.Close();
            foreach (Booking b in Bookings)
            {
                System.Console.WriteLine(b.ToString());
                System.Console.WriteLine("");
            }
        }


    }
}