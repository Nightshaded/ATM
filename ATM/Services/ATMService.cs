    using System;
using System.Security;
public class ATMService
{        
    private readonly AuthenticationService authService;
    private readonly AccountRepository accountRepository;
    private readonly AccountService accountService;
    private Account? currentUser;

    public ATMService(AuthenticationService authService, AccountRepository accountRepository, AccountService accountService)
    {
        this.authService = authService;
        this.accountRepository = accountRepository;
        this.accountService = accountService;
        currentUser = null;
    }
    // Login to account
    public void StartSession()
    {
        bool restart;
        do{
            restart = false;
            Console.WriteLine("Please login to your account...");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Exit");
            // Checks User Input
            string UserInput = Console.ReadLine() ?? "0";
            if(UserInput == "1"){
                AccountLogin();                 
            }
            else if(UserInput == "2"){
                Console.WriteLine("Exiting the ATM application...");
                Environment.Exit(0);
            }
            else{
                Console.WriteLine("Please input 1 or 2 to proceed");
                restart = true;
            }
        } while (restart);

    }

    public void AccountLogin()
    {
        bool restartLoop;
        string accountNumber;
        int pinNumber;
        int attempts = 3;
        do
        {
            restartLoop = false;
            Console.WriteLine("Please type in your account number:");
            // Stores the input from the user and if null the default value is 0
            accountNumber = Console.ReadLine() ?? "0";
            Console.WriteLine("Please type in your PIN number: ");
            pinNumber = InputValidation.GetValidatedIntegerInput();
            currentUser = authService.AuthenticateUser(accountNumber, pinNumber);
            if (currentUser != null)
            {
                Console.WriteLine("Successfully logged in");
                PrintOptions();
            }
            else
            {
                attempts--;
                restartLoop = true;
                // Checks the number of attempts and sends back an error message and the number of attempts left
                if (attempts > 0)
                {
                    Console.WriteLine("Incorrect account number or PIN. Please try again.");
                    Console.WriteLine($"You have {attempts} attempt{(attempts > 1 ? "s" : "")} left.");
                }
                // If the total number of PIN attempts is reached the session is terminated
                else
                {
                    Console.WriteLine("You have been locked out of the account.\nPlease contact an administator to unlock your account.");
                }
            }
        } while(restartLoop && attempts != 0);
    }

    // Prints the list of potential options to choose from
    public void PrintOptions()
    {
        Console.WriteLine("Please choose from one of the following options...");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Show Balance");
        Console.WriteLine("4. View Previous Transactions");
        Console.WriteLine("5. Exit");
            
        int input = InputValidation.GetValidatedIntegerInput();
        switch (input)
        {
            case 1:
                Console.WriteLine("How much money would you like to deposit into your account?");
                double depositAmount = InputValidation.GetValidatedDoubleInput();
                accountService.Deposit(currentUser, depositAmount);
                Console.WriteLine($"Thanks for your deposit.\nYour new balance is: {currentUser.GetBalance()}");
                PrintOptions();
                break;
        }
    }
}
