namespace mis_221_pa_5_mcscott5
{
    public class Trainer
    {
        private string id;
        private string name;
        private string mailingAddress;
        private string emailAddress;

        static private int count;

        public Trainer(){

        }
        public Trainer(string id, string name, string mailingAddress, string emailAddress){
            this.id = id;
            this.name = name;
            this.mailingAddress = mailingAddress;
            this.emailAddress = emailAddress;
        }

        public void SetId(string id){
            this.id = id;
        }

        public string GetId(){
            return this.id;
        }

        public void SetName(string name){
            this.name = name;
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

        static public void SetCount(int count){
            Trainer.count = count;
        }

        static public void IncCount(){
            Trainer.count++;
        }

        static public int GetCount(){
            return Trainer.count;
        }

        public override string ToString()
        {
            return $"ID: {this.id}\nName: {this.name}\nMailing Address: {this.mailingAddress}\nEmail Address: {this.emailAddress}";
        }

    }
}