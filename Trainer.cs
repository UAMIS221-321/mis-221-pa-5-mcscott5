namespace mis_221_pa_5_mcscott5
{
    public class Trainer
    {
        private int id;
        private string name;
        private string mailingAddress;
        private string emailAddress;

        public Trainer(){

        }
        public Trainer(int id, string name, string mailingAddress, string emailAddress){
            this.id = id;
            this.name = name;
            this.mailingAddress = mailingAddress;
            this.emailAddress = emailAddress;
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

        public override string ToString()
        {
            return $"ID: {this.id}\nName: {this.name}\nMailing Address: {this.mailingAddress}\nEmail Address: {this.emailAddress}";
        }

        public string ToFile()
        {
            return $"{this.id}#{this.name}#{this.mailingAddress}#{this.emailAddress}";
        }

    }
}