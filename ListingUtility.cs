namespace mis_221_pa_5_mcscott5
{
    public class ListingUtility
    {
        public static List<Listing> Listings = new List<Listing>();

        public void AddListing()
        {
            System.Console.WriteLine("New Listing Information: ");
            Listing l = new Listing();
            System.Console.WriteLine("Available Trainers: ");
            foreach (Trainer t in TrainersUtility.Trainers)
            {
                if (t.GetStatus() == "Active")
                    System.Console.WriteLine(t.GetId() + ":\t" + t.GetName());
            }

            System.Console.WriteLine("Please enter the id for the trainer you wish to add a listing for: ");
            int findID = int.Parse(Console.ReadLine());

            while (!TrainerExists(findID))
            {
                System.Console.WriteLine("Trainer does not Exist!");
                System.Console.WriteLine("Please enter the id for the trainer you wish to add a listing for: ");
                findID = int.Parse(Console.ReadLine());
            }
            string newName = "";
            foreach (Trainer t in TrainersUtility.Trainers)
            {
                if (t.GetId() == findID)
                {
                    l.SetTrainerId(t.GetId());
                    l.SetTrainerName(t.GetName());
                    break;
                }
            }


            System.Console.WriteLine("Please enter a date: ");
            string newDate = Console.ReadLine();
            l.SetDate(newDate);

            System.Console.WriteLine("Please enter a start time: ");
            string newStartTime = Console.ReadLine();
            l.SetStartTime(newStartTime);

            System.Console.WriteLine("Please enter a duration: ");
            Console.WriteLine("1:   30 minutes");
            Console.WriteLine("2:   1 hour");
            Console.WriteLine("3:   2 hours");
            string newDuration = Console.ReadLine();
            string newEndTime = "";
            bool validTime = false;
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

            l.SetEndTime(newEndTime);

            System.Console.WriteLine("Please enter a cost: ");
            string newCost = Console.ReadLine();
            l.SetCost(double.Parse(newCost));

            Random rnd = new Random();
            int newID = rnd.Next(10000000);
            while (ListingExists(newID))
            {
                newID = rnd.Next();
            }

            l.SetId(newID);
            l.SetListingStatus("Open");

            //Listing newListing = new Listing(newID, newName, newDate, newStartTime, newEndTime, double.Parse(newCost), "Open");
            Listings.Add(l);
            Save();
        }

        public void DeleteListing()
        {
            foreach(Listing l in Listings){
                    System.Console.WriteLine(l.ToString());
            }

            System.Console.WriteLine("Please enter the ID of the Listing you want to delete: ");
            int deleteID = int.Parse(Console.ReadLine());

            while (!ListingExists(deleteID))
            {
                System.Console.WriteLine("Listing does not Exist!");
                System.Console.WriteLine("Please enter the ID of the Listing you want to delete: ");
                deleteID = int.Parse(Console.ReadLine());
            }

            foreach (Listing l in Listings)
            {
                if (l.GetId() == deleteID)
                {
                    l.SetListingStatus("Deleted");
                    break;
                    
                }
            }
            Save();

        }

        public void EditListing()
        {
            System.Console.WriteLine("Please enter the ID of the listing you want to edit: ");
            int editID = int.Parse(Console.ReadLine());

            while (!ListingExists(editID))
            {
                System.Console.WriteLine("Listing does not Exist!");
                System.Console.WriteLine("Please enter the ID of the listing you want to edit: ");
                editID = int.Parse(Console.ReadLine());
            }

            System.Console.WriteLine("Please enter what you want to edit: ");
            Console.WriteLine("1:   Trainer Id");
            Console.WriteLine("2:   Name");
            Console.WriteLine("3:   Date");
            Console.WriteLine("4:   Start Time");
            Console.WriteLine("5:   End Time");
            Console.WriteLine("6:   Cost");
            Console.WriteLine("7:   Status");
            string menuOption = Console.ReadLine();

            foreach (Listing l in Listings)
            {
                if (l.GetId() == editID)
                {
                    if (menuOption == "1")
                    {
                        System.Console.WriteLine("Please enter what you wish to change their name to: ");
                        string newName = Console.ReadLine();
                        t.SetName(newName);
                        System.Console.WriteLine("Name has been changed to " + newName);
                    }
                    else if (menuOption == "2")
                    {
                        System.Console.WriteLine("Please enter what you wish to change their mailing address to: ");
                        string newMail = Console.ReadLine();
                        t.SetMailingAddress(newMail);
                        System.Console.WriteLine("Mailing address has been changed to " + newMail);
                    }
                    else if (menuOption == "3")
                    {
                        System.Console.WriteLine("Please enter what you wish to change their email address to: ");
                        string newEmail = Console.ReadLine();
                        t.SetEmailAddress(newEmail);
                        System.Console.WriteLine("Email address has been changed to " + newEmail);
                    }
                    else if (menuOption == "4")
                    {
                        System.Console.WriteLine("Please enter what you wish to change their email address to: ");
                        string newEmail = Console.ReadLine();
                        t.SetEmailAddress(newEmail);
                        System.Console.WriteLine("Email address has been changed to " + newEmail);
                    }
                    else if (menuOption == "5")
                    {
                        System.Console.WriteLine("Please enter what you wish to change their email address to: ");
                        string newEmail = Console.ReadLine();
                        t.SetEmailAddress(newEmail);
                        System.Console.WriteLine("Email address has been changed to " + newEmail);
                    }
                    else if (menuOption == "6")
                    {
                        System.Console.WriteLine("Please enter what you wish to change their email address to: ");
                        string newEmail = Console.ReadLine();
                        t.SetEmailAddress(newEmail);
                        System.Console.WriteLine("Email address has been changed to " + newEmail);
                    }
                    else if (menuOption == "7")
                    {
                        System.Console.WriteLine("Please enter what you wish to change their email address to: ");
                        string newEmail = Console.ReadLine();
                        t.SetEmailAddress(newEmail);
                        System.Console.WriteLine("Email address has been changed to " + newEmail);
                    }

                    break;
                }
            }

            Save();
        }

        
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
                Listing newListing = new Listing(int.Parse(temp[0]), int.Parse(temp[1]), temp[2], temp[3], temp[4], temp[5], double.Parse(temp[6]), temp[7]);
                Listings.Add(newListing);

            }

            inFile.Close();
            foreach (Listing l in Listings)
            {
                System.Console.WriteLine(l.ToString());
                System.Console.WriteLine("");
            }
        }

        public bool TrainerExists(int searchID)
        {
            foreach (Trainer t in TrainersUtility.Trainers)
            {
                if (t.GetId() == searchID && (t.GetStatus() == "Active"))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ListingExists(int searchID)
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