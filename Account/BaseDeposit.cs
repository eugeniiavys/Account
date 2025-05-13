using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    public class BaseDeposit : Deposit
    {
        public BaseDeposit(decimal depositAmount, int depositPeriod) : base(depositAmount, depositPeriod)
        {
        }

        public override decimal Income()
        {
            decimal total = Amount;

            for(int i =0; i< Period; i++)
            {
                total = Math.Round(total * 1.05m, 2);
            }

            return total - Amount;
        }
    }
}
