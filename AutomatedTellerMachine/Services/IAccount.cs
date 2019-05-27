using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Services
{
    public interface IAccount
    {
        Account GetAccount(string identityHash);
        bool UpdateBalance(Account account, int amount);
    }
}