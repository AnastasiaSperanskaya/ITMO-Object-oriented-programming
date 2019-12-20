namespace lab6
{
    public class Decorator
    {
        public void decorate(Account account)
        {
            if (account.accountClient.passportId == null || account.accountClient.address == null)
            {
                account.sumForSuspicious = 30000.0;
            }
        }
    }
}