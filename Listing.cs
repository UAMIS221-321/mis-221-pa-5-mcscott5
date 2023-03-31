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
        public Listings(){

        }

        public Listings(string id, string trainerName, DateOnly date, TimeOnly time, double cost, bool taken){
            this.id = id;
            this.trainerName = trainerName;
            this.date = date;
            this.time = time;
            this.cost = cost;
            this.taken = taken;
        }


        public void SetDate(string date){
            this.date = DateOnly.Parse(date);
        }

        public string GetDate(){
            return this.date.ToString();
        }
    }
}