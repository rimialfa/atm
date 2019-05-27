using AutomatedTellerMachine.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedTellerMachine.Models
{
    public class CardReaderServise : ICardReader
    {
        private List<Card> _cards = new List<Card>()
        {
            new Card
            {
                CardNumber="5368",
                IsReported = false,
                IsRetained = false
            },
            new Card
            {
                CardNumber="4850",
                IsReported = true,
                IsRetained = false
            }
        };
        public Card GetCard(string cardNumber)
        {
            return _cards.Where(c => c.CardNumber == cardNumber).FirstOrDefault();
        }

        public async Task<bool> RetainCard(Card card)
        {
            await Task.Delay(1000);
            card.IsRetained = false;
            return true;
        }
    }
}