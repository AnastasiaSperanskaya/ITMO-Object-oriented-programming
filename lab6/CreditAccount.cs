using System;

namespace lab6
{
    class CreditAccount : Account
    {
        private double limit;
        public readonly double tax;

        public CreditAccount(Client client)
            : base(client)
        { }

        public CreditAccount(Client client, Double limit, Double tax)
        {
            this.accountClient = client;
            this.limit = limit;
            this.tax = tax;
        }

        public override void Debit(double moneyAmount)
        {
            if (limit > (this.accountSum - moneyAmount))
            {
                Console.WriteLine(
                    $"We are sorry, you cannot run out of limit\nAmount of money you can debit is:{this.accountSum - limit} rubles\n");
            }
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
                        if (this.accountSum >= 0)
                        {
                            this.accountSum -= moneyAmount;
                            Console.WriteLine(
                                $"We are informing you that your account is considered suspicious.You can debit only {sumForSuspicious} rubles\n");
                            Console.WriteLine($"{CheckType()}\nHere are your: {moneyAmount} rubles\n");
                        }
                        else
                        {
                            Console.WriteLine(
                                $"We are informing you that your account is considered suspicious.You can debit only {sumForSuspicious} rubles\n");
                            Console.WriteLine(
                                $"Your balance is below zero. \nYou will be charged {tax} rubles.\nDo you want to continue? \nPress Y or N key");
                            if (Console.ReadLine().ToLower() == "y")
                            {
                                this.accountSum -= (moneyAmount + tax);
                                Console.WriteLine(
                                    $"Here are your: {moneyAmount} rubles\nAccount: {this.accountSum} rubles\nCredit limit: {Math.Abs(limit)}\n");
                            }
                        }
                    }
                }
                else
                {
                    if (this.accountSum >= 0)
                    {
                        this.accountSum -= moneyAmount;
                        Console.WriteLine(
                            $"{CheckType()}\nHere are your: {moneyAmount} rubles\nCredit limit: {Math.Abs(limit)}\n");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Your balance is below zero. \nYou will be charged {tax} rubles.\nDo you want to continue? \nPress Y or N key");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            this.accountSum -= (moneyAmount + tax);
                            Console.WriteLine(
                                $"{CheckType()}\nHere are your: {moneyAmount} rubles\nCredit limit: {Math.Abs(limit)}\n");
                        }
                    }
                }
            }
        }

        public override void Transfer(Account account, double money)
        {
            Console.WriteLine($"Transfering: {money} rubles");
            if (account.accountClient != this.accountClient)
            {
                Console.WriteLine("Account is not yours\n");
            }
            else
            {
                if (limit > (this.accountSum - money))
                {
                    Console.WriteLine(
                        $"We are sorry, you cannot run out of limit\nAmount of money you can transfer is:{this.accountSum - limit} rubles\n");
                }
                else
                {
                    if (sumForSuspicious != null)
                    {
                        if (money > sumForSuspicious)

                            Console.WriteLine(
                                $"Your account is considered suspicious.\nYou can transfer only {sumForSuspicious} rubles\nWe recommend you to give your personal information to unlock the restrictions\n");
                        else
                        {
                            Console.WriteLine(
                                $"We are informing you that your account is considered suspicious.You can transfer only {sumForSuspicious} rubles\n");

                            if (this.accountSum >= 0)
                            {
                                this.accountSum -= money;
                                account.accountSum += money;
                                Console.WriteLine(
                                    $"Transfer accomplished\n====FROM====\n{CheckType()}\n==== TO ====\n{account.CheckType()}\n");
                            }
                            else
                            {
                                Console.WriteLine(
                                    $"Your balance is below zero. \nYou will be charged {tax} rubles.\nDo you want to continue? \nPress Y or N key");
                                if (Console.ReadLine().ToLower() == "y")
                                {
                                    this.accountSum -= (money + tax);
                                    account.accountSum += money;
                                    Console.WriteLine(
                                        $"Transfer accomplished\n====FROM====\n{CheckType()}\n==== TO ====\n{account.CheckType()}\n");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.accountSum >= 0)
                        {
                            this.accountSum -= money;
                            account.accountSum += money;
                            Console.WriteLine(
                                $"Transfer accomplished\n====FROM====\n{CheckType()}\n==== TO ====\n{account.CheckType()}\n");
                        }
                        else
                        {
                            Console.WriteLine(
                                $"Your balance is below zero. \nYou will be charged {tax} rubles.\nDo you want to continue? \nPress Y or N key");
                            if (Console.ReadLine().ToLower() == "y")
                            {
                                this.accountSum -= (money + tax);
                                account.accountSum += money;
                                Console.WriteLine(
                                    $"Transfer accomplished\n====FROM====\n{CheckType()}\n==== TO ====\n{account.CheckType()}\n");
                            }
                        }
                    }
                }
            }
        }        
    }
}