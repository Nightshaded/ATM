    using System;
public class ATMService
{        
    private readonly AuthenticationService authService;
    private int pinAttempts = 3;
    
    public ATMService(AuthenticationService authService)
    {
        this.authService = authService;
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
            Console.WriteLine("Please type in your pin number: ");
            pinNumber = InputValidation.GetValidatedIntegerInput();
            if (authService.AuthenticateUser(accountNumber, pinNumber) != null)
            {
                Console.WriteLine("Successfully logged in");
            }
            else
            {
                attempts--;
                restartLoop = true;
                // Checks the number of attempts and sends back an error message and the number of attempts left
                if (attempts != 0 && attempts != 1)
                {
                    Console.WriteLine("Incorrect account number or pin. Please try again");
                    Console.WriteLine($"You have {attempts} attempts left");
                }
                else if (attempts == 1)
                {
                    Console.WriteLine("Incorrect account number or pin. Please try again");
                    Console.WriteLine($"You have {attempts} attempt left");
                }
                // If the total number of pin attempts is reached the session is terminated
                else
                {
                    Console.WriteLine("You have been locked out of the account.\nPlease contact an administator to unlock your account");
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
        if (input == 1)
        {
            
        }
    }

    // Deposit option
    public void Deposit(Account currentUser)
    {
        Console.WriteLine("How much $$ would you like to deposit? ");
        double deposit = Double.Parse(Console.ReadLine() ?? "0");
        currentUser.SetBalance(currentUser.GetBalance() + deposit);
        Console.WriteLine($"Thank you for your $$. Your new balance is: {currentUser.GetBalance()}");
    }

    // Withdrawal option
    public void Withdraw(Account currentUser)
    {
        Console.WriteLine("How much $$ would you like to withdraw: ");
        double withdrawal = Double.Parse(Console.ReadLine() ?? "0");

        // checks if the user has enough in their balance to withdraw
        if(currentUser.GetBalance() > withdrawal){
            currentUser.SetBalance(currentUser.GetBalance() - withdrawal);
            Console.WriteLine($"Thanks for you withdrawal. Your new balance is: {currentUser.GetBalance()}");
        }
        else{
            Console.WriteLine($"Sorry you have insufficient money in your account to withdraw. /n Your balance is: {currentUser.GetBalance()}");
        }
    }
}
