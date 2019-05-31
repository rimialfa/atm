using AutomatedTellerMachine.Services;
using Newtonsoft.Json;
using System;
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
                IdentityHash = "ACC|1234|2369",
                Number = "AJO01254",
                Balance = 500
            },
            new Account
            {
                IdentityHash = "ACC|12345|2323",
                Number = "AJO01255",
                Balance = 150
            }
        };
        public static string _session;
        public Response GetAccount(string identityHash)
        {
            Response response = new Response();
            try
            {
                if (identityHash != string.Empty)
                {
                    Account account = _accounts.Where(c => c.IdentityHash == identityHash).FirstOrDefault();
                    response.Status = true;
                    response.Message = JsonConvert.SerializeObject(account);
                }
                else
                {
                    response.Status = false;
                    response.Message = "Account not found";
                }

            }
            catch (Exception e)
            {

                response.Status = false;
                response.Message = e.ToString();
            }
            return response;
        }

        public void SetSession(string identityHash)
        {
            _session = identityHash;

        }
        public string GetSession()
        {
            return _session;
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