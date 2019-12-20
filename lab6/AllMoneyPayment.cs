namespace lab6
{
    public class AllMoneyPayment : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request is CreditAccount || request is CurrentAccount || request is DepositAccount)
            {
                var account = request as Account;
                account.Debit(account.accountSum);

                if (NextHandler != null)
                {
                    return NextHandler.Handle(request);
                }

                return account;
            }

            return base.Handle(request);
        }
    }
}