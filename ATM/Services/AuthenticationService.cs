public class AuthenticationService
{
    private readonly AccountRepository accountList;
    public AuthenticationService(AccountRepository accountList)
    {
        this.accountList = accountList;
    }
    public Account? AuthenticateUser(string accountNumber, int pin)
    {
        var account = accountList.FindAccount(accountNumber);
        return account != null && account.GetPin() == pin ? account : null;
    }
}        