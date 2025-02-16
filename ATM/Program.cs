using System;
using System.Runtime.CompilerServices;

public class Program
{

// Main
    public static void Main(string[] args)
    {
        AccountRepository accountRepository = new AccountRepository();
        AuthenticationService authService = new AuthenticationService(accountRepository);
        ATMService session = new ATMService(authService);
        session.StartSession();
    }
}

