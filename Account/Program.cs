﻿
namespace Account
{
    public class Account
    {
        private string name;
        private double balance;

        
        public Account(string name, double initialBalance)
        {
            this.name = name;

            if (initialBalance < 0)
            {
                this.balance = 0;
            }
            else
            {
                this.balance = initialBalance;
            }
        }

        public string Name
        {
            get { return name; }
        }

        public double Balance
        {
            get { return balance; }
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
        }

        public bool Withdrawal(double amount)
        {
            if (amount > 0 && balance >= amount)
            {
                balance -= amount;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{name}: {balance}";
        }
    }


    public abstract class Deposit
    {
        public decimal Amount { get; }
        public int Period { get; }

        protected Deposit(decimal depositAmount, int depositPeriod)
        {
            Amount = depositAmount;
            Period = depositPeriod;
        }

        public abstract decimal Income();
    }


    public class BaseDeposit : Deposit
    {
        public BaseDeposit(decimal depositAmount, int depositPeriod) : base(depositAmount, depositPeriod)
        {
        }

        public override decimal Income()
        {
            decimal total = Amount;

            for (int i = 0; i < Period; i++)
            {
                total = Math.Round(total * 1.05m, 2);
            }

            return total - Amount;
        }
    }

    public class LongDeposit : Deposit
    {
        public LongDeposit(decimal amount, int period) : base(amount, period)
        {
        }

        public override decimal Income()
        {
            decimal total = Amount;

            for (int i = 0; i < Period; i++)
            {
                if (i >= 6)
                {
                    total = Math.Round(total * 1.15m, 2);
                }
            }

            return total - Amount;
        }
    }


    public class SpecialDeposit : Deposit
    {
        public SpecialDeposit(decimal amount, int period) : base(amount, period)
        {
        }

        public override decimal Income()
        {
            decimal total = Amount;

            for (int i = 0; i < Period; i++)
            {
                decimal interestRate = (i + 1) / 100.0m;
                total = Math.Round(total * (1 + interestRate), 2);
            }

            return total - Amount;
        }
    }
    public class Client
    {
        private Deposit[] deposits;

        public Client()
        {
            deposits = new Deposit[10];
        }

        public bool AddDeposit(Deposit deposit)
        {
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] == null)
                {
                    deposits[i] = deposit;
                    return true;
                }
            }

            return false;
        }

        public decimal TotalIncome()
        {
            decimal total = 0;

            foreach (var deposit in deposits)
            {
                if (deposit != null)
                {
                    total += deposit.Income();
                }
            }

            return total;
        }

        public decimal MaxIncome()
        {
            decimal maxIncome = 0;

            foreach (var deposit in deposits)
            {
                if (deposit != null)
                {
                    decimal income = deposit.Income();
                    if (income > maxIncome)
                    {
                        maxIncome = income;
                    }
                }
            }

            return maxIncome;
        }

        public decimal GetIncomeByNumber(int number)
        {
            int index = number - 1;

            if (index >= 0 && index < deposits.Length && deposits[index] != null)
            {
                return deposits[index].Income();
            }

            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Account heikkisAccount = new Account("Heikki's account", 100.00);
            Account heikkisSwissAccount = new Account("Heikki's account in Switzerland", 1000000.00);

            Console.WriteLine("Initial state:");
            Console.WriteLine(heikkisAccount);
            Console.WriteLine(heikkisSwissAccount);

            heikkisAccount.Withdrawal(20);
            Console.WriteLine("The balance of Heikki's account is now: " + heikkisAccount.Balance);

            heikkisSwissAccount.Deposit(200);
            Console.WriteLine("The balance of Heikki's other account is now: " + heikkisSwissAccount.Balance);

         
            bool success = heikkisAccount.Withdrawal(1000);
            Console.WriteLine("Attempt to withdraw 1000 from Heikki's account: " + (success ? "Successful" : "Failed"));
            Console.WriteLine("The balance of Heikki's account is now: " + heikkisAccount.Balance);

            heikkisAccount.Deposit(-50);
            Console.WriteLine("The balance after attempt to deposit -50: " + heikkisAccount.Balance);
        }
    }
}
