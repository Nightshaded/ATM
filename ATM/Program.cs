using System;
using System.Runtime.CompilerServices;

public class CardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
// Getters
    public string GetCardNum()
    {
        return cardNum;
    }
    public int GetPin() 
    {
        return pin;
    }
    public string GetFirstName() 
    { 
        return firstName;
    }
    public string getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }
    
    /Setters
    public void SetCardNum(string cardNum)
    { 
        this.cardNum = cardNum; 
    }
    public void SetPin(int pin)
    {
        this.pin = pin;
    }
    public void SetFirstName(string firstName)
    {
        this.firstName = firstName;
    }
    public void SetLastName(string lastName)
    {
        this.lastName = lastName;
    }
    public void SetBalance(double balance)
    {
        this.balance = balance;
    }


    public static void Main(string[] args)
    {
        void PrintOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }
        void Deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.SetBalance(currentUser.getBalance() + deposit);
            Console.WriteLine($"Thank you for your $$. Your new balance is: {currentUser.getBalance()}");
        }
    }
}

