using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
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
}
