using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

using System;
class BankAccount
{
    public int Account_number { get; set; }
    public string Name { get; set; }
    public double Balance { get; set; }
    public Double IniterestRate { get; set; }
    public BankAccount(int account_number, string name, double initialBalance, double rate=0)
    {
        Account_number = account_number;
        Name = name;
        Balance = initialBalance;
        IniterestRate = rate;
        


    }

    public void Deposite(double balance)
    {
        if (balance > 0)
        {
            Balance += balance;
            Console.WriteLine($"Your new Balance After Deposite: {Balance}");
        }
        else
        {
            Console.WriteLine("Plz Enter valid balance");
        }

    }
    public void Withdraw(double balance)
    {
        if (balance > 0)
        {
            Balance -= balance;
            Console.WriteLine($"Your new Balance:  " + Balance);
        }
        else
        {
            Console.WriteLine("Your balance is insufficient");
        }
    }
    public void showbalance()
    {
        Console.WriteLine($"The current balance now: " + Balance);
    }
    public void ApplyInterest()
    {
        if (IniterestRate > 0)
        {
            double interest = Balance * (IniterestRate / 100);
            Balance += interest;
            Console.WriteLine("Interest: " + interest + " new Amount: " + Balance);
        }
    }
}


 
    class Account
{
    public static void Main(string[] args)
    {
        Dictionary<string, string> Names = new Dictionary<string, string>();


        BankAccount account = null;
        while (true)
        {

            Console.WriteLine("1.Create Account");
            Console.WriteLine("2.Deposite");
            Console.WriteLine("3.Withdraw");
            Console.WriteLine("4.Check Balance");
            Console.WriteLine("5.Apply Interest(Saving Account)");
            Console.WriteLine("6.Exit");
            Console.WriteLine("Choose an option: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter Account Type(1-Regular,2-saving): ");
                int type = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your account number: ");
                int Acc_number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Account Holder Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Initial Balance");
                Double balance = Convert.ToDouble(Console.ReadLine());
                try
                {
                    if (balance < 0) { throw new Exception("Balance cannot be negative!"); }
                    Console.WriteLine($"Balance: {balance}");
                    
                     
                }
                catch(Exception e)
                {
                    Console.WriteLine("Something went wrong");
                    Console.WriteLine();
                }

                if (type == 1)
                {
                    account = new BankAccount(Acc_number, name, balance);
                  
                    Console.WriteLine("Successful your account");
                    Console.WriteLine();
                }
                else
                {

                    Console.WriteLine("Enter Interent");
                    double interest = Convert.ToDouble(Console.ReadLine());
                    account = new BankAccount(Acc_number, name, balance,interest);

                    Console.WriteLine("Successful your account");


                }

            }
            else if (choice == 2 && account != null)
            {
                Console.WriteLine("Enter Your Deposite Amount: ");
                double amount = Convert.ToDouble(Console.ReadLine());
                account.Deposite(amount);


            }
            else if (choice == 3 && account != null)
            {
                Console.WriteLine("Enter the number of Amount: ");

                double amount = Convert.ToDouble(Console.ReadLine());
                account.Withdraw(amount);
            }
            else if (choice == 4 && account != null)
            {
                account.showbalance();
                
            }
            else if (choice == 5 && account != null)
            {

                
                
                account.ApplyInterest();
                
            }
            else
            {
                break;
            }
        }
    }
}
