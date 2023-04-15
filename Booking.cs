namespace mis_221_pa_5_mcscott5
{
    public class Booking
    {
        private int sessionId;
        private int trainerId;
        private string trainerName;
        private DateOnly date = new DateOnly();
        private string customerName;
        private string customerEmail;
        private double cost;
        private string status;

        //private Trainer[] trainers;
        public Booking(){

        }

        public Booking(int sessionId, string customerName, string customerEmail, string trainingDate, int trainerId, string trainerName, double cost){
            this.sessionId = sessionId;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainerName = trainerName;
            this.date = DateOnly.Parse(trainingDate);
            this.trainerId = trainerId;
            this.trainerName = trainerName;
            this.cost = cost;
            this.status = "Booked";
        }

        public void SetSessionId(int id){
            this.sessionId = id;
        }

        public int GetSessionId(){
            return this.sessionId;
        }

        public void SetTrainerId(int trainerId){
            this.trainerId = trainerId;
        }

        public int GetTrainerId(){
            return this.trainerId;
        }

        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }

        public string GetTrainerName(){
            return this.trainerName;
        }

        public void SetCustomerName(string customerName){
            this.customerName = customerName;
        }

        public string GetCustomerName(){
            return this.customerName;
        }

        public void SetCustomerEmail(string customerEmail){
            this.customerEmail = customerEmail;
        }

        public string GetCustomerEmail(){
            return this.customerEmail;
        }

        public void SetDate(string date){
            this.date = DateOnly.Parse(date);
        }

        public string GetDate(){
            return this.date.ToString();
        }
        
        public void SetCost(double cost){
            this.cost = cost;
        }

        public double GetCost(){
            return this.cost;
        }

        public void SetStatus(string status){
            this.status = status;
        }

        public string GetStatus(){
            return this.status;
        }

        public override string ToString()
        {
            return $"Session ID: {this.sessionId}\nCustomer Name: {this.customerName}\nCustomer Email: {this.customerEmail}\nDate: {this.date.ToString()}\nTrainer ID: {this.trainerId}\nTrainer Name: {this.trainerName}\nCost: {this.cost}\nStatus: {this.status}";
        }

        public string ToFile()
        {
            return $"{this.sessionId}#{this.customerName}#{this.customerEmail}#{this.date.ToString()}#{this.trainerId}#{this.trainerName}#{this.cost}#{this.status}";
        }
    }
}