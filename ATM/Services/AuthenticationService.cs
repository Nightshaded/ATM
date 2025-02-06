public class AuthenticationService
{
    public void Authentication()
    {
        AccountRepository accountList = new AccountRepository();
        bool restart;
        int attempts = 0;
        int pinNumber;
        string accountNumber;
        do{
            Console.WriteLine("Please type in your account number: ");
            accountNumber = Console.ReadLine() ?? "0";
            Account currentAccount = accountList.FindAccount(accountNumber);
            restart = false;
            if(currentAccount != null)
            {
                do{
                    restart = false;
                    Console.WriteLine("Please input your pin: ");
                    string input = Console.ReadLine() ?? "0";
                    if(int.TryParse(input, out pinNumber))
                    {
                        if(currentAccount.GetPin() == pinNumber)
                        {
                            Console.WriteLine("Successfully logged in");
                            attempts = 0;
                        }
                        else{
                            Console.WriteLine("Incorrect pin \nPlease try again");
                            restart = true;
                            attempts++;
                        }   
                    }
                    else
                    {
                        restart = true;
                        Console.WriteLine("Invalid pin format \nPlease use numbers only and between 3-6 numbers long...");
                    }
                } while(restart == true && attempts < 3);

            }
            else
            {
                Console.WriteLine("This is not a valid account number \nPlease try again...");
                restart = true;
            }
        } while (restart == true && attempts < 3);


    }
}