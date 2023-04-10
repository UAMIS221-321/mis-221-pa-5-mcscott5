namespace mis_221_pa_5_mcscott5
{
    public class Trainer
    {
        private int id;
        private string name;
        private string mailingAddress;
        private string emailAddress;

        private string status;

        public Trainer(){

        }
        public Trainer(int id, string name, string mailingAddress, string emailAddress, string status){
            this.id = id;
            this.name = name;
            this.mailingAddress = mailingAddress;
            this.emailAddress = emailAddress;
            this.status = status;
        }

        public Trainer(int id, string name, string mailingAddress, string emailAddress){
            this.id = id;
            this.name = name;
            this.mailingAddress = mailingAddress;
            this.emailAddress = emailAddress;
            this.status = "Active";
        }

        public void SetId(int id){
            this.id = id;
        }

        public int GetId(){
            return this.id;
        }

        public void SetName(string name){
            this.name = name;
        }

        public string GetName(){
            return this.name;
        }

        public string GetMailingAddress(){
            return this.mailingAddress;
        }

        public void SetMailingAddress(string mailingAddress){
            this.mailingAddress = mailingAddress;
        }

        public string GetEmail(){
            return this.emailAddress;
        }

        public void SetEmailAddress(string emailAddress){
            this.emailAddress = emailAddress;
        }

        public void SetStatus(string status){
            this.status = status;
        }

        public string GetStatus(){
            return this.status;
        }

        public override string ToString()
        {
            return $"ID: {this.id}\nName: {this.name}\nMailing Address: {this.mailingAddress}\nEmail Address: {this.emailAddress}\nStatus: {this.status}";
        }

        public string ToFile()
        {
            return $"{this.id}#{this.name}#{this.mailingAddress}#{this.emailAddress}#{this.status}";
        }

    }
}