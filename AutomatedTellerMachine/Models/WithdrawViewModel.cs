namespace AutomatedTellerMachine.Models
{
    public class WithdrawViewModel
    {
        public string Error { get; set; }
        public Account Account { get; set; }
        public int Amount { get; set; }
    }
}