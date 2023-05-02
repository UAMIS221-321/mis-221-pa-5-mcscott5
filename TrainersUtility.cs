namespace mis_221_pa_5_mcscott5
{
    public class TrainersUtility
    {
        public static List<Trainer> Trainers = new List<Trainer>();

        public void AddTrainer()
        {
            System.Console.WriteLine("New Trainer Information: ");

            System.Console.WriteLine("Please enter a name: ");
            string newName = Console.ReadLine();

            System.Console.WriteLine("Please enter a mailing address: ");
            string newMail = Console.ReadLine();

            System.Console.WriteLine("Please enter a email address: ");
            string newEmail = Console.ReadLine();

            Random rnd = new Random();
            int newID = rnd.Next(10000000);
            while (TrainerExists(newID))
            {
                newID = rnd.Next();
            }

            Trainer newTrainer = new Trainer(newID, newName, newMail, newEmail);
            Trainers.Add(newTrainer);
            Save();
        }

        public void DeleteTrainer()
        {
            System.Console.WriteLine("Please enter the ID of the trainer you want to delete: ");
            int deleteID = int.Parse(Console.ReadLine());

            while (!TrainerExists(deleteID))
            {
                System.Console.WriteLine("Trainer does not Exist!");
                System.Console.WriteLine("Please enter the ID of the trainer you want to delete: ");
                deleteID = int.Parse(Console.ReadLine());
            }

            foreach (Trainer t in Trainers)
            {
                if (t.GetId() == deleteID)
                {
                    t.SetStatus("Deleted");
                    break;
                }
            }

            foreach (Listing l in ListingUtility.Listings){
                if (l.GetTrainerId() == deleteID && l.GetListingStatus() == "Open"){
                    l.SetListingStatus("Deleted");
                }
            }

            Save();
            ListingUtility.Save();
        }

        public void EditTrainer()
        {
            System.Console.WriteLine("Please enter the ID of the trainer you want to edit: ");
            int editID = int.Parse(Console.ReadLine());

            while (!TrainerExists(editID))
            {
                System.Console.WriteLine("Trainer does not Exist!");
                System.Console.WriteLine("Please enter the ID of the trainer you want to edit: ");
                editID = int.Parse(Console.ReadLine());
            }

            System.Console.WriteLine("Please enter what you want to edit: ");
            Console.WriteLine("1:   Name");
            Console.WriteLine("2:   Mailing Address");
            Console.WriteLine("3:   Email");
            string menuOption = Console.ReadLine();



            foreach (Trainer t in Trainers)
            {
                if (t.GetId() == editID)
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
                    
                    break;
                }
            }

            Save();
        }

        public void Save()
        {
            StreamWriter outFile = new StreamWriter("trainers.txt");
            foreach (Trainer t in Trainers)
            {
                outFile.WriteLine(t.ToFile());
            }
            outFile.Close();
        }

        public static void PopulateTrainers()
        {
            StreamReader inFile = new StreamReader("trainers.txt");
            string line = inFile.ReadLine();
            while ((line != null))
            {
                string[] temp = line.Split('#');
                Trainer newTrainer = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3], temp[4]);
                Trainers.Add(newTrainer);
                line = inFile.ReadLine();
            }

            inFile.Close();
            foreach (Trainer t in TrainersUtility.Trainers)
            {
                System.Console.WriteLine(t.ToString());
                System.Console.WriteLine("");
            }
        }

        public bool TrainerExists(int searchID)
        {
            foreach (Trainer t in Trainers)
            {
                if (t.GetId() == searchID && (t.GetStatus() == "Active"))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
