namespace mis_221_pa_5_mcscott5
{
    public class BookingUtility
    {
        public static List<Booking> Bookings = new List<Booking>();

        public void ViewAllAvailableTrainingSessions(){
            foreach(Listing l in ListingUtility.Listings){
                if (l.GetListingStatus() == "Open"){
                    System.Console.WriteLine(l.ToString());
                    System.Console.WriteLine("--------------------");
                }
            }
        }

        public void ViewAvailableTrainingSessionsByTrainer(){
            System.Console.WriteLine("Please enter a trainer name: ");
            string inName = Console.ReadLine();
            foreach(Listing l in ListingUtility.Listings){
                if (l.GetListingStatus() == "Open" && l.GeTrainerName() == inName){
                    System.Console.WriteLine(l.ToString());
                    System.Console.WriteLine("--------------------");
                }
            }
        }

        public void BookSession(){
            
        }


    }
}