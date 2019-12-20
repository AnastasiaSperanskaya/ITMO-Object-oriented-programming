using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public abstract class Account
    {
        public Client accountClient;          
        public double accountSum = 0;
        public double? sumForSuspicious = null;

        protected Account() { }

        protected Account(Client client)
        {
            this.accountClient = client;
        }

        public void Add(double moneyAmount)
        {
            this.accountSum += moneyAmount;
            Console.WriteLine($"\tOperation complete\n\tCurrent sum is {this.accountSum}\n\n{CheckType()}\n\n");
        }

        public abstract void Debit(double moneyAmount);
        public abstract void Transfer(Account account, double moneyAmount);

        public string CheckType()
        {
            return $"{this.accountClient}\nAccount type: {GetType().ToString().Substring(5)}";
        }
    }
}