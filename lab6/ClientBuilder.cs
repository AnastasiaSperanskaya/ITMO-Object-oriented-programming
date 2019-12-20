using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class ClientBuilder
    {
        private string firstName;
        private string lastName;
        private string passportId;
        private string address;

        public void AddFullName(string fName, string lName)
        {
            this.firstName = fName;
            this.lastName = lName;
        }

        public void AddPassport(string id)
        {
            this.passportId = id;
        }

        public void AddAddress(string address)
        {
            this.address = address;
        }

        public Client BuildClient()
        {
            return new Client(this.firstName, this.lastName, this.passportId, this.address);
        }
    }
}