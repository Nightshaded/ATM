using System;
using System.Runtime.CompilerServices;

public class Program
{

// Main
    public static void Main(string[] args)
    {
        // Initialise accounts
        List<Account> accounts = new List<Account>();
        accounts.Add(new Account("3301021001574868",627,"Landon","Smith", 1500.50));
        accounts.Add(new Account("5301028977683383",724,"Anna","Allen", 100.10));
        accounts.Add(new Account("3521022299095202",312,"Jayden","Daniel", 1010.10));
        ATMService session = new ATMService();
        session.LoginOptions();
    }
}

