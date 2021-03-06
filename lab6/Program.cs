﻿using System;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientBuilder builder = new ClientBuilder();
            builder.AddFullName("Vasya", "Pupkin");
            builder.AddPassport("Hfsdj1286");
            builder.AddAddress("ulitsa Pushkina");

            Client client = builder.BuildClient();
            Console.WriteLine(client.ToString());

            Factory factory = new Factory(5.0, 9.0, 600.0);

            var dateString = "2019-12-14 13:10:54";
            Account currentAccount = factory.CreateAccount(client, null, null);
            Account depositAccount = factory.CreateAccount(client, null, DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm:ss", null));
            Account creditAccount = factory.CreateAccount(client, -24000, null);

            currentAccount.Add(4500.43);
            depositAccount.Add(5420.43);
            creditAccount.Add(14400.43);

            ClientBuilder secondBuilder = new ClientBuilder();
            Client secondClient = secondBuilder.BuildClient();
            secondBuilder.AddFullName("Tom", "Hohland");

            Account account = factory.CreateAccount(secondClient, null, null);

            Decorator decorator = new Decorator();
            decorator.decorate(account);

            AbstractHandler handlerRecount = new PercentRecount();
            AbstractHandler handlerTax = new TaxPayment();
            AbstractHandler handlerAll = new AllMoneyPayment();

            var buffer = handlerRecount.Handle(currentAccount);

            handlerRecount.SetNext(handlerAll);
            var buffer2 = handlerRecount.Handle(currentAccount);

            var buffer3 = handlerTax.Handle(account);

            Console.ReadKey();

        }
    }
}