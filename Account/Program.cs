
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
