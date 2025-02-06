using System;
using System.Runtime.CompilerServices;

public class Account
{
    string accountNumber;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public Account(string accountNumber, int pin, string firstName, string lastName, double balance)
    {
        this.accountNumber = accountNumber;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
// Getters
    public string GetAccountNumber()
    {
        return accountNumber;
    }
    public int GetPin() 
    {
        return pin;
    }
    public string GetFirstName() 
    { 
        return firstName;
    }
    public string GetLastName()
    {
        return lastName;
    }
    public double GetBalance()
    {
        return balance;
    }
    
// Setters
    public void SetAccountNumber(string accountNumber)
    { 
        this.accountNumber = accountNumber; 
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
}

