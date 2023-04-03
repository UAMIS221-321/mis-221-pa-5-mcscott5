namespace mis_221_pa_5_mcscott5
{
    public class Listing
    {
        string id;
        string trainerName;
        public DateOnly date = new DateOnly();
        TimeOnly time = new TimeOnly();
        double cost;
        string taken;

        //private Trainer[] trainers;
        public Listing(){

        }

        public Listing(string id, string trainerName, string date, string time, double cost, string taken){
            this.id = id;
            this.trainerName = trainerName;
            this.date = DateOnly.Parse(date);
            this.time = TimeOnly.Parse(time);
            this.cost = cost;
            this.taken = taken;
        }

        public void SetId(string id){
            this.id = id;
        }

        public string GetId(){
            return this.id;
        }

        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }

        public string GeTrainerName(){
            return this.trainerName;
        }

        public void SetDate(string date){
            this.date = DateOnly.Parse(date);
        }

        public string GetDate(){
            return this.date.ToString();
        }

        public void SetTime(string time){
            this.time = TimeOnly.Parse(time);
        }

        public string GetTime(){
            return this.time.ToString();
        }

        public void SetCost(double cost){
            this.cost = cost;
        }

        public double GetCost(){
            return this.cost;
        }

        public void SetListingStatus(string taken){
            this.taken = taken;
        }

        public string GetListingStatus(){
            return this.taken;
        }

        public override string ToString()
        {
            return $"Listing ID: {this.id}\nTrainer Name: {this.trainerName}\nDate: {this.date.ToString()}\nTime: {this.time.ToString()}\nCost: {this.cost}\nStatus: {this.taken}";
        }

        public string ToFile()
        {
            return $"{this.id}#{this.trainerName}#{this.date.ToString()}#{this.time.ToString()}#{this.cost}#{this.taken}";
        }

    }
}