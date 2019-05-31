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
        public static string session = string.Empty;
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
        public Response Login(string cardNumber, string pin)
        {
            // Here we are not really hashing the card number with the pin, for demo purposes
            string identityHash = "ACC" + "|" + cardNumber.Trim().ToLower() + "|" + pin;
            int attempts = 0;
            Response auth = new Response();
            try
            {

                Card card = _cardReader.GetCard(cardNumber);
                if (card != null)
                {
                    if (!card.IsReported && !card.IsRetained)
                    {
                        Response currentAccount = _account.GetAccount(identityHash);
                        if (currentAccount.Status)
                        {
                            _account.SetSession(identityHash);
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
                                _cardReader.RetainCard(_cardReader.GetCard(cardNumber));
                                auth.Message = "This card has been retained, please visit our branch for help";
                                _cardAttempts.Clear();
                                _account.SetSession("");
                            }
                        }
                    }
                    else
                    {
                        if (!card.IsRetained)
                        {
                            _cardReader.RetainCard(_cardReader.GetCard(cardNumber));
                        }

                        auth.Message = "This card has been retained, please visit our branch for help";
                    }

                }

                else
                {
                    // In case the card is not found by the card reader service
                    auth.Status = false;
                    auth.Message = "Wrong card number";

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