using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Services
{
    public interface IAccount
    {
        Response GetAccount(string identityHash);
        void SetSession(string identityHash);
        string GetSession();
        bool UpdateBalance(Account account, int amount);
    }
}