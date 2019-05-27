using AutomatedTellerMachine.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public Task<bool> AttemptIncrementer()
        {
            throw new System.NotImplementedException();
        }


        public Auth Login(string cardNumber, int pin)
        {
            // TODO: Hash256
            string identityHash = string.Empty;
            Account currentAccount = _account.GetAccount(identityHash);
            Auth auth = new Auth();
            if (currentAccount != null)
            {
                auth.Status = true;
                auth.Message = "Login Sucess";
                auth.Attempts = 0;
                return auth;

            }

            else
            {
                auth.Status = false;
                _cardAttempts.Add(cardNumber);
                auth.Attempts = _cardAttempts.Count(c => c.Equals(cardNumber));
                auth.Message = $"Attempt : # {auth.Attempts} Login Failed, Please insert the correct CardNumber/Pin combination!";
                if (auth.Attempts > 3)
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
            return auth;
        }
    }
}