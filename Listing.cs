namespace mis_221_pa_5_mcscott5
{
    public class Listings
    {
        string id;
        string trainerName;
        public DateOnly date = new DateOnly();
        TimeOnly time = new TimeOnly();
        double cost;
        bool taken;

        //private Trainer[] trainers;

        public void SetDate(string date){
            this.date = DateOnly.Parse(date);
        }

        public string GetDate(){
            return this.date.ToString();
        }
    }
}