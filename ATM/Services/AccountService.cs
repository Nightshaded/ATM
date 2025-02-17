public class AccountService
{
    public AccountService()
    {

    }
    // Deposit option
    public void Deposit(Account currentUser, double deposit)
    {
        currentUser.SetBalance(currentUser.GetBalance() + deposit);
    }

    // Withdrawal option
    public void Withdraw(Account currentUser)
    {
        Console.WriteLine("How much $$ would you like to withdraw: ");
        double withdrawal = InputValidation.GetValidatedDoubleInput();

        // checks if the user has enough in their balance to withdraw
        if (currentUser.GetBalance() > withdrawal)
        {
            currentUser.SetBalance(currentUser.GetBalance() - withdrawal);
            Console.WriteLine($"Thanks for you withdrawal. Your new balance is: {currentUser.GetBalance()}");
        }
        else
        {
            Console.WriteLine($"Sorry you have insufficient money in your account to withdraw.\nYour balance is: {currentUser.GetBalance()}");
        }
    }

}


