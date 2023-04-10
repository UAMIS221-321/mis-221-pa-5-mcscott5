namespace mis_221_pa_5_mcscott5
{
    public class Listing
    {
        private int id;
        private string trainerName;
        private DateOnly date = new DateOnly();
        private TimeOnly startTime = new TimeOnly();
        private TimeOnly endTime = new TimeOnly();
        private double cost;
        private string status;

        //private Trainer[] trainers;
        public Listing(){

        }

        public Listing(int id, string trainerName, string date, string startTime, double cost, string status){
            this.id = id;
            this.trainerName = trainerName;
            this.date = DateOnly.Parse(date);
            this.startTime = TimeOnly.Parse(startTime);
            this.cost = cost;
            this.status = status;
        }

        public Listing(int id, string trainerName, string date, string startTime, string endTime, double cost, string status){
            this.id = id;
            this.trainerName = trainerName;
            this.date = DateOnly.Parse(date);
            this.startTime = TimeOnly.Parse(startTime);
            this.endTime = TimeOnly.Parse(endTime);
            this.cost = cost;
            this.status = status;
        }

        public void SetId(int id){
            this.id = id;
        }

        public int GetId(){
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

        public void SetStartTime(string time){
            this.startTime = TimeOnly.Parse(time);
        }

        public string GetStartTime(){
            return this.startTime.ToString();
        }

        public void SetEndTime(string time){
            this.startTime = TimeOnly.Parse(time);
        }

        public string GetEndTime(){
            return this.startTime.ToString();
        }

        public void SetCost(double cost){
            this.cost = cost;
        }

        public double GetCost(){
            return this.cost;
        }

        public void SetListingStatus(string status){
            this.status = status;
        }

        public string GetListingStatus(){
            return this.status;
        }

        public override string ToString()
        {
            return $"Listing ID: {this.id}\nTrainer Name: {this.trainerName}\nDate: {this.date.ToString()}\nStart Time: {this.startTime.ToString()}\nEnd Time: {this.endTime.ToString()}\nCost: {this.cost}\nStatus: {this.status}";
        }

        public string ToFile()
        {
            return $"{this.id}#{this.trainerName}#{this.date.ToString()}#{this.startTime.ToString()}#{this.endTime.ToString()}#{this.cost}#{this.status}";
        }

    }
}