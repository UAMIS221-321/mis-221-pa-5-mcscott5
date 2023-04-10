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
            string line;
            while ((line = inFile.ReadLine()) != null)
            {
                string[] temp = line.Split('#');
                Trainer newTrainer = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                Trainers.Add(newTrainer);

            }

            inFile.Close();
            foreach (Trainer t in TrainersUtility.Trainers)
            {
                System.Console.WriteLine(t.ToString());
            }
        }

        public bool TrainerExists(int searchID)
        {
            foreach (Trainer t in Trainers)
            {
                if (t.GetId() == searchID)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
