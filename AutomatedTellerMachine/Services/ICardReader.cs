using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Services
{
    public interface ICardReader
    {
        void RetainCard(Card card);
        Card GetCard(string cardNumber);
    }
}