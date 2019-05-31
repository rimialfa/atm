using AutomatedTellerMachine.Services;
using System.Collections.Generic;
using System.Linq;

namespace AutomatedTellerMachine.Models
{
    public class CardReaderServise : ICardReader
    {
        private static List<Card> _cards = new List<Card>()
        {
            new Card
            {
                CardNumber="1234",
                IsReported = false,
                IsRetained = false
            },
            new Card
            {
                CardNumber="12345",
                IsReported = true,
                IsRetained = false
            }
        };
        public Card GetCard(string cardNumber)
        {
            return _cards.Where(c => c.CardNumber == cardNumber).FirstOrDefault();
        }

        public void RetainCard(Card card)
        {
            card.IsRetained = true;
        }
    }
}