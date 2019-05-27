namespace AutomatedTellerMachine.Models
{
    public class Account
    {
        public string IdentityHash { get; set; }
        public string Number { get; set; }
        public int Balance { get; set; }
    }
}