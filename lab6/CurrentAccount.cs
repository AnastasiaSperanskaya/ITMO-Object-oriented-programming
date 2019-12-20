using System;

namespace lab6
{
    class CurrentAccount : Account
    {
        public readonly double percent;

        public CurrentAccount(Client client) 
            : base(client)
        {}

        public CurrentAccount(Client client, double percent)
        {
            this.accountClient = client;
            this.percent = percent;
        }

        public override void Debit(double moneyAmount)
        {
            if (this.accountSum < moneyAmount)
                Console.WriteLine("Error: No enough money\n");
            else
            {
                if (sumForSuspicious != null)
                {
                    if (moneyAmount > sumForSuspicious)
                    {
                        Console.WriteLine(
                            $"Your account is considered suspicious.\nYou can debit only {sumForSuspicious} rubles\n'We recommend you to give your personal information to unlock the restrictions\n");
                    }
                    else
                    {
                        this.accountSum -= moneyAmount;
                        Console.WriteLine(
                            $"We are informing you that your account is considered suspicious.You can debit only {sumForSuspicious} rubles\n");
                        Console.WriteLine($"{CheckType()}\nHere are your: {moneyAmount} rubles\n");
                    }
                }
                else
                {
                    this.accountSum -= moneyAmount;
                    Console.WriteLine($"{CheckType()}\nHere are your: {moneyAmount} rubles\n");
                }
            }
        }

        public override void Transfer(Account account, double money)
        {
            Console.WriteLine($"Transfering: {money} rubles");
            if (account.accountClient != this.accountClient)
                Console.WriteLine("Account is not yours\n");
            else
            {
                if (accountSum < money)
                    Console.WriteLine("Error: No enough money\n");
                else
                {
                    if (sumForSuspicious != null)
                    {
                        if (money > sumForSuspicious)
                        {
                            Console.WriteLine(
                                $"Your account is considered suspicious.\nYou can transfer only {sumForSuspicious} rubles\nWe recommend you to give your personal information to unlock the restrictions\n");
                        }
                        else
                        {
                            this.accountSum -= money;
                            account.accountSum += money;
                            Console.WriteLine(
                                $"We are informing you that your account is considered suspicious.You can transfer only {sumForSuspicious} rubles\n");
                            Console.WriteLine($"Transfer accomplished\n====FROM====\n{CheckType()}\n==== TO ====\n{account.CheckType()}\n");
                        }
                    }
                    else
                    {
                        this.accountSum -= money;
                        account.accountSum += money;
                        Console.WriteLine(
                            $"Transfer accomplished\n====FROM====\n{CheckType()}\n==== TO ====\n{account.CheckType()}\n");
                    }
                }
            }
        }        
    }
}