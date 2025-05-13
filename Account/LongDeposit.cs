using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
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
}
