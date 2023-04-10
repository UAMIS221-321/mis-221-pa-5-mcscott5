namespace mis_221_pa_5_mcscott5
{
    public class ListingUtility
    {
        public static List<Listing> Listings = new List<Listing>();

        public void AddListing()
        {
            System.Console.WriteLine("New Listing Information: ");

            System.Console.WriteLine("Please enter a trainer name: ");
            string newName = Console.ReadLine();

            while (!TrainerExists(newName))
            {
                System.Console.WriteLine("Trainer does not Exist!");
                System.Console.WriteLine("Please enter a trainer name: ");
                newName = Console.ReadLine();
            }


            System.Console.WriteLine("Please enter a date: ");
            string newDate = Console.ReadLine();

            System.Console.WriteLine("Please enter a start time: ");
            string newStartTime = Console.ReadLine();

            System.Console.WriteLine("Please enter a duration: ");
            Console.WriteLine("1:   30 minutes");
            Console.WriteLine("2:   1 hour");
            Console.WriteLine("3:   2 hours");
            string newDuration = Console.ReadLine();
            string newEndTime = "";
            if (newDuration == "1")
            {
                newEndTime = (TimeOnly.Parse(newStartTime).AddMinutes(30).ToString());
            }
            else if (newDuration == "2")
            {
                newEndTime = (TimeOnly.Parse(newStartTime).AddHours(1).ToString());
            }
            else if (newDuration == "3")
            {
                newEndTime = (TimeOnly.Parse(newStartTime).AddHours(2).ToString());
            }

            System.Console.WriteLine("Please enter a cost: ");
            string newCost = Console.ReadLine();


            Random rnd = new Random();
            int newID = rnd.Next(10000000);
            while (ListingExists(newID))
            {
                newID = rnd.Next();
            }

            Listing newListing = new Listing(newID, newName, newDate, newStartTime, newEndTime, double.Parse(newCost), "Open");
            Listings.Add(newListing);
            Save();
        }

        // public void DeleteTrainer()
        // {
        //     System.Console.WriteLine("Please enter the ID of the trainer you want to delete: ");
        //     int deleteID = int.Parse(Console.ReadLine());

        //     while (!TrainerExists(deleteID))
        //     {
        //         System.Console.WriteLine("Trainer does not Exist!");
        //         System.Console.WriteLine("Please enter the ID of the trainer you want to delete: ");
        //         deleteID = int.Parse(Console.ReadLine());
        //     }

        //     foreach (Trainer t in Trainers)
        //     {
        //         if (t.GetId() == deleteID)
        //         {
        //             t.SetStatus("Deleted");
        //             break;
        //         }
        //     }

        //     Save();

        // }

        // public void EditTrainer()
        // {
        //     System.Console.WriteLine("Please enter the ID of the trainer you want to edit: ");
        //     int editID = int.Parse(Console.ReadLine());

        //     while (!TrainerExists(editID))
        //     {
        //         System.Console.WriteLine("Trainer does not Exist!");
        //         System.Console.WriteLine("Please enter the ID of the trainer you want to edit: ");
        //         editID = int.Parse(Console.ReadLine());
        //     }

        //     System.Console.WriteLine("Please enter what you want to edit: ");
        //     Console.WriteLine("1:   Name");
        //     Console.WriteLine("2:   Mailing Address");
        //     Console.WriteLine("3:   Email");
        //     string menuOption = Console.ReadLine();



        //     foreach (Trainer t in Trainers)
        //     {
        //         if (t.GetId() == editID)
        //         {
        //             if (menuOption == "1")
        //             {
        //                 System.Console.WriteLine("Please enter what you wish to change their name to: ");
        //                 string newName = Console.ReadLine();
        //                 t.SetName(newName);
        //                 System.Console.WriteLine("Name has been changed to " + newName);
        //             }
        //             else if (menuOption == "2")
        //             {
        //                 System.Console.WriteLine("Please enter what you wish to change their mailing address to: ");
        //                 string newMail = Console.ReadLine();
        //                 t.SetMailingAddress(newMail);
        //                 System.Console.WriteLine("Mailing address has been changed to " + newMail);
        //             }
        //             else if (menuOption == "3")
        //             {
        //                 System.Console.WriteLine("Please enter what you wish to change their email address to: ");
        //                 string newEmail = Console.ReadLine();
        //                 t.SetEmailAddress(newEmail);
        //                 System.Console.WriteLine("Email address has been changed to " + newEmail);
        //             }

        //             break;
        //         }
        //     }

        //     Save();
        // }

        public void Save()
        {
            StreamWriter outFile = new StreamWriter("listings.txt");
            foreach (Listing l in Listings)
            {
                outFile.WriteLine(l.ToFile());
            }
            outFile.Close();
        }

        public static void PopulateListings()
        {
            StreamReader inFile = new StreamReader("listings.txt");
            string line;
            while ((line = inFile.ReadLine()) != null)
            {
                string[] temp = line.Split('#');
                Listing newListing = new Listing(int.Parse(temp[0]), temp[1], temp[2], temp[3], temp[4], double.Parse(temp[5]), temp[6]);
                Listings.Add(newListing);

            }

            inFile.Close();
            foreach (Listing l in Listings)
            {
                System.Console.WriteLine(l.ToString());
            }
        }

        public bool TrainerExists(string searchName)
        {
            foreach (Trainer t in TrainersUtility.Trainers)
            {
                if (t.GetName() == searchName && (t.GetStatus() == "Active"))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ListingExists(int searchID)
        {
            foreach (Listing l in Listings)
            {
                if (l.GetId() == searchID && (l.GetListingStatus() == "Open"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}