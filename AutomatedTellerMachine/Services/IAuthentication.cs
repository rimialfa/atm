using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Services
{
    public interface IAuthentication
    {
        Auth Login(string cardNumber, int pin);
    }

}