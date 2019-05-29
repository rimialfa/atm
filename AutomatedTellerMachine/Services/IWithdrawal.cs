using AutomatedTellerMachine.Models;
using System.Threading.Tasks;

namespace AutomatedTellerMachine.Services
{
    public interface IWithdrawal
    {
        Task<bool> Withdraw(int amount);
        Response Dispensor(int amount);
        string DispensorHelper(int amount, int denom);
    }
}