using AutomatedTellerMachine.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomatedTellerMachine.Models
{
    public class AuthenticationService : IAuthentication
    {
        private IAccount _account;
        private ICardReader _cardReader;
        private static List<string> _cardAttempts = new List<string>();
        public AuthenticationService()
        {
            _account = new AccountService();
            _cardReader = new CardReaderServise();
        }
        public AuthenticationService(IAccount account, ICardReader cardReader)
        {
            _account = account;
            _cardReader = cardReader;
        }
        public Response Login(string cardNumber, int pin)
        {
            // TODO: Hash256
            string identityHash = string.Empty;
            int attempts = 0;
            Response auth = new Response();
            try
            {
                Account currentAccount = _account.GetAccount(identityHash);

                if (currentAccount != null)
                {
                    auth.Status = true;
                    auth.Message = "Login Sucess";

                }

                else
                {
                    auth.Status = false;
                    _cardAttempts.Add(cardNumber);
                    attempts = _cardAttempts.Count(c => c.Equals(cardNumber));
                    auth.Message = $"Attempt : # {attempts} Login Failed, Please insert the correct CardNumber/Pin combination!";
                    if (attempts > 3)
                    {
                        // This check is added in case the card number entered cannot be found by the CardReaderService
                        Card card = _cardReader.GetCard(cardNumber);
                        if (card != null)
                        {
                            card.IsRetained = true;
                        }

                        auth.Message = "Your card has been retained, please visit our branch for help";

                    }


                }

            }
            catch (Exception e)
            {
                auth.Status = false;
                auth.Message = e.ToString();
            }
            return auth;
        }
    }
}