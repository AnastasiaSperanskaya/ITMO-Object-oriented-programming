namespace lab6
{
    public class Client
    {
        private readonly string firstName;
        private readonly string lastName;
        public readonly string passportId;
        public readonly string address;

        //public bool isReliable => !string.IsNullOrEmpty(this.address) && !string.IsNullOrEmpty(this.passportId);

        public Client(string firstName, string lastName, string passportId, string address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.passportId = passportId;
            this.address = address;
        }

        public override string ToString()
        {
            return $"Client {firstName} {lastName}\n\tAddress: {address}\n\tPassport: {passportId}\n";
        }
    }
}