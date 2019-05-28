using AutomatedTellerMachine.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomatedTellerMachine.Models
{
    public class WithdrawalService : IWithdrawal
    {
        public List<string> Dispensor(int amount)
        {
            throw new NotImplementedException();
        }

        public string DispensorHelper(int amount, int denom)
        {
            if (amount / denom < 1)
                return string.Empty;
            else
            {
                int count = amount / denom;
                int prevDenom = denom;
                if (denom == 1000)
                    denom = 500;
                else if (denom == 500)
                    denom = 200;
                else if (denom == 200)
                    denom = 100;
                else if (denom == 100)
                    denom = 50;
                else if (denom == 50)
                    denom = 20;
                else
                    denom = 10;

                return Convert.ToString(count) + "*" + Convert.ToString(prevDenom) + "+" + DispensorHelper(amount - (count * prevDenom), denom);
            }
        }

        public Task<bool> Withdraw(int amount)
        {
            throw new NotImplementedException();
        }

    }
}