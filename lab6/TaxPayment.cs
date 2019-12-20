namespace lab6
{
    public class TaxPayment : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request is CreditAccount)
            {
                var account = request as CreditAccount;
                account.Debit(account.tax);

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