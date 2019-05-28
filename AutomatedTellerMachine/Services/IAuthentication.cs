using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Services
{
    public interface IAuthentication
    {
        Response Login(string cardNumber, int pin);
    }

}