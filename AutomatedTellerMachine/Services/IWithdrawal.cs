using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Services
{
    public interface IWithdrawal
    {
        Response Dispensor(int amount);
        Response Denominator(int amount);
        string DenominatorHelper(int amount, int denom);
    }
}