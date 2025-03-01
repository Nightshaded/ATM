public class AccountRepository
{
    private readonly List<Account> accounts;
    public AccountRepository()
    {
        // Initialise new dummy accounts
        accounts = new List<Account>
        {
            new Account("3301021001574868",1111,"Landon","Smith", 1500.50),
            new Account("5301028977683383",2222,"Anna","Allen", 100.10),
            new Account("3521022299095202",3333,"Jayden","Daniel", 1010.10)
        };
    }
    
    // Get all accounts
    public List<Account> GetAllAccounts()
    {
        return accounts;
    }

    // Find the account in the database
    public Account FindAccount(string accountNumber)
    {
        return accounts.Find(acc => acc.GetAccountNumber() == accountNumber);
    }
}