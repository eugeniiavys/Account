using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
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
}
