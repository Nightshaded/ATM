using System;
using System.Runtime.CompilerServices;

public class Program
{

// Main
    public static void Main(string[] args)
    {
        var accountRepository = new AccountRepository();
        var authService = new AuthenticationService(accountRepository);
        var accountService = new AccountService();
        var session = new ATMService(authService, accountRepository, accountService);


        session.StartSession();
    }
}

