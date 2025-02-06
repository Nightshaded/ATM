using System;
using System.Runtime.CompilerServices;

public class Program
{

// Main
    public static void Main(string[] args)
    {
        // Initialise accounts
        ATMService session = new ATMService();
        session.LoginOptions();
    }
}

