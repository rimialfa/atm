using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomatedTellerMachine.Services
{
    public interface IWithdrawal
    {
        Task<bool> Withdraw(int amount);
        List<string> Dispensor(int amount);
        string DispensorHelper(int amount, int denom);
    }
}