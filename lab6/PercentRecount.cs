namespace lab6
{
    public class PercentRecount : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request is DepositAccount)
            {
                var account = request as DepositAccount;
                account.Add(account.accountSum * account.percent / 100.0);
                return NextHandler.Handle(request);
            }
            else
            {
                if (request is CurrentAccount)
                {
                    var account = request as CurrentAccount;
                    account.Add(account.accountSum * account.percent / 100.0);
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
}