using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

using System;
using System.ComponentModel.Design;
class BankAccount
{
    public int Account_number { get; set; }
    public string Name { get; set; }
    public double Balance { get; set; }

    public BankAccount(int account_number, string name, double initialbalance)
    {
        Account_number = account_number;
        Name = name;
        Balance = initialbalance;
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

}

class SavingAccount : BankAccount
{
    public double InterestRate { get; set; }

    public SavingAccount(int accountNumber, string name, double initialbalance, double interestRate)
        : base(accountNumber, name, initialbalance)
    {
        InterestRate = interestRate;
    }

    public void ApplyInterest()
    {
        if (InterestRate > 0)
        {
            double interest = Balance * (InterestRate / 100);
            Balance += interest;
            Console.WriteLine($"Interest applied: {interest}, new balance: {Balance}");
        }
        else
        {
            Console.WriteLine("No interest applied due to non-positive interest rate.");
        }
    }

}

class Account
{
    public static void Main(string[] args)
    {
        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();//Generic
        List<int> numbers = new List<int>();//Predicate Delegate
        

        BankAccount account = null;
        while (true)
        {

            Console.WriteLine("1.Create Account");
            Console.WriteLine("2.Deposite");
            Console.WriteLine("3.Withdraw");
            Console.WriteLine("4.Check Balance");
            Console.WriteLine("5.Apply Interest(Saving Account)");
            Console.WriteLine("6.Print All Saving Account number: ");
            Console.WriteLine("7.Exit");
            Console.WriteLine("Choose an option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Enter Account Type(1-Regular,2-saving): ");
                int type = Convert.ToInt32(Console.ReadLine());



                if (type == 1)
                {
                    Console.WriteLine("Enter your account number: ");
                    int Acc_number = Convert.ToInt32(Console.ReadLine());
                 
                    

                    if (!accounts.ContainsKey(Acc_number))
                    {
                        
                        numbers.Add(Acc_number);
                       
                        
                        Console.WriteLine("Enter Account Holder Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Initial Balance");
                        Double balance = Convert.ToDouble(Console.ReadLine());
                        try
                        {
                            if (balance < 0) { throw new Exception("Balance cannot be negative!"); }
                            Console.WriteLine($"Balance: {balance}");
                            Console.WriteLine("Successful your account");


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("put valid Amount");
                            Console.WriteLine();
                        }
                       

                        account = new BankAccount(Acc_number, name, balance);
                        accounts.Add(Acc_number, account);

                    }
                    else
                    {
                        Console.WriteLine("This account is already taken");
                    }

                }

                else if (type == 2)
                {

                    Console.WriteLine("Enter your account number: ");
                    int Acc_number = Convert.ToInt32(Console.ReadLine());
                    if (!accounts.ContainsKey(Acc_number))
                    {
                        numbers.Add(Acc_number);

                        Console.WriteLine("Enter Account Holder Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Initial Balance");
                        Double balance = Convert.ToDouble(Console.ReadLine());
                        try
                        {
                            if (balance < 0) { throw new Exception("Balance cannot be negative!"); }
                            Console.WriteLine($"Balance: {balance}");



                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("put valid Amount"); break;
                            Console.WriteLine();
                        }
                        Console.WriteLine("Enter Interent");
                        double interest = Convert.ToDouble(Console.ReadLine());
                        account = new SavingAccount(Acc_number, name, balance, interest);
                        accounts.Add(Acc_number, account);
                        Console.WriteLine("Successful your account");

                    }
                    else
                    {
                        Console.WriteLine("This account is already taken");
                    }


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
                try
                {
                    double amount = Convert.ToDouble(Console.ReadLine());
                    if (account.Balance - amount < 0)
                    {
                        throw new Exception("Insufficient balance");
                    }
                    account.Withdraw(amount);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Plz put in valid Amount");

                }
            }
            else if (choice == 4 && account != null)
            {
                account.showbalance();

            }
            else if (choice == 5 && account != null)
            {


                if (account is SavingAccount savingAccount)
                {
                    savingAccount.ApplyInterest();
                }
                else
                {
                    Console.WriteLine("Interest application is only available for saving accounts.");
                }

            }
            else if(choice == 6 && account != null) 
            {


                Predicate<BankAccount> isSavingAccount = acc => acc is SavingAccount;
                List<int>saving=new List<int>();
                foreach(var ac in accounts)
                {
                    if(isSavingAccount(ac.Value))
                    {
                        saving.Add(ac.Key);
                    }
                }
               Console.WriteLine($"Saving Account number: "+string.Join(", ",saving));
             }
            else{
                  
                    break;
             }
        }
    }
}