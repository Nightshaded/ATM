    using System;
    public class ATMService
    {

        // Login to account
        public void LoginOptions()
        {
            bool restart = false;
            do{
                Console.WriteLine("Please login to your account...");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Exit");
                // Checks User Input
                string UserInput = Console.ReadLine() ?? "0";
                if(UserInput == "1"){
                    // Calls the AuthenticationService class to authenticate the user with the account details
                    restart = false;
                    AuthenticationService login = new AuthenticationService();
                    login.Authentication();
                }
                else if(UserInput == "2"){
                    restart = false;
                    Console.WriteLine("Exiting the ATM application...");
                    Environment.Exit(0);
                }
                else{
                    Console.WriteLine("Please input 1 or 2 to proceed");
                    restart = true;
                }
            } while (restart);

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
        }

        // Deposit option
        public void Deposit(Account currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine() ?? "0");
            currentUser.SetBalance(currentUser.getBalance() + deposit);
            Console.WriteLine($"Thank you for your $$. Your new balance is: {currentUser.getBalance()}");
        }

        // Withdrawal option
        public void Withdraw(Account currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine() ?? "0");

            // checks if the user has enough in their balance to withdraw
            if(currentUser.getBalance() > withdrawal){
                currentUser.SetBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine($"Thanks for you withdrawal. Your new balance is: {currentUser.getBalance()}");
            }
            else{
                Console.WriteLine($"Sorry you have insufficient money in your account to withdraw. /n Your balance is: {currentUser.getBalance()}");
            }
        }
    }
