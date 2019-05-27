using AutomatedTellerMachine.Services;
using System.Collections.Generic;
using System.Linq;

namespace AutomatedTellerMachine.Models
{
    public class AccountService : IAccount
    {
        private List<Account> _accounts = new List<Account>()
        {
            new Account
            {
                IdentityHash = "asdasd",
                Balance = 500
            },
            new Account
            {
                IdentityHash = "asdasd",
                Balance = 150
            }
        };
        public Account GetAccount(string identityHash)
        {
            return _accounts.Where(c => c.IdentityHash == identityHash).FirstOrDefault();
        }


        public bool UpdateBalance(Account account, int amount)
        {
            // If the ammount is negative, it will decrease the balance ny the amount provided.
            // This is Implemented like this to make space for an option of deposit in the future.

            account.Balance += amount;
            return true;
        }

    }
}