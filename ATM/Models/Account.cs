using System;
using System.Runtime.CompilerServices;

public class Account
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public Account(string cardNum, int pin, string firstName, string lastName, double balance)
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
    
// Setters
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
}

