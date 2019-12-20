using System;

namespace lab6
{
    class DepositAccount : Account
    {
        private DateTime dateTime;
        public readonly double percent;
        private bool moneyRecount = false;

        public DepositAccount(Client client)
            : base(client)
        { }

        public DepositAccount(Client client, DateTime dateTime, Double percent)
        {
            this.accountClient = client;
            this.dateTime = dateTime;
            this.percent = percent;
        }

        public override void Debit(double moneyAmount)
        {
            if (DateTime.Now.CompareTo(dateTime) < 0)
            {
                Console.WriteLine($"Please wait {(dateTime - DateTime.Now)} untill {dateTime}\n");
            }
            else
            {
                if (sumForSuspicious != null)
                {
                    if (sumForSuspicious < moneyAmount)
                    {
                        Console.WriteLine(
                            $"Your account is considered suspicious.\nYou can debit only {sumForSuspicious} rubles\n'We recommend you to give your personal information to unlock the restrictions\n");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"We are informing you that your account is considered suspicious.You can debit only {sumForSuspicious} rubles\n");
                        if (!moneyRecount)
                        {
                            this.accountSum = moneyAmount * (1 + percent / 100.00);
                            moneyRecount = true;
                        }

                        this.accountSum -= moneyAmount;
                        Console.WriteLine($"{CheckType()}\nHere are your: {moneyAmount} rubles\n");
                    }
                }
                else
                {
                    if (!moneyRecount)
                    {
                        this.accountSum = moneyAmount * (1 + percent / 100.00);
                        moneyRecount = true;
                    }

                    this.accountSum -= moneyAmount;
                    Console.WriteLine($"{CheckType()}\nHere are your: {moneyAmount} rubles\n");
                }
            }
        }

        public override void Transfer(Account account, double money)
        {
            Console.WriteLine($"Transfering: {money} rubles");
            if (moneyRecount)
            {
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
                            if (sumForSuspicious < money)
                                Console.WriteLine(
                                    $"Your account is considered suspicious.\nYou can transfer only {sumForSuspicious} rubles\n'We recommend you to give your personal information to unlock the restrictions\n");
                            else
                            {
                                Console.WriteLine(
                                    $"We are informing you that your account is considered suspicious.You can transfer only {sumForSuspicious} rubles\n");
                                this.accountSum -= money;
                                account.accountSum += money;
                                Console.WriteLine(
                                    $"Transfer accomplished\n====FROM====\n{CheckType()}\n==== TO ====\n{account.CheckType()}\n");
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
            else
            {
                if (!moneyRecount)
                {
                    this.accountSum = accountSum * (1 + percent / 100.00);
                    moneyRecount = true;
                }

                Transfer(account, money);
            }
        }        
    }
}