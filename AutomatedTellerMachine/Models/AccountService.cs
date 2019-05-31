using AutomatedTellerMachine.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomatedTellerMachine.Models
{
    public class AccountService : IAccount
    {
        private static List<Account> _accounts = new List<Account>()
        {
            new Account
            { 
                // the hash is in this format "ACC|{cardNumber}|{pin}"
                IdentityHash = "ACC|1234|1234",
                Number = "AJO01254",
                Balance = 500
            },
            new Account
            {
                IdentityHash = "ACC|12345|12345",
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
                    if (account != null)
                    {
                        response.Status = true;
                        response.Message = JsonConvert.SerializeObject(account);
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Account not found";
                    }

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

        public Response UpdateBalance(int amount)
        {
            // If the ammount is negative, it will decrease the balance ny the amount provided.
            // This is Implemented like this to make space for an option of deposit in the future.
            Response response = new Response();
            try
            {
                Account account = _accounts.Where(c => c.IdentityHash == _session).FirstOrDefault();
                account.Balance += amount;
                response.Status = true;

            }
            catch (Exception e)
            {
                response.Status = true;
                response.Message = e.ToString();
            }

            return response;
        }

    }
}