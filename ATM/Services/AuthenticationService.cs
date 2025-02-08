public class AuthenticationService
{
    public void Authentication()
    {
        // Initialise the variables
        AccountRepository accountList = new AccountRepository();
        bool restartAccount;
        bool restartPin;
        int pinAttempts = 3;
        int accountAttempts = 5;
        int pinNumber;
        string accountNumber;
        // Do while loop to check if the account number inputted by the user is in the AccountRepository
        // The user has 5 attempts to type a valid account number
        do{
            Console.WriteLine("Please type in your account number: ");
            // Stores the input from the user and if null the default value is 0
            accountNumber = Console.ReadLine() ?? "0";
            // Checks for the account in the database and then stores the value in the currentAccount variable
            Account currentAccount = accountList.FindAccount(accountNumber);
            restartAccount = false;
            if(currentAccount != null)
            {
                accountAttempts = 5;
                // Do while loop to check the pin inputted by the user matches the account's pin
                // The user has 3 attempts to type the correct pin 
                do{
                    restartPin = false;
                    Console.WriteLine("Please input your pin: ");
                    // Stores the input from the user and if null the default value is 0
                    string input = Console.ReadLine() ?? "0";
                    // If statement checks the input if it is an integer and if it is valid it stores it in the pinNumber variable
                    if(int.TryParse(input, out pinNumber))
                    {
                        // Checks if the pin input matches with the account 
                        if(currentAccount.GetPin() == pinNumber)
                        {
                            Console.WriteLine("Successfully logged in");
                            // Resets the pinAttempts for future when you can logout and log back in the same session
                            pinAttempts = 3;
                        }
                        else{
                            restartPin = true;
                            // Reduces the amount of pin attempts when an incorrect pin is inputted
                            pinAttempts--;
                            // Checks the number of attempts and sends back an error message and the number of attempts left
                            if(pinAttempts != 0 && pinAttempts != 1)
                            {
                                Console.WriteLine("Incorrect pin. Please try again");
                                Console.WriteLine($"You have {pinAttempts} attempts left");
                            }
                            else if(pinAttempts == 1)
                            {
                                Console.WriteLine("Incorrect pin. Please try again");
                                Console.WriteLine($"You have {pinAttempts} attempt left");
                            }
                            // If the total number of pin attempts is reached the session is terminated
                            else
                            {
                                Console.WriteLine("You have been locked out of the account.\nPlease contact an administator to unlock your account");
                            }
                        }   
                    }
                    // If the pin the user inputs is in an invalid format it will not reduce the attempts and will let them retry
                    else
                    {
                        restartPin = true;
                        Console.WriteLine("Invalid pin format \nPlease use numbers only and between 3-6 numbers long...");
                    }
                } while(restartPin == true && pinAttempts != 0);

            }
            // If the account number is not found in the database it will prompt the user to try again.
            else
            {
                accountAttempts--;
                if(accountAttempts != 0 && accountAttempts != 1)
                {
                    Console.WriteLine("This is not a valid account number \nPlease try again...");
                    Console.WriteLine($"You have {accountAttempts} attempts left");
                }
                else if(accountAttempts == 1)
                {
                    Console.WriteLine("This is not a valid account number \nPlease try again...");
                    Console.WriteLine($"You have {accountAttempts} attempt left");
                }
                else
                {
                    Console.WriteLine("This is not a valid account number \nPlease try again...");
                    Console.WriteLine("Session has been terminated for too many failed attempts");
                }

                restartAccount = true;
            }
        } while (restartAccount == true && accountAttempts != 0);


    }
}