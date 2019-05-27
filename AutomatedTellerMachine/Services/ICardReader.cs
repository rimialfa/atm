using AutomatedTellerMachine.Models;
using System.Threading.Tasks;

namespace AutomatedTellerMachine.Services
{
    public interface ICardReader
    {
        Task<bool> RetainCard(Card card);
        Card GetCard(string cardNumber);
    }
}