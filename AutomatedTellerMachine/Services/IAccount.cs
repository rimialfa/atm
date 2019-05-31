using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Services
{
    public interface IAccount
    {
        Response GetAccount(string identityHash);
        void SetSession(string identityHash);
        string GetSession();
        Response UpdateBalance(int amount);
    }
}